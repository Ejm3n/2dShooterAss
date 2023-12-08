using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    [SerializeField] private GameObject explosionPrefab;
    public override void Die()
    {
        GameObject exp = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(exp, 3f);
        base.Die();
    }
}
