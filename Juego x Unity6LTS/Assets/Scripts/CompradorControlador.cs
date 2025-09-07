using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Comprador : MonoBehaviour
{
    [SerializeField] private Transform destino;
    [SerializeField]
    [Range(5, 100)]
    private int velocidad;

    private Vector3 direccionDestino;
    private Vector3 direccionOrigen;

    private bool puedoComprar;

    void Start()
    {
        direccionDestino = (destino.position - transform.position).normalized;
        direccionOrigen = (transform.position - destino.position).normalized;
        puedoComprar = true;
    }

    void Update()
    {
        if (puedoComprar)
        {
            transform.Translate(direccionDestino * velocidad * Time.deltaTime);
        }
        else
        {
            transform.Translate(direccionOrigen * velocidad * Time.deltaTime);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        puedoComprar = false;
        int delayCompra = Random.Range(4, 10);
        Invoke("ReiniciarCompra", delayCompra);
    }

    private void ReiniciarCompra()
    {
        puedoComprar = true;
    }
}