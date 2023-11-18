using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rb;
    
    [SerializeField]
    float speed;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();


        rb.AddRelativeForce(new Vector2(0, speed));
        Destroy(gameObject,5f);
    }
}
