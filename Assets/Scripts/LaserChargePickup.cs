using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserChargePickup : MonoBehaviour
{
    [SerializeField] private int chargeToAdd;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerMove>().AddCharge(chargeToAdd);
            //here add sound effect or something
            Destroy(gameObject);
        }
    }
}
