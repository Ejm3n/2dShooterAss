using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health
{
    [SerializeField] private AudioSource hitSound;
    public override void TakeDamage(int damage = 1, KilledBy attackedBy = KilledBy.Unknown)
    {
        hitSound.Play();
        base.TakeDamage(damage);
        GameManager.Instance.UpdateHealthUI((float)CurrentHealth/(float)maxHealth);
    }
    public override void Die(KilledBy killedBy = KilledBy.Unknown)
    {
        GameManager.Instance.GameOver();
    }
}
