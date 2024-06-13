using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{

    public GameObject manchaAceite;

    public float velocidad = 5f;
    public float fuerzaSalto = 15f;

    private Rigidbody2D rigidBody;
    private BoxCollider2D boxColision;
    public LayerMask capaPiso;

    public AudioClip sonidoSalto;
    public AudioClip sonidoDano;
    public AudioClip sonidoInquieta;


    /*private Animator animator;*/

    private bool miraDerecha = true;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        boxColision = GetComponent<BoxCollider2D>();
        /*animator = GetComponent<Animator>();*/
    }
    void Update()
    {
        movementProcess();
        jumpProcess();
    }

    private void FixedUpdate()
    {
        /*animator.SetBool("InGround", EstaEnPiso());*/

    }

    bool EstaEnPiso()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxColision.bounds.center, new Vector2(boxColision.bounds.size.x, boxColision.bounds.size.y), 0f, Vector2.down, 0.5f, capaPiso);
        return raycastHit.collider != null;
    }

    void jumpProcess()
    {
        if (Input.GetKeyDown(KeyCode.W) && EstaEnPiso())
        {
            /*animator.Play("Jump");*/
            AudioManager.Instance.ReproducirSonido(sonidoSalto);
            rigidBody.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
        }

    }

    void movementProcess()
    {
        float inputMovimiento = Input.GetAxis("Horizontal");

        if (inputMovimiento != 0f)
        {
            /*animator.SetBool("IsWalking", true);*/
        }
        else
        {
            /*animator.SetBool("IsWalking", false);*/
        }

        rigidBody.velocity = new Vector2(inputMovimiento * velocidad, rigidBody.velocity.y);

        gestionOrientacion(inputMovimiento);
    }

    void gestionOrientacion(float inputMovimiento)
    {
        if ((miraDerecha == true && inputMovimiento < 0) || (miraDerecha == false && inputMovimiento > 0))
        {
            miraDerecha = !miraDerecha;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Barro")
        {
            AudioManager.Instance.ReproducirSonido(sonidoInquieta);
            velocidad = 5.5f;
            /*animator.Play("Slip");*/
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Barro")
        {
            velocidad = 10f;
            /*animator.Play("Idle");*/
        }
    }

}
