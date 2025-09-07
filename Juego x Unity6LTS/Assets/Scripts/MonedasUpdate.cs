using UnityEngine;
using TMPro;

public class MonedasUpdater : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textoMonedas;

    private void OnEnable()
    {
        TiendaManager.OnMonedasCambiadas += ActualizarMonedas;
    }

    private void OnDisable()
    {
        TiendaManager.OnMonedasCambiadas -= ActualizarMonedas;
    }

    private void ActualizarMonedas(int nuevaCantidad)
    {
        textoMonedas.text = nuevaCantidad.ToString();
    }
}