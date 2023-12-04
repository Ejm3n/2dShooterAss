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
            gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.CompareTag("Bullet"))
        {
            GameObject exp = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(exp,3f);
            gameObject.SetActive(false);
        }
    }
}
