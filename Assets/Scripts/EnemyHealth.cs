using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    [SerializeField] private AudioSource explodeSound;
    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] private int scoreForKillingEnemy;
    public override void Die(KilledBy killedBy)
    {
        explodeSound.Play();
        GameObject exp = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(exp, 3f);
        Debug.Log("sadhjfghdsagf" + killedBy.ToString());
        if(killedBy == KilledBy.Player)
        {
            GameManager.Instance.AddScore(scoreForKillingEnemy);
        }
        base.Die(killedBy);
    }
}
