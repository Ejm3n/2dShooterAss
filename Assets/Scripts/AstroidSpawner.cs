using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidSpawner : MonoBehaviour
{
    [SerializeField] private float stTimerMin, stTimerMax;
    private float timer;

    [SerializeField] private Vector2 minSpawn, maxSpawn;

    [SerializeField]private GameObject astroid;
    [SerializeField] private Transform spawnPoint;
    // Update is called once per frame

    private void Update()
    {
        CheckTimer();
    }

    private void CheckTimer()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            Instantiate(astroid, RandomSpawn(), transform.rotation, null);
            float addTime = Random.Range(stTimerMin, stTimerMax);
            timer = addTime;
        }
    }

    private Vector2 RandomSpawn()
    {
        return new Vector2(Random.Range(minSpawn.x, maxSpawn.x), Random.Range(minSpawn.y, maxSpawn.y));
    }
}
