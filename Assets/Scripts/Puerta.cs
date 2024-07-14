using UnityEngine;

public class Puerta : MonoBehaviour
{
    public Animator puertaAnimator; // Referencia al Animator de la puerta

    public void AbrirPuerta()
    {
        puertaAnimator.SetBool("Abriendose", true); // Activa la animación de abrir la puerta
    }

    public void CerrarPuerta()
    {
        puertaAnimator.SetBool("Abriendose", false); // Activa la animación de cerrar la puerta
    }
}
