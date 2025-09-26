using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class CompradorControlador : MonoBehaviour
{

    [SerializeField]
    private PerfilJugador perfilJugador;

    [SerializeField] private Sprite spriteComprando;
    [SerializeField] private Sprite spriteSaliendo;

    [SerializeField] private TiendaManager tiendaManager;
    [SerializeField] private Transform destino;
    [SerializeField] private Sprite iconoPancho;
    [SerializeField] private Sprite iconoHelado;
    [SerializeField] private Sprite iconoHamb;
    [SerializeField] private Sprite iconoEnojado;
    [SerializeField] private Sprite iconoFeliz;
    [SerializeField] private SpriteRenderer iconoRenderer;
    /*[SerializeField]
    [Range(5, 100)]

    private int velocidad;
    */
    private int Seleccion;
    private SpriteRenderer spriteUso;
    int Comprar;
    private Vector3 direccionDestino;
    private Vector3 direccionOrigen;

    private bool puedoComprar;

    void Start()
    {

        spriteUso = GetComponent<SpriteRenderer>();
        direccionDestino = (destino.position - transform.position).normalized;
        direccionOrigen = (transform.position - destino.position).normalized;
        puedoComprar = true;
        Comprar = Random.Range(1, 4);
        if (spriteUso != null && spriteSaliendo != null)
        {
            spriteUso.sprite = spriteSaliendo;
        }
    }

    void Update()
    {
        if (tiendaManager != null && tiendaManager.PausaJuego)
        {

            return;
        }
        if (puedoComprar)
        {
            transform.Translate(direccionDestino * perfilJugador.velocidad * Time.deltaTime);
        }
        else
        {
            transform.Translate(direccionOrigen * perfilJugador.velocidad * Time.deltaTime);
        }

    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (tiendaManager != null && tiendaManager.PausaJuego)
        {
            return;
        }
        puedoComprar = false;
        int delayCompra = Random.Range(2, 4);
        if (spriteUso != null && spriteComprando != null)
        {
            spriteUso.sprite = spriteComprando;
        }
        /*
        if (tiendaManager != null && tiendaManager.EstadoComprador)
        {
            iconoRenderer.sprite = iconoEnojado;
        }
        else
        {
            iconoRenderer.sprite = iconoFeliz;
        }
        */

            Invoke("ReiniciarCompra", delayCompra);
    }

    private void ReiniciarCompra()
    {
        if (tiendaManager != null && tiendaManager.PausaJuego)
        {
            return;
        }
        Comprar = Random.Range(1, 4);
        if (tiendaManager != null)
        {
            tiendaManager.RecibirCompra(Comprar);
        }

        if (iconoRenderer != null)
        {
            switch (Comprar)
            {
                case 1:
                    iconoRenderer.sprite = iconoPancho;
                    break;
                case 2:
                    iconoRenderer.sprite = iconoHelado;
                    break;
                case 3:
                    iconoRenderer.sprite = iconoHamb;
                    break;
            }
        }

        if (spriteUso != null && spriteSaliendo != null)
        {
            spriteUso.sprite = spriteSaliendo;
        }

        puedoComprar = true;
    }


}