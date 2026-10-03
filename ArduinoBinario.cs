using UnityEngine;
using System.IO.Ports;

public class ArduinoBinario : MonoBehaviour
{
    SerialPort puerto;

    public string puertoArduino = "COM4";
    public int velocidad = 9600;

    public int b1 = 1;
    public int b2 = 1;
    public int b3 = 1;
    public int b4 = 1;
    public int pot = 0;

    void Start()
    {
        puerto = new SerialPort(puertoArduino, velocidad);

        try
        {
            puerto.Open();

            Debug.Log("Binario conectado");
        }
        catch (System.Exception e)
        {
            Debug.LogError(e.Message);
        }
    }

    void Update()
    {
        if (puerto != null && puerto.IsOpen)
        {
            LeerBinario();
        }
    }

    void LeerBinario()
    {
        try
        {
            while (puerto.BytesToRead > 0)
            {
                int cabecera = puerto.ReadByte();

                if (cabecera == 0xAA)
                {
                    int longitud = puerto.ReadByte();

                    if (longitud == 6)
                    {
                        byte rb1 = (byte)puerto.ReadByte();
                        byte rb2 = (byte)puerto.ReadByte();
                        byte rb3 = (byte)puerto.ReadByte();
                        byte rb4 = (byte)puerto.ReadByte();

                        byte potH = (byte)puerto.ReadByte();
                        byte potL = (byte)puerto.ReadByte();

                        byte checksum =
                            (byte)puerto.ReadByte();

                        byte suma =
                            (byte)(
                                rb1 +
                                rb2 +
                                rb3 +
                                rb4 +
                                potH +
                                potL
                            );

                        if (checksum == suma)
                        {
                            b1 = rb1;
                            b2 = rb2;
                            b3 = rb3;
                            b4 = rb4;

                            pot =
                                (potH << 8) | potL;

                            Debug.Log(
                                "BINARIO -> " +
                                "B1:" + b1 +
                                " B2:" + b2 +
                                " B3:" + b3 +
                                " B4:" + b4 +
                                " POT:" + pot
                            );
                        }
                    }
                }
            }
        }
        catch
        {
        }
    }

    void OnApplicationQuit()
    {
        if (puerto != null &&
            puerto.IsOpen)
        {
            puerto.Close();
        }
    }
}