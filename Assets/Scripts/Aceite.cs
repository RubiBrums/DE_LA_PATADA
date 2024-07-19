using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aceite : MonoBehaviour
{

    public ScrollingTilemap velocidadCamino1;
    public ScrollingTilemap velocidadArboles1;
    public ScrollingTilemap velocidadArbusto1;
    public ScrollingTilemap velocidadPasto1;
    public ScrollingTilemap velocidadPastoFront1;




    public float newScrollSpeed = -3f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            velocidadCamino1.scrollSpeed = newScrollSpeed++;
            velocidadArboles1.scrollSpeed = newScrollSpeed++;
            velocidadArbusto1.scrollSpeed = newScrollSpeed++;
            velocidadPasto1.scrollSpeed = newScrollSpeed++;
            velocidadPastoFront1.scrollSpeed = newScrollSpeed++;


            this.GetComponent<SpriteRenderer>().enabled = false;
            this.GetComponent<Collider2D>().enabled = false;
            StartCoroutine(RalentizarJugador(collision.gameObject.GetComponent<CharacterSwimming>()));
        }
    }

    private IEnumerator RalentizarJugador(CharacterSwimming player)
    {
        Debug.Log("Entró en aceite");
        float velocidadOriginal = player.velocidad;
        player.velocidad = 2.5f;

        float tiempoRestante = 5f;
        while (tiempoRestante > 0)
        {
            yield return new WaitForSeconds(1f);
            tiempoRestante -= 1f;
        }

        player.velocidad = velocidadOriginal;
        velocidadCamino1.scrollSpeed = -5;
        velocidadArboles1.scrollSpeed = -3;
        velocidadArbusto1.scrollSpeed = -4;
        velocidadPasto1.scrollSpeed = -2;
        velocidadPastoFront1.scrollSpeed = -4;

        Debug.Log("Se quitó el aceite, velocidad restaurada");
    }
}
