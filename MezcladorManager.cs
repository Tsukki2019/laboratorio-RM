using UnityEngine;

public class MezcladorVisual : MonoBehaviour
{
    [Header("PROTOCOLO")]
    public bool usarJSON = true;

    [Header("ARDUINO")]
    public ArduinoCSV csv;
    public ArduinoJSON json;

    [Header("IMAGENES")]
    public Transform visual1;
    public Transform visual2;
    public Transform visual3;

    
    private int anteriorB1 = 1;
    private int anteriorB2 = 1;
    private int anteriorB3 = 1;
    private int anteriorB4 = 1;

    
    private Vector3 posicionOriginal3;

    void Start()
    {
        if (visual3 != null)
        {
            posicionOriginal3 = visual3.position;
        }
    }

    void Update()
    {
       

        int b1;
        int b2;
        int b3;
        int b4;
        int pot;

        if (usarJSON)
        {
            if (json == null)
                return;

            b1 = json.b1;
            b2 = json.b2;
            b3 = json.b3;
            b4 = json.b4;
            pot = json.pot;
        }
        else
        {
            if (csv == null)
                return;

            b1 = csv.b1;
            b2 = csv.b2;
            b3 = csv.b3;
            b4 = csv.b4;
            pot = csv.pot;
        }

      
        float valor = Mathf.Clamp01(pot / 1023f);

        if (visual1 != null)
        {
            float escala = Mathf.Lerp(0.7f, 1.8f, valor);

            visual1.localScale = new Vector3(
                escala,
                escala,
                1f
            );
        }

        

        if (b1 == 0 && anteriorB1 == 1)
        {
            if (visual1 != null)
            {
                visual1.Rotate(
                    0f,
                    0f,
                    45f
                );
            }
        }

        

        if (b2 == 0 && anteriorB2 == 1)
        {
            if (visual2 != null)
            {
                visual2.Rotate(
                    0f,
                    0f,
                    45f
                );
            }
        }

       

        if (b3 == 0 && anteriorB3 == 1)
        {
            if (visual3 != null)
            {
                Vector3 posicion = visual3.position;

                posicion.y += 1f;

                visual3.position = posicion;
            }
        }

        

        if (b4 == 0 && anteriorB4 == 1)
        {
            if (visual2 != null)
            {
                Vector3 escala = visual2.localScale;

                escala *= 1.2f;

                visual2.localScale = escala;
            }
        }

      

        anteriorB1 = b1;
        anteriorB2 = b2;
        anteriorB3 = b3;
        anteriorB4 = b4;
    }
}