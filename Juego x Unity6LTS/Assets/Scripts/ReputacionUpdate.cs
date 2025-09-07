using UnityEngine;
using TMPro;

public class UIReputacionUpdater : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textoReputacion;

    private void OnEnable()
    {
        TiendaManager.OnReputacionCambiada += ActualizarReputacion;
    }

    private void OnDisable()
    {
        TiendaManager.OnReputacionCambiada -= ActualizarReputacion;
    }

    private void ActualizarReputacion(int nuevaReputacion)
    {
        textoReputacion.text = nuevaReputacion + "/100";
    }
}