using UnityEngine;

public class Cazador : MonoBehaviour
{

    public GameObject bala;
    public Transform posicionBala;

    private float timer;
    private GameObject player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {

        float distancia = Vector2.Distance(transform.position, player.transform.position);


        if (distancia < 15)
        {
            timer += Time.deltaTime;

            if (timer > 2)
            {
                timer = 0;
                Disparar();
            }

        }

    }

    void Disparar()
    {
        Instantiate(bala, posicionBala.position, Quaternion.identity);
    }
}
