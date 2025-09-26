using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;


public class TiendaManager : MonoBehaviour
{

    //----------
    public static event Action<int> OnReputacionCambiada;
    public static event Action<int> OnMonedasCambiadas;
    //----------
    //Visual
    [SerializeField] private TextMeshProUGUI TextoPancho;
    [SerializeField] private TextMeshProUGUI TextoHelado;
    [SerializeField] private TextMeshProUGUI TextoHamb;
    //[SerializeField] private TextMeshProUGUI TextoMonedas;
    //[SerializeField] private TextMeshProUGUI TextoReputacion;
    private int cantidadPanchos;
    private int cantidadHelados;
    private int cantidadHamb;
    private int cantidadMonedas;
    private int cantidadReputacion;
    private int maxReputacion;
    private int NumeroSeleccion;
    private int NumeroExpansion;
    //Expansion 2.0
    [SerializeField] private List<Expansion> listaDeExpansiones; // Se ve en el Inspector
    private Queue<Expansion> expansiones = new Queue<Expansion>();
    [SerializeField] private List<TextMeshProUGUI> textosCostosExpansiones;

    //Expansion
    [SerializeField] private GameObject Expansion1;
    [SerializeField] private GameObject BotonHelado;
    [SerializeField] private GameObject Expansion2;
    [SerializeField] private GameObject BotonHamb;
    [SerializeField] private GameObject Expansion3;
    [SerializeField] private GameObject Puesto2;
    [SerializeField] private GameObject Puesto3;
    //Colisiones
    int Comprar = 1;
    public bool EstadoComprador = true;
    //Condicion de victoria y derrota
    [SerializeField] private GameObject Victoria;
    [SerializeField] private GameObject Derrota;
    public bool PausaJuego = false;
    

    void Start()
    {
        cantidadPanchos = 5;
        cantidadHelados = 0;
        cantidadHamb = 0;
        //cantidadMonedas = 250;
        cantidadMonedas = 1250;
        maxReputacion = 100;
        //cantidadReputacion = 50;
        cantidadReputacion = 90;
        NumeroSeleccion = 0;
        Expansion2.SetActive(false);
        Expansion3.SetActive(false);
        BotonHelado.SetActive(false);
        BotonHamb.SetActive(false);
        Victoria.SetActive(false);
        Derrota.SetActive(false);
        NumeroExpansion = 1;
        ActualizarUI();
        foreach (Expansion e in listaDeExpansiones)
        {
            expansiones.Enqueue(e);
        }
        for (int i = 0; i < listaDeExpansiones.Count; i++)
        {
            var expansion = listaDeExpansiones[i];
            var texto = textosCostosExpansiones[i];

            texto.text = $"x{expansion.CostoReputacion}     {expansion.CostoMonedas}x";
        }

    }

    public void ComprarExpansion()
    {
        if (expansiones.Count == 0) return;

        Expansion actual = expansiones.Dequeue(); // Saca la expansion actual

        if (cantidadMonedas >= actual.CostoMonedas && cantidadReputacion >= actual.CostoReputacion)
        {
            cantidadMonedas -= actual.CostoMonedas;

            if (actual.ObjetoExpansion != null)
                actual.ObjetoExpansion.SetActive(false); // Desactivás expansion comprada

            if (actual.BotonProducto != null)
                actual.BotonProducto.SetActive(true); // Activa el boton del producto comprado

            // Activa la siguiente cola si hay
            if (expansiones.Count > 0)
            {
                Expansion siguiente = expansiones.Peek();

                if (siguiente.ObjetoExpansion != null)
                    siguiente.ObjetoExpansion.SetActive(true);  // Activa la siguiente expansion
            }
            else
            {
                if (Victoria != null)
                {
                    Victoria.SetActive(true);
                    PausaJuego = true;
                }
            }

            ActualizarUI();
        }
    }

    //----------
    private void CambiarReputacion(int cantidad)
    {
        cantidadReputacion += cantidad;

        if (cantidadReputacion >= maxReputacion)
            cantidadReputacion = maxReputacion;

        if (cantidadReputacion <= 0)
        {
            cantidadReputacion = 0;
            Derrota.SetActive(true);
            PausaJuego = true;
        }

        OnReputacionCambiada?.Invoke(cantidadReputacion);

    }
    private void CambiarMonedas(int cantidad)
    {
        cantidadMonedas += cantidad;

        if (cantidadMonedas < 0)
            cantidadMonedas = 0;

        OnMonedasCambiadas?.Invoke(cantidadMonedas);
    }
    //----------
    // Update is called once per frame
    void Update()
    {

    }

