using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTargetSC : MonoBehaviour
{
    // El objetivo que la c�mara seguir�, generalmente el jugador
    public Transform target;

    // Desplazamiento de la c�mara en relaci�n con el objetivo
    public Vector3 offset;

    // Velocidad de seguimiento de la c�mara
    public float followSpeed = 2f;

    private void Update()
    {
        // Obtener la entrada del jugador
        Vector3 targetPosition = target.position + offset;
        float movementx = transform.position.x - targetPosition.x;

        // Voltear el jugador dependiendo de la direcci�n del movimiento
        if (movementx > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1); // Moverse a la derecha
        }
        else if (movementx < 0)
        {
            transform.localScale = new Vector3(1, 1, 1); // Moverse a la izquierda
        }
    }

    void LateUpdate()
    {
        if (target != null)
        {
            // Nueva posici�n deseada de la c�mara
            Vector3 targetPosition = target.position + offset;
            targetPosition.y = transform.position.y; // Mantener la posici�n Y fija

            // Interpolaci�n suave entre la posici�n actual y la deseada
            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
        }
    }
}
