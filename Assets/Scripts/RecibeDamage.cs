using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecibeDamage : MonoBehaviour
{

    public static RecibeDamage Instance { get; private set; }
    public CircleCollider2D recibidorDamage;

    void Start()
    {
        recibidorDamage = GetComponent<CircleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "AtaqueEnemigo")
        {
            //CharacterController CC = collision.GetComponent<CharacterController>();
            //CC.RecibirDamage();

        }

    }

}
