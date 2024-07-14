using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GusanoEscurridizo : MonoBehaviour
{
    public AudioClip sonidoConsume;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            this.GetComponent<SpriteRenderer>().enabled = false;
            this.GetComponent<Collider2D>().enabled = false;
            AudioManager.Instance.ReproducirSonido(sonidoConsume);
            StartCoroutine(PotenciaVelocidad(collision.gameObject.GetComponent<CharacterController>()));
        }
    }

    private IEnumerator PotenciaVelocidad(CharacterController player)
    {
        Debug.Log("PowerUp activado");
        float velocidadOriginal = player.velocidad;
        player.velocidad = 15f;

        HUD hud = FindObjectOfType<HUD>();
        hud.MostrarPowerUp();

        float tiempoRestante = 5f;
        while (tiempoRestante > 0)
        {
            hud.ActualizarTiempoPowerUp(tiempoRestante);
            Debug.Log("Tiempo restante: " + tiempoRestante);
            yield return new WaitForSeconds(1f);
            tiempoRestante -= 1f;
        }

        player.velocidad = velocidadOriginal;
        hud.OcultarPowerUp();
        Debug.Log("PowerUp desactivado, velocidad restaurada");
    }
}
