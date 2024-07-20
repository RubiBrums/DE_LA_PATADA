using UnityEngine;

public class WarningColliderScript : MonoBehaviour
{
    private AudioSource audioSource; 
    public AudioClip ladridoGalgo; 
    public AudioClip ladridoQuiltro; 

    private void Start()
    {
        audioSource = GetComponentInParent<AudioSource>(); 
        if (audioSource == null)
        {
            Debug.LogError("No se encontró el componente AudioSource en el padre.");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"WarningCollider detecta colisión con: {collision.name}");

        if (collision.CompareTag("Player"))
        {
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(ladridoGalgo); 
                audioSource.PlayOneShot(ladridoQuiltro);
            }
            Debug.Log("Colisionador de advertencia detectado, reproduciendo sonido.");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log($"WarningCollider detecta salida de colisión con: {collision.name}");

        if (collision.CompareTag("Player"))
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop(); 
            }
            Debug.Log("Colisionador de advertencia detectado, deteniendo sonido.");
        }
    }
}
