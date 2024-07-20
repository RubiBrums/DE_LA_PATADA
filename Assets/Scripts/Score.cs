using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int valor = 1;
    public AudioClip sonidoScore;
    private bool recogido = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !recogido)
        {
            recogido = true; // Asegurarse de que solo se recoja una vez
            AudioManager.Instance.ReproducirSonido(sonidoScore);
            collision.GetComponent<PuntajeJugador>().AgregarPuntos(valor);
            DesactivarObjeto();
        }
    }

    private void DesactivarObjeto()
    {
        // Desactivar el colisionador y el renderer para evitar colisiones adicionales
        GetComponent<Collider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;

        // Destruir el objeto después de un pequeño retraso para asegurarse de que los cambios se apliquen
        Destroy(gameObject, 0.1f);
    }
}
