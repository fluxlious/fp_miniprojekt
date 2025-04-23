using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    private Rigidbody2D rb;
    private float maxDistance = 10f;
    private Vector2 startPosition;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Initialise()
    {
        startPosition = transform.position;
        rb.velocity = transform.up * speed;

        Debug.DrawRay(transform.position, transform.up * 1f, Color.red, 1f); 
    }

    private void Update()
    {
        float traveledDistance = Vector2.Distance(startPosition, transform.position);
        if (traveledDistance >= maxDistance)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Hit something: " + collision.tag);
        if (collision.CompareTag("Enemy") || collision.CompareTag("Obstacles")) 
        {
            Destroy(gameObject);
        }
    }
}

