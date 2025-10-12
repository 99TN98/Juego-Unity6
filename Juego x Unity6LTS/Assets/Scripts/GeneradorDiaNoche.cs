using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;  

public class GeneradorDiaNoche : MonoBehaviour
{
    [SerializeField] private Light2D luzGlobal;
    [SerializeField] private GameObject luzObjetos;
    [SerializeField] private Color nocheColor;
    [SerializeField] private Color diaColor;
    [SerializeField] private float segundos;
    [SerializeField] private float duracionTransicion = 2f;  

    private bool esDeNoche = false;

    void Start()
    {
        
        if (diaColor == null)
        {
            diaColor = luzGlobal.color;
        }

       
        StartCoroutine(CambiarColorGradualmente());
    }

    IEnumerator CambiarColorGradualmente()
    {
        while (true)
        {
            
            Color objetivoColor = esDeNoche ? nocheColor : diaColor;

           
            float tiempoTranscurrido = 0f;
            Color colorInicial = luzGlobal.color;

            
            while (tiempoTranscurrido < duracionTransicion)
            {
                tiempoTranscurrido += Time.deltaTime;
                luzGlobal.color = Color.Lerp(colorInicial, objetivoColor, tiempoTranscurrido / duracionTransicion);
                yield return null;  
            }

            
            luzGlobal.color = objetivoColor;

            
            esDeNoche = !esDeNoche;

            if (esDeNoche)
            {
                luzObjetos.SetActive(true);  
            }
            else
            {
                luzObjetos.SetActive(false);  
            }


            yield return new WaitForSeconds(segundos);
        }
    }
}