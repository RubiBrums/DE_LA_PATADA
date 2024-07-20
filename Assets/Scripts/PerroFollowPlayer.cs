using UnityEngine;

public class PerroFollowPlayer : MonoBehaviour
{
    public Transform player; 
    public float speed = 2f;
    public float followDistance = 5f; 

    private Animator animator; 

    private void Start()
    {
        animator = GetComponent<Animator>(); 
    }

    private void Update()
    {
        
        if (Vector2.Distance(transform.position, player.position) <= followDistance)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            animator.SetFloat("Speed", speed);
        }
        else
        {
            animator.SetFloat("Speed", 0f);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, followDistance);
    }
}
