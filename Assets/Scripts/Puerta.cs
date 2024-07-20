using UnityEngine;

public class Puerta : MonoBehaviour
{
    public Animator puertaAnimator; // Referencia al Animator de la puerta
    public AudioClip puertaAbriendo;
    public AudioClip puertaCerrando;
    public void AbrirPuerta()
    {
        AudioManager.Instance.ReproducirSonido(puertaAbriendo);
        puertaAnimator.SetBool("Abriendose", true); // Activa la animación de abrir la puerta
    }

    public void CerrarPuerta()
    {
        AudioManager.Instance.ReproducirSonido(puertaCerrando);
        puertaAnimator.SetBool("Abriendose", false); // Activa la animación de cerrar la puerta
    }
}
