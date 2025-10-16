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
    private int Comprar;
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
        ActualizarIcono();
        if (spriteUso != null && spriteSaliendo != null)
        {
            spriteUso.sprite = spriteSaliendo;
        }
    }


    private void ActualizarIcono()
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

    void Update()
    {
        if (spriteUso == null || perfilJugador == null || destino == null)
        {
            Debug.LogError("Faltan referencias en CompradorControlador.");
            return;
        }
        if (tiendaManager != null && tiendaManager.PausaJuego)
        {
            return;
        }

        float distancia = Vector3.Distance(transform.position, destino.position);

      
        if (puedoComprar)
        {
            transform.Translate(direccionDestino * perfilJugador.velocidad * Time.deltaTime);
        }
        else
        {
            
            transform.Translate(direccionOrigen * perfilJugador.velocidad * Time.deltaTime);

            
            if (distancia <= 0.1f) 
            {

                gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (tiendaManager != null && tiendaManager.PausaJuego)
        {
            return;
        }
        if (other.CompareTag("Tienda"))
        {
            Debug.Log("Comprador ha llegado a la tienda");
            puedoComprar = false;

            int delayCompra = Random.Range(2, 4);
            if (spriteUso != null && spriteComprando != null)
            {
                spriteUso.sprite = spriteComprando;
            }
            Invoke("ReiniciarCompra", delayCompra);
        };
    }

    /*public void MostrarResultadoCompra(bool resultado)
    {
        if (resultado)
        {
            iconoRenderer.sprite = iconoFeliz;
        }
        else
        {
            iconoRenderer.sprite = iconoEnojado;
        }
    }*/

    public void MostrarResultadoCompra(bool resultado)
    {
        if (resultado)
        {
            iconoRenderer.sprite = iconoFeliz;
        }
        else
        {
            iconoRenderer.sprite = iconoEnojado;
        }
    }

    private void ResetIcono()
    {
        
        iconoRenderer.sprite = spriteSaliendo;
    }

    public int ObtenerComprar()
    {
        return Comprar;
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


