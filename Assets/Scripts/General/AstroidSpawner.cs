using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidSpawner : MonoBehaviour
{
    [SerializeField] private float stTimerMin, stTimerMax;
    private float timer;

    [SerializeField] private Vector2 minSpawn, maxSpawn;

    [SerializeField]private Astroid astroid;
    private ObjectPool<Astroid> pool;
    // Update is called once per frame
    private void Awake()
    {
        pool = new ObjectPool<Astroid>(astroid, 10, transform);
        pool.AutoExpand = true;
    }
    private void Update()
    {
        CheckTimer();
    }

    private void CheckTimer()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            Astroid newAstroid = pool.GetFreeElement();
            newAstroid.gameObject.SetActive(true);
            newAstroid.transform.position = RandomSpawn();
            newAstroid.transform.rotation = transform.rotation;
            
            float addTime = Random.Range(stTimerMin, stTimerMax);
            timer = addTime;
        }
    }

    private Vector2 RandomSpawn()
    {
        return new Vector2(Random.Range(minSpawn.x, maxSpawn.x), Random.Range(minSpawn.y, maxSpawn.y));
    }
}
