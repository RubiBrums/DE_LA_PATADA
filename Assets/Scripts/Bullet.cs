using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float lifeTime = 2f;
    public int daño;


    private void Update()
    {
        transform.Translate(Vector2.right * speed * Vector2.right);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Manejar colisiones de la bala aquí
        if (other.TryGetComponent(out GameManager vidas))
        {
            vidas.PerderVida(daño);
            Destroy(gameObject);
        }
    }
}
