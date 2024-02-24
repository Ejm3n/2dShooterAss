using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BazookaPickUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerMove>().ChangeGuns(true);
            //here add sound effect or something
            Destroy(gameObject);
        }
    }
}
