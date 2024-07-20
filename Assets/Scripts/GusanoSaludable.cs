using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GusanoSaludable : MonoBehaviour
{
    public CharacterController character;
    public AudioClip sonidoConsume;
    public GameManager manager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Power-up collided with player.");
            AudioManager.Instance.ReproducirSonido(sonidoConsume);
            collision.gameObject.GetComponent<VidaJugador>().RecuperarVida(1);
            Destroy(gameObject);
        }
    }

}
