using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayerTrigger : MonoBehaviour
{
    [SerializeField] int damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Debug.Log("hurt player",this);
            PlayerHealthSystemHearts phs = collision.transform.GetComponent<PlayerHealthSystemHearts>();
            phs.Hurt(damage);

        }
    }

}