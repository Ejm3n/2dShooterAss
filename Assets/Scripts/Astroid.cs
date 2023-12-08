using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astroid : Bullet
{
    [SerializeField] private GameObject explosionPrefab;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(1);
            GameObject exp = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(exp, 3f);
            gameObject.SetActive(false);
            
        }
        if (collision.transform.CompareTag("Enemy"))
        {
           try
            {
                collision.gameObject.GetComponent<Health>().Die(KilledBy.Asteroid);
            }
            catch
            {
                Debug.Log("No enemy health");
            }

        }
    }
    
}
