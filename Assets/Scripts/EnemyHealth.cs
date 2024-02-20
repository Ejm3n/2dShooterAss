using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] private int scoreForKillingEnemy;
    public override void Die(KilledBy killedBy)
    {
        GameObject exp = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        //float dist = Vector2.Distance(transform.position, GameManager.Instance.GetPlayerPos());
        //if (dist<GameManager.Instance.GetMaxDistanceToPlayer())
        //{
        //    exp.GetComponent<AudioSource>().volume = 1f - (dist / GameManager.Instance.GetMaxDistanceToPlayer());
        //}
        //else
        //{
        //    exp.GetComponent<AudioSource>().volume = 0;
        //}
        SoundManager.Instance.PlaySound("Explosion");
        Destroy(exp, 3f);
        Debug.Log("sadhjfghdsagf" + killedBy.ToString());
        if(killedBy == KilledBy.Player)
        {
            GameManager.Instance.AddScore(scoreForKillingEnemy);
        }
        base.Die(killedBy);
    }
}
