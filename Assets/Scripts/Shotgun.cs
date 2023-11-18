using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField]
    float force;

    public GameObject bullet, shootPoint;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            shoot();
            rb.AddRelativeForce(new Vector2(0, -force));
        }
    }

    void shoot()
    {
        Instantiate(bullet, shootPoint.transform);
    }
}
