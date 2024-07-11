using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTargetSC : MonoBehaviour
{
    // El objetivo que la cámara seguirá, generalmente el jugador
    public Transform target;

    // Desplazamiento de la cámara en relación con el objetivo
    public Vector3 offset;

    // Velocidad de seguimiento de la cámara
    public float followSpeed = 2f;

    private void Update()
    {
        // Obtener la entrada del jugador
        Vector3 targetPosition = target.position + offset;
        float movementx = transform.position.x - targetPosition.x;

        // Voltear el jugador dependiendo de la dirección del movimiento
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
            // Nueva posición deseada de la cámara
            Vector3 targetPosition = target.position + offset;
            targetPosition.y = transform.position.y; // Mantener la posición Y fija

            // Interpolación suave entre la posición actual y la deseada
            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
        }
    }
}
