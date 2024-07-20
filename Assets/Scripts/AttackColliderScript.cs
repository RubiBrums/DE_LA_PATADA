using UnityEngine;

public class AttackColliderScript : MonoBehaviour
{
    public int damage = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"AttackCollider detecta colisión con: {collision.name}");

        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<VidaJugador>().RecibirDaño(damage);
            Debug.Log("Colisionador de ataque detectado, aplicando daño.");
        }
    }
}
