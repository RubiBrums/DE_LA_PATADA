using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotenciadorVelocidad : MonoBehaviour
{

    public ScrollingTilemap velocidadCamino1;
    public ScrollingTilemap velocidadArboles1;
    public ScrollingTilemap velocidadArbusto1;
    public ScrollingTilemap velocidadPasto1;
    public ScrollingTilemap velocidadPastoFront1;




    public float newScrollSpeed = -7f;


    public AudioClip sonidoConsume;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            velocidadCamino1.scrollSpeed = newScrollSpeed ++;
            velocidadArboles1.scrollSpeed = newScrollSpeed ++;
            velocidadArbusto1.scrollSpeed = newScrollSpeed ++;
            velocidadPasto1.scrollSpeed = newScrollSpeed ++;
            velocidadPastoFront1.scrollSpeed = newScrollSpeed ++;


            this.GetComponent<SpriteRenderer>().enabled = false;
            this.GetComponent<Collider2D>().enabled = false;
            AudioManager.Instance.ReproducirSonido(sonidoConsume);
            StartCoroutine(PotenciaVelocidad(collision.gameObject.GetComponent<CharacterSwimming>()));
        }
    }

    private IEnumerator PotenciaVelocidad(CharacterSwimming player)
    {
        Debug.Log("PowerUp activado");
        float velocidadOriginal = player.velocidad;
        player.velocidad = 10f;

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
        velocidadCamino1.scrollSpeed = -5;
        velocidadArboles1.scrollSpeed = -3;
        velocidadArbusto1.scrollSpeed = -4;
        velocidadPasto1.scrollSpeed = -2;
        velocidadPastoFront1.scrollSpeed = -4;

        hud.OcultarPowerUp();
        Debug.Log("PowerUp desactivado, velocidad restaurada");
    }
}
