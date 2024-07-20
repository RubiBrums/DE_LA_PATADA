using System.Collections;
using UnityEngine;

public class VidaJugador : MonoBehaviour
{
    public int vidaMaxima;
    public int vida;
    private GameManager manager;
    private bool esInvulnerable = false;
    public float tiempoInvulnerable = 2f; // Tiempo de invulnerabilidad en segundos

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
        if (!esInvulnerable)
        {
            vida -= daño;
            if (vida < 0) vida = 0;
            manager.ActualizarHUD();
            StartCoroutine(Invulnerabilidad());
        }
    }

    public void RecuperarVida(int cantidad)
    {
        vida += cantidad;
        if (vida > vidaMaxima) vida = vidaMaxima;
        manager.ActualizarHUD();
    }

    private IEnumerator Invulnerabilidad()
    {
        esInvulnerable = true;
        yield return new WaitForSeconds(tiempoInvulnerable);
        esInvulnerable = false;
    }
}