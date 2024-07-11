using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    [SerializeField] int damage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            PlayerHealthSystemHearts phs = collision.transform.GetComponent<PlayerHealthSystemHearts>();
            phs.Hurt(damage);
            
        }
    }
}
