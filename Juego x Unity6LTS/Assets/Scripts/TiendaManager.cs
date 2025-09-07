using UnityEngine;
using TMPro;


public class TiendaManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI TextoPancho;
    [SerializeField] private TextMeshProUGUI TextoHelado;
    [SerializeField] private TextMeshProUGUI TextoHamb;
    [SerializeField] private TextMeshProUGUI TextoMonedas;
    [SerializeField] private TextMeshProUGUI TextoReputacion;
    private int cantidadPanchos;
    private int cantidadHelados;
    private int cantidadHamb;
    private int cantidadMonedas;
    private int cantidadReputacion;
    private int maxReputacion;
    private int NumeroSeleccion;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cantidadPanchos = 5;
        cantidadHelados = 0;
        cantidadHamb = 0;
        cantidadMonedas = 20;
        maxReputacion = 100;
        cantidadReputacion = 20;
        NumeroSeleccion = 0;
        ActualizarUI();
    }

    // Update is called once per frame
    void Update()
    {

    }
 /*   void Update() 
    {
        if (NumeroSeleccion == 1 && cantidadMonedas >= 2)
        {
            cantidadPanchos++;
            cantidadMonedas -= 2;
            TextoPancho.text = "x " + cantidadPanchos;
        }
        if (NumeroSeleccion == 2 && cantidadMonedas >= 3)
        {
            cantidadHelados++;
            cantidadMonedas -= 3;
            TextoHelado.text = "x " + cantidadHelados;
        }
        if (NumeroSeleccion == 3 && cantidadMonedas >= 5)
        {
            cantidadMonedas -= 5;
            cantidadHamb++;
            TextoHamb.text = "x " + cantidadHamb;
        }
    }
 */

    public void ComprarArticulo()
    {
        switch (NumeroSeleccion)
        {
            case 1:  // Panchos
                if (cantidadMonedas >= 2)  
                {
                    cantidadPanchos++;
                    cantidadMonedas -= 2;
                    TextoPancho.text = "x " + cantidadPanchos;
                    ActualizarUI();  
                }
                break;

            case 2:  // Helados
                if (cantidadMonedas >= 3)  
                {
                    cantidadHelados++;
                    cantidadMonedas -= 3;
                    TextoHelado.text = "x " + cantidadHelados;
                    ActualizarUI();  
                }
                break;

            case 3:  // Hamb
                if (cantidadMonedas >= 5) 
                {
                    cantidadHamb++;
                    cantidadMonedas -= 5;
                    TextoHamb.text = "x " + cantidadHamb;
                    ActualizarUI(); 
                }
                break;

            default:
                Debug.LogWarning("Selecciona un objeto para comprar");
                break;
        }
    }
    private void ActualizarUI()
    {
        TextoMonedas.text = cantidadMonedas.ToString();
        TextoReputacion.text = cantidadReputacion.ToString() + "/100"; ;
    }
    public void CambiarSeleccion (int seleccion)
    {
        NumeroSeleccion = seleccion;
        Debug.Log("Numero seleccionado para compra = " + NumeroSeleccion);
    }


}
