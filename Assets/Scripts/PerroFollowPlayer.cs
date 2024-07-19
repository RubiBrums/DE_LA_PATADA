using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerroFollowPlayer : MonoBehaviour
{
    public BoxCollider2D colisionAtaque;
    public static AtaqueMinion Instance { get; private set; }
    public CharacterSwimming character;

    public GameManager manager;
    public int damage;

    public Transform player; // Referencia al transform del jugador
    public float speed = 2f; // Velocidad de movimiento del fantasma
    public float followDistance = 5f; // Distancia a la que el fantasma empieza a seguir al jugador

    private Animator animator; // Referencia al componente Animator

    private void Start()
    {
        animator = GetComponent<Animator>(); // Obtener el componente Animator del fantasma
    }

    private void Update()
    {
        // Verifica si el jugador está dentro de la distancia de seguimiento
        if (Vector2.Distance(transform.position, player.position) <= followDistance)
        {
            // Calcular la dirección hacia la que debe moverse el fantasma
            Vector2 direction = (player.position - transform.position).normalized;

            // Mueve al fantasma hacia la posición del jugador
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

            // Limitar la rotación a dos direcciones (izquierda y derecha)
            // float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            // transform.rotation = Quaternion.Euler(0, 0, angle);

            // Activar la animación de correr si la velocidad no es cero
            animator.SetFloat("Speed", speed);
        }
        else
        {
            // Si el jugador está fuera de la distancia, detener la animación de correr
            animator.SetFloat("Speed", 0f);
        }
    }

    private void OnDrawGizmos()
    {
        // Dibuja un círculo rojo alrededor del fantasma con el radio de followDistance
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, followDistance);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<VidaJugador>().RecibirDaño(damage);

        }

    }
}
