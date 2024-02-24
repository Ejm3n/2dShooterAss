using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Explotion : MonoBehaviour
{
    private void OnEnable()
    {
        Destroy(gameObject, 1);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") )
        {
            try
            {
                collision.gameObject.GetComponent<EnemyHealth>().Die(KilledBy.Player);
            }

            catch
            {
                Debug.Log("NO HEALTH COMP ON " + collision.name);
                collision.gameObject.SetActive(false);
            }
            
        }
        if( collision.CompareTag("Asteroid"))
        {
            collision.gameObject.SetActive(false);
        }

    }
}
