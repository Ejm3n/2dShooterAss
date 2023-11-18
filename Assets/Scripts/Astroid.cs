using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astroid : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField]
    float speed;

    [SerializeField]
    float destroyTimer = 5f;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.AddRelativeForce(new Vector2(0, speed));
        Destroy(gameObject, destroyTimer);
    }
    private void OnEnable()
    {
        transform.parent = null;
    }
}
