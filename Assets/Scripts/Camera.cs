using UnityEngine;


public class Camera : MonoBehaviour
{
    [SerializeField] private float distancia = 10f;
    [SerializeField] private float velocidadRotacion = 80f; 
    [SerializeField] private float anguloMinY = -20f;
    [SerializeField] private float anguloMaxY = 80f;

    private float rotacionX = 0f;
    private float rotacionY = 20f;

    void Start()
    {

        GameObject origen = new GameObject("CentroDeOrbitaVirtual");
        origen.transform.position = Vector3.zero;

    }

    void LateUpdate()
    {
       
        float entradaHorizontal = Input.GetAxis("Horizontal");
        float entradaVertical = Input.GetAxis("Vertical");

        rotacionX += entradaHorizontal * velocidadRotacion * Time.deltaTime;
        rotacionY -= entradaVertical * velocidadRotacion * Time.deltaTime;
        
        rotacionY = Mathf.Clamp(rotacionY, anguloMinY, anguloMaxY);

        Quaternion rotacionCualquiera = Quaternion.Euler(rotacionY, rotacionX, 0f);
        Vector3 posicionCalculada = (rotacionCualquiera * new Vector3(0.0f, 0.0f, -distancia));

        transform.rotation = rotacionCualquiera;
        transform.position = posicionCalculada;
    }

}

