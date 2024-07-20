using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acido : MonoBehaviour
{
    public CharacterController character;
    public int damage;
    public AudioClip acido;
    public GameManager manager;

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            AudioManager.Instance.ReproducirSonido(acido);

            collision.gameObject.GetComponent<VidaJugador>().RecibirDaño(damage);
        }
    }
}
