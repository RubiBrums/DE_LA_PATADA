using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acido : MonoBehaviour
{
    public CharacterController character;
    public GameManager manager;
    public int damage;

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<VidaJugador>().RecibirDaño(damage);
        }
    }
}
