using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int CurrentHealth;
    public KilledBy KilledBy = KilledBy.Unknown;
    [SerializeField] protected int maxHealth =1;


    private void Start()
    {
        CurrentHealth = maxHealth;
    }

    public virtual void TakeDamage(int damage = 1, KilledBy attackedBy = KilledBy.Unknown)
    {
        CurrentHealth-=damage;
        if (CheckIfDead())
            Die(attackedBy);
    }

    public bool CheckIfDead() { return CurrentHealth <= 0; }

    public virtual void Die(KilledBy killedBy)
    {
        KilledBy = killedBy;
        gameObject.SetActive(false);        
    }


}

public enum KilledBy
{
    Unknown,
Player,
Asteroid,
Enemy
}
