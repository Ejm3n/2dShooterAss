using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health
{
    public override void TakeDamage(int damage = 1, KilledBy attackedBy = KilledBy.Unknown)
    {
        base.TakeDamage(damage);
        GameManager.Instance.UpdateHealthUI((float)CurrentHealth/(float)maxHealth);
    }
    public override void Die(KilledBy killedBy = KilledBy.Unknown)
    {
        GameManager.Instance.GameOver();
    }
}
