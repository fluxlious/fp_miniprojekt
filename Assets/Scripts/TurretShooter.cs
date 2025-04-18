using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TurretShooter : MonoBehaviour
{
    [SerializeField] private string turretName = "Turret"; // Optional for identification
    [SerializeField] private float fireCooldown = 1f;

    private float fireTimer;

    public void TryShoot()
    {
        if (Time.time < fireTimer) return;

        fireTimer = Time.time + fireCooldown;
        Debug.Log($"{turretName} fired at {Time.time}");
    }
}
