using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NuevoPerfilJugador", menuName = "SO/PerfilJugador")]
public class PerfilJugador : ScriptableObject
{
    /*
    [Header("Test1")]
    [Tooltip("Testeo1")]
    [SerializeField]
    [Range(10, 50)]
    public int test;
    */
    [Header("Monedas y Reputacion")]
    [SerializeField]
    [Range(250, 2000)]
    public int cantidadMonedas;
    [SerializeField]
    [Range(10, 100)]
    public int cantidadReputacion;

    //Comida
    //Panchos
    [Header("Stock de items")]
    [Header("Panchos")]
    [SerializeField]
    [Range(0, 100)]
    public int cantidadPanchos;
    [SerializeField]
    [Range(2, 100)]
    public int costoPanchosCompra;
    [SerializeField]
    [Range(5, 100)]
    private int CostoPanchosVenta => costoPanchosVenta;
    public int costoPanchosVenta;
   //Helados
    [Header("Helados")]
    [SerializeField]
    [Range(0, 100)]
    public int cantidadHelados;
    [SerializeField]
    [Range(3, 100)]
    public int costoHeladosCompra;
    [SerializeField]
    [Range(15, 100)]
    private int CostoHeladosVenta => costoHeladosVenta;
    public int costoHeladosVenta;
    //Hamb
    [Header("Hamburguesa")]
    [SerializeField]
    [Range(0, 100)]
    public int cantidadHamb;
    [SerializeField]
    [Range(5, 100)]
    public int costoHambCompra;
    [SerializeField]
    [Range(40, 100)]
    private int CostoHambVenta => costoHambVenta;
    public int costoHambVenta;

    [Header("Expansiones")]
    [Tooltip("Costes en orden de expansion")]
    public List<int> costosExpansionesMonedas;
    [Tooltip("Costes en orden de expansion")]
    public List<int> costosExpansionesReputacion;

    [Header("Reputacion ganada y perdida")]
    [SerializeField]
    [Range(1, 20)]
    public int ReputacionPerdida;
    [SerializeField]
    [Range(1, 20)]
    public int ReputacionGanada;
    [Header("Velocidad Comprador")]
    [SerializeField]
    [Range(5, 50)]
    public int velocidad;

}