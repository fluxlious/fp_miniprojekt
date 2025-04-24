using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damageable : MonoBehaviour
{
    [SerializeField]
    private int health;
    public int maxHealth = 100;

    public int Health { get { return health; } 
        set => health = value; }

    // Start is called before the first frame update

    public UnityEvent OnDead,OnHit,OnHeal;

    public UnityEvent<float> OnHealthChange;

    private void Start()
    {
        health = maxHealth;
    }
    internal void TakeDamage(int damagePoints)
    {
        Health -= damagePoints;
        if(Health <= 0)
        {
            OnDead.Invoke();
        }
        else
        {
            OnHit.Invoke();
        }
    }
    internal void Heal(int healthPoints)
    {
        Health += healthPoints;
        OnHeal.Invoke();
    }


}
