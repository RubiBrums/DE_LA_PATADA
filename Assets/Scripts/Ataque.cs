using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ataque : MonoBehaviour
{
    [SerializeField] private Transform controladorAtaque;
    [SerializeField] private float radioAtaque;
    [SerializeField] private float danoAtaque;

    private Animator animator;
    public AudioClip ataque;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Atacar()
    {
        animator.SetBool("IsAttacking", true);
        Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorAtaque.position, radioAtaque);

        foreach (Collider2D colisionador in objetos)
        {
            if (colisionador.CompareTag("EnemigoRecibeDano"))
            {
                EnemigoFollowPlayer enemigo = colisionador.GetComponentInParent<EnemigoFollowPlayer>();
                if (enemigo != null)
                {
                    enemigo.RecibirDano(danoAtaque);
                }
                else
                {
                    Debug.LogError("El objeto con la etiqueta 'EnemigoRecibeDano' no tiene el componente 'EnemigoFollowPlayer'.");
                }
            }
        }
        StartCoroutine(FinAtaque());
    }

    private IEnumerator FinAtaque()
    {
        yield return new WaitForSeconds(0.1f); // Ajusta este valor según sea necesario
        animator.SetBool("IsAttacking", false);

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controladorAtaque.position, radioAtaque);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AudioManager.Instance.ReproducirSonido(ataque);
            Atacar();
        }
    }
}
