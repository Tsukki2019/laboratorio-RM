using UnityEngine;

public class MezcladorJSON : MonoBehaviour
{
    public ArduinoJSON arduino;

    public Transform visual1;
    public Transform visual2;
    public Transform visual3;

    void Update()
    {
        if (arduino == null)
            return;

        float valor = arduino.pot / 1023f;

       
        if (visual1 != null)
        {
            float escala = Mathf.Lerp(0.5f, 2f, valor);

            visual1.localScale = new Vector3(
                escala,
                escala,
                1f
            );
        }

        
        if (arduino.b1 == 0 && visual1 != null)
        {
            visual1.Rotate(
                0f,
                0f,
                100f * Time.deltaTime
            );
        }

        
        if (arduino.b2 == 0 && visual2 != null)
        {
            visual2.Rotate(
                0f,
                0f,
                150f * Time.deltaTime
            );
        }

        
        if (arduino.b3 == 0 && visual3 != null)
        {
            Vector3 posicion = visual3.position;

            posicion.y = Mathf.Sin(Time.time * 3f) * 2f;

            visual3.position = posicion;
        }

        
        if (arduino.b4 == 0 && visual2 != null)
        {
            float pulso =
                1f + Mathf.Sin(Time.time * 5f) * 0.5f;

            visual2.localScale = new Vector3(
                pulso,
                pulso,
                1f
            );
        }
    }
}