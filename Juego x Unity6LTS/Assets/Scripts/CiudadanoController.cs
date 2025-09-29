using UnityEngine;

public class CiudadanoController : MonoBehaviour
{
    [SerializeField]
    private PerfilJugador perfilJugador;
    [SerializeField] private TiendaManager tiendaManager;
    [SerializeField] private Transform destino;

    private Vector3 direccionDestino;
    private Vector3 direccionOrigen;
    private Vector3 puntoInicial;
    private bool Restart;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        puntoInicial = transform.position;
        Restart = true;
        direccionDestino = (destino.position - transform.position).normalized;
        direccionOrigen = (transform.position - destino.position).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        if (tiendaManager != null && tiendaManager.PausaJuego)
            return;

        if (Restart)
        {
            transform.Translate(direccionDestino * perfilJugador.velocidad * Time.deltaTime);
        }
        else
        {
            transform.Translate(direccionOrigen * perfilJugador.velocidad * Time.deltaTime);

            // Verificamos si ya volvió al punto inicial
            if (Vector3.Distance(transform.position, puntoInicial) < 0.1f)
            {
                Restart = true;

                // Volver a orientación original
                Vector3 escala = transform.localScale;
                escala.x = Mathf.Abs(escala.x); // escala positiva para volver a mirar al destino
                transform.localScale = escala;

                
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (tiendaManager != null && tiendaManager.PausaJuego)
        {
            return;
        }
        if (other.CompareTag("Destino1"))
        {
            Restart = false;
            Vector3 escala = transform.localScale;
            escala.x = -Mathf.Abs(escala.x);
            transform.localScale = escala;

            Debug.Log("Colisionó solo con objeto con tag Destino y se volteó");
        }

    }
}
