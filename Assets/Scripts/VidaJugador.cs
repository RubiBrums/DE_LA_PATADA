using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaJugador : MonoBehaviour
{
    public int vidaMaxima;
    public int vida;
    private GameManager manager;

    private void Start()
    {
        manager = GameManager.Instance;
        vidaMaxima = vida;
    }

    private void Update()
    {
        if (vida <= 0)
        {
            manager.GameOver();
        }
    }

    public void RecibirDaño(int daño)
    {
        vida -= daño;
        if (vida < 0) vida = 0;
        manager.ActualizarHUD();
    }

    public void RecuperarVida(int cantidad)
    {
        vida += cantidad;
        if (vida > vidaMaxima) vida = vidaMaxima;
        manager.ActualizarHUD();
    }
}
