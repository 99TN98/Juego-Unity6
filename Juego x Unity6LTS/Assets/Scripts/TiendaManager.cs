using UnityEngine;
using TMPro;


public class TiendaManager : MonoBehaviour
{
    //Visual
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
    private int NumeroExpansion;
    //Expansion
    [SerializeField] private GameObject Expansion1;
    [SerializeField] private GameObject BotonHelado;
    [SerializeField] private GameObject Expansion2;
    [SerializeField] private GameObject BotonHamb;
    [SerializeField] private GameObject Expansion3;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cantidadPanchos = 5;
        cantidadHelados = 0;
        cantidadHamb = 0;
        cantidadMonedas = 10000;
        maxReputacion = 100;
        cantidadReputacion = 1000;
        NumeroSeleccion = 0;
        Expansion2.SetActive(false);
        Expansion3.SetActive(false);
        BotonHelado.SetActive(false);
        BotonHamb.SetActive(false);
        NumeroExpansion = 1;
        ActualizarUI();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ComprarExpansion()
    {
       //Expansion 1 Helado
       if (cantidadMonedas >= 100 && cantidadReputacion >= 40 && NumeroExpansion == 1)
        {
            Expansion1.SetActive(false);
            cantidadMonedas -= 100;
            Expansion2.SetActive(true);
            BotonHelado.SetActive(true);
            ActualizarUI();
            NumeroExpansion++;
            return;
        }
        //Expansion 2 Hamburguesa
        if (cantidadMonedas >= 250 && cantidadReputacion >= 60 && NumeroExpansion == 2)
        {
            Expansion2.SetActive(false);
            cantidadMonedas -= 250;
            Expansion3.SetActive(true);
            BotonHamb.SetActive(true);
            ActualizarUI();
            NumeroExpansion++;
            return;
        }
        //Expansion 3 Win - Siguiente etapa
        if (cantidadMonedas >= 500 && cantidadReputacion >= 80 && NumeroExpansion == 3)
        {
            Expansion3.SetActive(false);
            cantidadMonedas -= 500;
            ActualizarUI();
            NumeroExpansion++;
            return;
        }
       
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
