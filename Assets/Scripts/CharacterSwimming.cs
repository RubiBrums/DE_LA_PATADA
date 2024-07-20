using UnityEngine;

public class CharacterSwimming : MonoBehaviour
{
    public float velocidad = 5f;

    private Rigidbody2D rigidBody;
    private BoxCollider2D boxColision;
    private Animator animator;

    public AudioClip sonidoDano;
    public AudioClip sonidoInquieta;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        boxColision = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        movementProcess();
    }

    void movementProcess()
    {
        float inputMovimientoX = Input.GetAxis("Horizontal");
        float inputMovimientoY = Input.GetAxis("Vertical");
        rigidBody.velocity = new Vector2(inputMovimientoX * velocidad, inputMovimientoY * velocidad);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"Jugador detecta colisión con: {collision.name}, Layer: {collision.gameObject.layer}");
    }
}
