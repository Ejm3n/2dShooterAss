using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    [SerializeField] private int healthToAdd;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player"))
        {
            other.GetComponent<PlayerHealth>().AddHealth(healthToAdd);
            //here add sound effect or something
            Destroy(gameObject);
        }
    }
}
