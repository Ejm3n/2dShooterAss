using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    [SerializeField] private GameObject healthPickUpPrefab, laserChargePrefab;
    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] private int scoreForKillingEnemy;
    [SerializeField] private float currentHeat;//up to 1 then die

    public void HeatEnemy(float heatAmount)
    {
        Debug.Log("Heating, currentheat = " + currentHeat);
        currentHeat+=heatAmount;
        if(currentHeat >= 1 )
        {
            Die(KilledBy.Player);
        }
    }
    public override void Die(KilledBy killedBy)
    {
        GameObject exp = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
       CreateABonusAfterDeath();
        PlayDeathSound();
        Destroy(exp, 3f);
        Debug.Log("sadhjfghdsagf" + killedBy.ToString());
        if(killedBy == KilledBy.Player)
        {
            GameManager.Instance.AddScore(scoreForKillingEnemy);
        }
        base.Die(killedBy);
    }
    void CreateABonusAfterDeath()
    {
        int rand = Random.Range(0,101);
        if(rand > 80)
        {
            Instantiate(healthPickUpPrefab,transform.position,Quaternion.identity);
        } else if (rand < 20)
        {
            Instantiate(laserChargePrefab, transform.position, Quaternion.identity);
        }
    }
    void PlayDeathSound()
    {
        float dist = Vector2.Distance(transform.position, GameManager.Instance.GetPlayerPos());
        if (dist < GameManager.Instance.GetMaxDistanceToPlayer())
        {
            SoundManager.Instance.PlaySound("Explosion", 1f - (dist / GameManager.Instance.GetMaxDistanceToPlayer()));
        }
        
    }
}
