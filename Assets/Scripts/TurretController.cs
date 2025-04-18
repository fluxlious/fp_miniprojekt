using UnityEngine;

public class TurretController : MonoBehaviour
{
    [SerializeField] public float turretLerpSpeed = 5f; // Higher = snappier, Lower = heavier

    public void AimAt(Vector2 pointerPosition)
    {
        Vector2 direction = pointerPosition - (Vector2)transform.position;
        float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        Quaternion targetRotation = Quaternion.Euler(0f, 0f, targetAngle);

        // Inertia-like smoothing using Slerp
        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            targetRotation,
            turretLerpSpeed * Time.deltaTime
        );
    }

}