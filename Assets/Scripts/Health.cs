using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int CurrentHealth;
    [SerializeField] protected int maxHealth =1;

    private void Start()
    {
        CurrentHealth = maxHealth;
    }

    public virtual void TakeDamage(int damage = 1)
    {
        CurrentHealth-=damage;
        if (CheckIfDead())
            Die();
    }

    public bool CheckIfDead() { return CurrentHealth <= 0; }

    public virtual void Die()
    {
        gameObject.SetActive(false);        
    }


}
