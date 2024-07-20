using System.Collections;
using UnityEngine;

public class Boton : MonoBehaviour
{
    public Puerta puerta; // Referencia al script de la puerta
    public Animator botonAnimator; // Referencia al Animator del botón
    public float tiempoPresionado = 4f; // Tiempo que el botón permanece presionado
    public AudioClip botonPresionado;

    private bool isPressed = false; // Estado del botón

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isPressed)
        {
            isPressed = true;
            AudioManager.Instance.ReproducirSonido(botonPresionado);
            StartCoroutine(ActivarYDesactivar());
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            botonAnimator.SetBool("Presionado", false); // Restablece la animación a la inicial
            isPressed = false; // Permite que el botón pueda ser presionado de nuevo
        }
    }

    private IEnumerator ActivarYDesactivar()
    {
        botonAnimator.SetBool("Presionado", true); // Activa la animación de presionado
        puerta.AbrirPuerta(); // Llama al método para abrir la puerta

        yield return new WaitForSeconds(tiempoPresionado); // Espera el tiempo especificado

        botonAnimator.SetBool("Presionado", false); // Restablece la animación a la inicial
        puerta.CerrarPuerta(); // Llama al método para cerrar la puerta
        isPressed = false; // Permite que el botón pueda ser presionado de nuevo
    }
}
