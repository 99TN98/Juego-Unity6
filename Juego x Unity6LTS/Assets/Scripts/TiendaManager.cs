using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;


public class TiendaManager : MonoBehaviour
{
    [SerializeField]
    private PerfilJugador perfilJugador;
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
    //private int cantidadPanchos;
    //private int cantidadHelados;
    //rivate int cantidadHamb;
    //private int cantidadMonedas;
    //private int cantidadReputacion;
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

        //cantidadPanchos = 5;
        //cantidadHelados = 0;
        //cantidadHamb = 0;
        //cantidadMonedas = 250;
        maxReputacion = 100;
        //cantidadReputacion = 50;
        //cantidadReputacion = 90;
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

            expansion.CostoMonedas = perfilJugador.costosExpansionesMonedas[i];
            expansion.CostoReputacion = perfilJugador.costosExpansionesReputacion[i];

            texto.text = $"x{expansion.CostoReputacion}     {expansion.CostoMonedas}x";
        }

    }

    public void ComprarExpansion()
    {
        if (expansiones.Count == 0) return;

        Expansion actual = expansiones.Dequeue(); // Saca la expansion actual

        if (perfilJugador.cantidadMonedas >= actual.CostoMonedas && perfilJugador.cantidadReputacion >= actual.CostoReputacion)
        {
            perfilJugador.cantidadMonedas -= actual.CostoMonedas;

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
        perfilJugador.cantidadReputacion += cantidad;

        if (perfilJugador.cantidadReputacion >= maxReputacion)
            perfilJugador.cantidadReputacion = maxReputacion;

        if (perfilJugador.cantidadReputacion <= 0)
        {
            perfilJugador.cantidadReputacion = 0;
            Derrota.SetActive(true);
            PausaJuego = true;
        }

        OnReputacionCambiada?.Invoke(perfilJugador.cantidadReputacion);

    }
    private void CambiarMonedas(int cantidad)
    {
        perfilJugador.cantidadMonedas += cantidad;

        if (perfilJugador.cantidadMonedas < 0)
            perfilJugador.cantidadMonedas = 0;

        OnMonedasCambiadas?.Invoke(perfilJugador.cantidadMonedas);
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
                if (perfilJugador.cantidadMonedas >= perfilJugador.costoPanchosCompra)  
                {
                    perfilJugador.cantidadPanchos++;
                    CambiarMonedas(-perfilJugador.costoPanchosCompra);

                    //CambiarMonedas(-2);
                    //cantidadMonedas -= 2;
                    ActualizarUI();  
                }
                break;

            case 2:  // Helados
                if (perfilJugador.cantidadMonedas >= perfilJugador.costoHeladosCompra)  
                {
                    perfilJugador.cantidadHelados++;
                    CambiarMonedas(-perfilJugador.costoHeladosCompra);
                    // cantidadMonedas -= 3;
                    ActualizarUI();  
                }
                break;

            case 3:  // Hamb
                if (perfilJugador.cantidadMonedas >= perfilJugador.costoHambCompra) 
                {
                    perfilJugador.cantidadHamb++;
                    CambiarMonedas(perfilJugador.costoHambCompra);
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
        TextoPancho.text = "x " + perfilJugador.cantidadPanchos;
        TextoHelado.text = "x " + perfilJugador.cantidadHelados;
        TextoHamb.text = "x " + perfilJugador.cantidadHamb;
        OnReputacionCambiada?.Invoke(perfilJugador.cantidadReputacion);
        OnMonedasCambiadas?.Invoke(perfilJugador.cantidadMonedas);
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
                if (perfilJugador.cantidadPanchos > 0)
                {
                    perfilJugador.cantidadPanchos--;
                    CambiarMonedas(perfilJugador.costoPanchosVenta);
                    //CambiarMonedas(5);
                    //cantidadMonedas += 10;
                    //cantidadReputacion += 1;
                    CambiarReputacion(perfilJugador.ReputacionGanada);

                    EstadoComprador = true;
                }
                else
                {
                    CambiarReputacion(-perfilJugador.ReputacionPerdida);
                    //cantidadReputacion--;
                    EstadoComprador = false;
}
                break;

            case 2:
                if (perfilJugador.cantidadHelados > 0)
                {
                    perfilJugador.cantidadHelados--;
                    //cantidadMonedas += 20;
                    CambiarMonedas(perfilJugador.costoHeladosVenta);
                    CambiarReputacion(perfilJugador.ReputacionGanada);
                    //cantidadReputacion += 2;
                    EstadoComprador = true;
                }
                else
                {
                    CambiarReputacion(-perfilJugador.ReputacionPerdida);
                    //cantidadReputacion--;
                    EstadoComprador = false;
                }
                break;

            case 3:
                if (perfilJugador.cantidadHamb > 0)
                {
                    perfilJugador.cantidadHamb--;
                    //cantidadMonedas += 40;
                    CambiarMonedas(perfilJugador.costoHambVenta);
                    CambiarReputacion(perfilJugador.ReputacionGanada);
                    //cantidadReputacion += 3;
                    EstadoComprador = true;
                }
                else
                {
                    //cantidadReputacion--;
                    CambiarReputacion(-perfilJugador.ReputacionPerdida);
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
        var comprador = other.GetComponent<CompradorControlador>();
        if (comprador != null)
        {
            comprador.MostrarResultadoCompra(EstadoComprador);
        }
    }


}
