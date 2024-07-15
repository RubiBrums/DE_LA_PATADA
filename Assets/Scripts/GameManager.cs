using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public int PuntosTotales { get; private set; }
    public HUD hud;

    private int vidas = 3;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.Log("Mas de 1 GameManager en la escena");
        }
    }
    public void SumarPuntos(int puntosPorSumar)
    {
        PuntosTotales += puntosPorSumar;
        hud.ActualizarPuntos(PuntosTotales);
    }
    public void PerderVida(int daño)
    {
        vidas -= daño;
        if (vidas <= 0)
        {
            vidas = 0;
            hud.DesactivarVida(vidas);
            // Destroy(gameObject);
            GameOver();
        }
        hud.DesactivarVida(vidas);
    }

    public bool RecuperarVida()
    {
        if (vidas == 3)
        {
            return false;
        }
        hud.ActivarVida(vidas);
        vidas += 1;
        return true;
    }

    public void GameOver()
    {
        GameOverScreen.Instance.Perder();
    }


}
