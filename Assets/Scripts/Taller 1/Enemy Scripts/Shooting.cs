using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform target; // El objetivo al que disparar
    public GameObject projectilePrefab; // Prefab del proyectil
    public Transform firePoint; // Punto desde donde se disparará el proyectil
    public float fireRate = 2f; // Intervalo de tiempo entre disparos
    public float projectileSpeed = 10f; // Velocidad del proyectil

    private float nextFireTime = 0f;

    void Update()
    {
        if (target != null)
        {
            AimAtTarget();

            if (Time.time >= nextFireTime)
            {
                Shoot();
                nextFireTime = Time.time + 1f / fireRate;
            }
        }
    }

    void AimAtTarget()
    {
        Vector2 direction = (target.position - firePoint.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        firePoint.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = firePoint.right * projectileSpeed;
        }
    }
}
