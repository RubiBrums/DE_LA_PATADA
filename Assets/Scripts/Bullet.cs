using UnityEngine;

public class Bullet : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    public float fuerza;
    private float timer;

    public int damage;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        Vector3 direccion = player.transform.position - transform.position;
        rb.velocity = new Vector2(direccion.x, direccion.y).normalized * fuerza;

        float rotacion = Mathf.Atan2(-direccion.y, -direccion.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotacion + 90);
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 5)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<VidaJugador>().RecibirDaño(damage);
            Destroy(gameObject);
        }
    }

}
