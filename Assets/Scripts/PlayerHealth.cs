using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health
{
    [SerializeField] private AudioSource hitSound;
    public override void TakeDamage(int damage = 1, KilledBy attackedBy = KilledBy.Unknown)
    {
        MainController.Instance.SoundManager.PlaySound("Hit");
        base.TakeDamage(damage);
        MainController.Instance.UIManager.UpdateHealthUI((float)CurrentHealth/(float)maxHealth);
    }
    public override void AddHealth(int healthToAdd)
    {
        base.AddHealth(healthToAdd);
        MainController.Instance.UIManager.UpdateHealthUI((float)CurrentHealth/(float)maxHealth);
    }
    public override void Die(KilledBy killedBy = KilledBy.Unknown)
    {
        GameManager.Instance.GameOver();
    }
}
