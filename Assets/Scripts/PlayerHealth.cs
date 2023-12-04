using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health
{
    public override void TakeDamage(int damage = 1)
    {
        base.TakeDamage(damage);
        GameManager.Instance.UpdateHealthUI();
    }
    public override void Die()
    {
        GameManager.Instance.GameOver();
    }
}
