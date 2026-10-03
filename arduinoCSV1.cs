using UnityEngine;
using System.IO.Ports;

public class ArduinoCSV : MonoBehaviour
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
        puertoArduino = "COM4";

        puerto = new SerialPort(puertoArduino, velocidad);
        puerto.ReadTimeout = 50;

        try
        {
            puerto.Open();
            Debug.Log("Arduino CSV conectado correctamente.");
        }
        catch (System.Exception e)
        {
            Debug.LogError("No se pudo conectar al Arduino CSV: " + e.Message);
        }
    }

    void Update()
    {
        if (puerto != null && puerto.IsOpen)
        {
            try
            {
                string datos = puerto.ReadLine();

                ProcesarDatos(datos);
            }
            catch (System.TimeoutException)
            {
            }
            catch (System.Exception e)
            {
                Debug.LogWarning("Error leyendo CSV: " + e.Message);
            }
        }
    }

    void ProcesarDatos(string datos)
    {
        string[] valores = datos.Trim().Split(',');

        if (valores.Length != 5)
        {
            return;
        }

        int.TryParse(valores[0], out b1);
        int.TryParse(valores[1], out b2);
        int.TryParse(valores[2], out b3);
        int.TryParse(valores[3], out b4);
        int.TryParse(valores[4], out pot);

        Debug.Log(
            "CSV → B1: " + b1 +
            " | B2: " + b2 +
            " | B3: " + b3 +
            " | B4: " + b4 +
            " | POT: " + pot
        );
    }

    void OnApplicationQuit()
    {
        if (puerto != null && puerto.IsOpen)
        {
            puerto.Close();
        }
    }
}