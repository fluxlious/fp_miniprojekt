using UnityEngine;
using UnityEngine.Events;

public class AIDetector : MonoBehaviour
{
    [Header("Detection Settings")]
    [SerializeField] private string playerTag = "Player";
    [SerializeField] private LayerMask obstacleMask;

    public UnityEvent<Transform> OnPlayerEnter;
    public UnityEvent OnPlayerExit;

    private Transform player;
    public Transform Player => player;
    public bool HasLineOfSight => player && !IsBlocked();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(playerTag))
        {
            player = collision.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(playerTag) && collision.transform == player)
        {
            player = null;
            OnPlayerExit?.Invoke();
        }
    }

    private void Update()
    {
        if (player)
        {
            if (HasLineOfSight)
                OnPlayerEnter?.Invoke(player);
            else
                OnPlayerExit?.Invoke();
        }
    }

    private bool IsBlocked()
    {
        Vector2 origin = transform.position;
        Vector2 direction = player.position - transform.position;
        float distance = direction.magnitude;

        RaycastHit2D hit = Physics2D.Raycast(origin, direction.normalized, distance, obstacleMask);
        return hit.collider != null;
    }
}

