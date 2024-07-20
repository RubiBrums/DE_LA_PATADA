using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuntajeJugador : MonoBehaviour
{
    public int puntaje;

    public void AgregarPuntos(int puntos)
    {
        puntaje += puntos;
        GameManager.Instance.SumarPuntos(puntos); // Notifica al GameManager
    }
}