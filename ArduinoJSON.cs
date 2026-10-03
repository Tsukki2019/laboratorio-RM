using UnityEngine;
using System.IO.Ports;

[System.Serializable]
public class DatosArduinoJSON
{
    public int b1;
    public int b2;
    public int b3;
    public int b4;
    public int pot;
}

public class ArduinoJSON : MonoBehaviour
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

            Debug.Log("Arduino JSON conectado correctamente.");
        }
        catch (System.Exception e)
        {
            Debug.LogError(
                "No se pudo conectar al Arduino JSON: " + e.Message
            );
        }
    }

    void Update()
    {
        if (puerto != null && puerto.IsOpen)
        {
            try
            {
                string datos = puerto.ReadLine();

                ProcesarJSON(datos);
            }
            catch (System.TimeoutException)
            {
            }
            catch (System.Exception e)
            {
                Debug.LogWarning(
                    "Error leyendo JSON: " + e.Message
                );
            }
        }
    }

    void ProcesarJSON(string datos)
    {
        try
        {
            DatosArduinoJSON datosArduino =
                JsonUtility.FromJson<DatosArduinoJSON>(datos);

            b1 = datosArduino.b1;
            b2 = datosArduino.b2;
            b3 = datosArduino.b3;
            b4 = datosArduino.b4;
            pot = datosArduino.pot;

            Debug.Log(
                "JSON → B1: " + b1 +
                " | B2: " + b2 +
                " | B3: " + b3 +
                " | B4: " + b4 +
                " | POT: " + pot
            );
        }
        catch
        {
            Debug.LogWarning("JSON inválido: " + datos);
        }
    }

    void OnApplicationQuit()
    {
        if (puerto != null && puerto.IsOpen)
        {
            puerto.Close();
        }
    }
}