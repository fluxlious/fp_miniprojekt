using UnityEngine;

public class TurretShooter : MonoBehaviour
{
    [SerializeField] private float fireCooldown = 1f;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform[] shootPoints; // Assign Barrel1, Barrel2, etc.

    private float fireTimer;

    public void TryShoot()
    {
        if (Time.time < fireTimer) return;

        foreach (Transform shootPoint in shootPoints)
        {
            if (!shootPoint.gameObject.activeInHierarchy) continue;

            GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
            bullet.GetComponent<Bullet>().Initialise();
        }

        fireTimer = Time.time + fireCooldown;
    }
}

