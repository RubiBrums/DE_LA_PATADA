using UnityEngine;

public class Cazador : MonoBehaviour
{
    public Transform puntoDisparo;

    public float distanciaLinea;
    public LayerMask capaJugador;
    public bool jugadorEnRango;

    public float tiempoUltimoDisparo;
    public float tiempoEntreDisparos;
    public float tiempoEsperaDisparo;

    public GameObject balaCazador;

    private void Update()
    {
        jugadorEnRango = Physics2D.Raycast(puntoDisparo.position, transform.right, distanciaLinea, capaJugador);
        if (jugadorEnRango)
        {
            if (Time.deltaTime > tiempoEntreDisparos + tiempoUltimoDisparo)
            {
                tiempoUltimoDisparo = Time.deltaTime;
                Invoke(nameof(Disparar), tiempoEsperaDisparo);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(puntoDisparo.position, puntoDisparo.position + transform.right * distanciaLinea);

    }

    void Disparar()
    {
        Instantiate(balaCazador, puntoDisparo.position, puntoDisparo.rotation);
    }
}
