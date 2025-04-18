using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretManager : MonoBehaviour
{
    [SerializeField] private TurretController[] manualTurrets;
    [SerializeField] private TurretController[] autoTurrets;
    [SerializeField] private TurretShooter[] allTurretShooters;

    [SerializeField] private Transform autoTarget; // not-implemented yet

    private void Awake()
    {
        manualTurrets = GetComponentsInChildren<TurretController>(true);
        allTurretShooters = GetComponentsInChildren<TurretShooter>(true);
    }
    public void AimManualTurrets(Vector2 pointerPosition)
    {
        foreach (var turret in manualTurrets)
            turret.AimAt(pointerPosition);
    }

    public void FireAllTurrets()
    {
        foreach (var shooter in allTurretShooters)
            shooter.TryShoot();
    }

    private void Update()
    {
        if (autoTurrets == null || autoTurrets.Length == 0 || autoTarget == null)
            return;

        foreach (var turret in autoTurrets)
        {
            turret.AimAt(autoTarget.position);
        }
    }

}
