using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform jugador;
    public Vector3 offset;
    public float smoothSpeed = 0.125f;

    void LateUpdate()
    {
        if (jugador != null)
        {
            Vector3 desiredPosition = jugador.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}