    /*----------------
     public void ComprarExpansion()
    {
       //Expansion 1 Helado
       if (cantidadMonedas >= 100 && cantidadReputacion >= 40 && NumeroExpansion == 1)
        {
            Expansion1.SetActive(false);
            CambiarMonedas(-100);
            //cantidadMonedas -= 100;
            Expansion2.SetActive(true);
            BotonHelado.SetActive(true);
            Puesto2.SetActive(false);
            ActualizarUI();
            NumeroExpansion++;
            return;
        }
        //Expansion 2 Hamburguesa
        if (cantidadMonedas >= 250 && cantidadReputacion >= 60 && NumeroExpansion == 2)
        {
            Expansion2.SetActive(false);
            CambiarMonedas(-250);
            //cantidadMonedas -= 250;
            Expansion3.SetActive(true);
            BotonHamb.SetActive(true);
            Puesto3.SetActive(false);
            ActualizarUI();
            NumeroExpansion++;
            return;
        }
        //Expansion 3 Win - Siguiente etapa
        if (cantidadMonedas >= 500 && cantidadReputacion >= 80 && NumeroExpansion == 3)
        {
            Expansion3.SetActive(false);
            CambiarMonedas(-500);
            //cantidadMonedas -= 500;
            ActualizarUI();
            NumeroExpansion++;
            Victoria.SetActive(true);
            PausaJuego = true;
            return;
        }
       
    }*/
    //-----------------

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
                    CambiarMonedas(-2);
                    //cantidadMonedas -= 2;
                    ActualizarUI();  
                }
                break;

            case 2:  // Helados
                if (cantidadMonedas >= 3)  
                {
                    cantidadHelados++;
                    CambiarMonedas(-3);
                    // cantidadMonedas -= 3;
                    ActualizarUI();  
                }
                break;

            case 3:  // Hamb
                if (cantidadMonedas >= 5) 
                {
                    cantidadHamb++;
                    CambiarMonedas(-5);
                    // cantidadMonedas -= 5;
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
        //TextoMonedas.text = cantidadMonedas.ToString();
        //TextoReputacion.text = cantidadReputacion.ToString() + "/100";
        TextoPancho.text = "x " + cantidadPanchos;
        TextoHelado.text = "x " + cantidadHelados;
        TextoHamb.text = "x " + cantidadHamb;
        OnReputacionCambiada?.Invoke(cantidadReputacion);
        OnMonedasCambiadas?.Invoke(cantidadMonedas);
    }
    public void CambiarSeleccion (int seleccion)
    {
        NumeroSeleccion = seleccion;
        Debug.Log("Numero seleccionado para compra = " + NumeroSeleccion);
    }

    public void RecibirCompra(int tipo)
    {
        Comprar = tipo;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (Comprar)
        {
            case 1:
                if (cantidadPanchos > 0)
                { 
                    cantidadPanchos--;
                    CambiarMonedas(10);
                    //cantidadMonedas += 10;
                    //cantidadReputacion += 1;
                    CambiarReputacion(1);

                    EstadoComprador = true;
                }
                else
                {
                    CambiarReputacion(-1);
                    //cantidadReputacion--;
                    EstadoComprador = false;
}
                break;

            case 2:
                if (cantidadHelados > 0)
                {
                    cantidadHelados--;
                    //cantidadMonedas += 20;
                    CambiarMonedas(20);
                    CambiarReputacion(2);
                    //cantidadReputacion += 2;
                    EstadoComprador = true;
                }
                else
                {
                    CambiarReputacion(-1);
                    //cantidadReputacion--;
                    EstadoComprador = false;
                }
                break;

            case 3:
                if (cantidadHamb > 0)
                {
                    cantidadHamb--;
                    //cantidadMonedas += 40;
                    CambiarMonedas(40);
                    CambiarReputacion(3);
                    //cantidadReputacion += 3;
                    EstadoComprador = true;
                }
                else
                {
                    //cantidadReputacion--;
                    CambiarReputacion(-1);
                    EstadoComprador = false;
                }
                break;
        }
        /*
        if (cantidadReputacion >= maxReputacion)
        {
            cantidadReputacion = 100;
        };
        if (cantidadReputacion <= 0)
        {
            Derrota.SetActive(true);
            PausaJuego = true;
        };*/
        ActualizarUI();
    }


}
