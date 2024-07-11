using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHitDamageEnemy : MonoBehaviour
{
    [SerializeField] int dmg;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            collision.transform.GetComponent<EnemyHealth>().Hurt(dmg);
        }
    }
}
