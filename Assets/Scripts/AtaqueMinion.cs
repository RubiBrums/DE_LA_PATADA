using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueMinion : MonoBehaviour
{
    public BoxCollider2D colisionAtaque;
    public static AtaqueMinion Instance { get; private set; }
    public CharacterController character;

    public GameManager manager;


    void Start()
    {
        colisionAtaque = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "RecibeDano")
        {
            manager.PerderVida();

        }

    }
}
