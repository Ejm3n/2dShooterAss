using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;

    Rigidbody2D rb;

    GameObject player;
    private void Start()
    {
        player = gameObject;
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(Input.GetAxis("Vertical") != 0)
        {
            rb.AddRelativeForce(new Vector2(0, Input.GetAxisRaw("Vertical") * moveSpeed));
        }
        if (Input.GetAxis("Horizontal") != 0)
        {
            rb.AddTorque(-Input.GetAxisRaw("Horizontal"));
        }
    }
}
