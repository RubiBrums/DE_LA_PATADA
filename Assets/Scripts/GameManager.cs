using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public int PuntosTotales { get; private set; }
    public HUD hud;
    public VidaJugador vidaJugador;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Time.timeScale = 1f; // Asegúrate de que el tiempo esté en 1f al inicio de la escena

        if (vidaJugador == null)
        {
            vidaJugador = FindObjectOfType<VidaJugador>();
        }

        if (hud == null)
        {
            hud = FindObjectOfType<HUD>();
        }
    }

    public void SumarPuntos(int puntosPorSumar)
    {
        PuntosTotales += puntosPorSumar;
        hud.ActualizarPuntos(PuntosTotales);
    }

    public void ActualizarHUD()
    {
        for (int i = 0; i < vidaJugador.vidaMaxima; i++)
        {
            if (i < vidaJugador.vida)
            {
                hud.ActivarVida(i);
            }
            else
            {
                hud.DesactivarVida(i);
            }
        }
    }

    public void GameOver()
    {
        if (GameOverScreen.Instance != null)
        {
            GameOverScreen.Instance.Perder();
        }
        else
        {
            Debug.LogError("GameOverScreen.Instance is null. Make sure GameOverScreen is properly initialized.");
        }
    }
}
