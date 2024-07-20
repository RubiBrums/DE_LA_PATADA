using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoFollowPlayer : MonoBehaviour
{
    [SerializeField] Animator animator;
    public float velocidad = 5f;

    private Rigidbody2D rigidBody;
    private BoxCollider2D boxColision;
    private Collider2D colisionadorRecibeDano;

    [SerializeField] private float hp;

    public int hitCount = 0;
    private Animator minion;
    public AudioClip golpe;
    public AudioClip ouch;
    public GameObject detectorDeDaño;

    private bool miraDerecha = true;
    private bool isFollowing = false;

    [SerializeField] Transform player;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        boxColision = GetComponent<BoxCollider2D>();
        //colisionadorRecibeDano = transform.Find("colisionadorRecibeDano").GetComponent<Collider2D>(); // Ajusta esto según sea necesario
        //animator = GetComponent<Animator>();
    }

    void Update()
    {
        movementProcess();
    }

    void movementProcess()
    {
        if (isFollowing == false) return;

        float velocidadMovimiento = player.position.x - transform.position.x < 0 ? -1f : 1f;

        if (velocidadMovimiento != 0f)
        {
            animator.SetBool("IsWalking", true);
            animator.Play("Correr");
        }
        else
        {
            animator.SetBool("IsWalking", false);
            animator.Play("Idle");
        }

        rigidBody.velocity = new Vector2(velocidadMovimiento * velocidad, rigidBody.velocity.y);
        // transform.position += new Vector3(velocidadMovimiento * velocidad, 0,0);
        gestionOrientacion(velocidadMovimiento);
    }

    void gestionOrientacion(float velocidadMovimiento)
    {
        if ((miraDerecha == true && velocidadMovimiento < 0) || (miraDerecha == false && velocidadMovimiento > 0))
        {
            miraDerecha = !miraDerecha;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //AudioManager.Instance.ReproducirSonido();
            animator.SetBool("Alertado", true);
            //float velocidadMovimiento = player.position.x;
            
            Invoke("ActivateFollow", 0.425f);

            //animator.Play("Correr");
        }
    }

    private void ActivateFollow()
    {
        isFollowing = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            animator.SetBool("Alertado", false);
            animator.SetBool("IsWalking", false);
            isFollowing = false;

        }

    }

    public void RecibirDano(float dano)
    {
        hp -= dano;

        if (hp == 3f)
        {
            AudioManager.Instance.ReproducirSonido(golpe);
        }

        if (hp == 2f)
        {
            AudioManager.Instance.ReproducirSonido(golpe);
        }

        if (hp == 1f)
        {
            AudioManager.Instance.ReproducirSonido(golpe);
        }

        if (hp <= 0f)
        {
            Death();
        }
    }

    void Death()
    {
        Destroy(gameObject);
    }
}
