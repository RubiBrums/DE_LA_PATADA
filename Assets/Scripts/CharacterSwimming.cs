using System.Collections;
using System.Collections.Generic;
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

        // Asigna ambas componentes de velocidad en una sola operación
        rigidBody.velocity = new Vector2(inputMovimientoX * velocidad, inputMovimientoY * velocidad);
    }
}
