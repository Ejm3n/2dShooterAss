using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    protected Rigidbody2D rb;
    
    [SerializeField]
    protected float speed;

    [SerializeField]
    protected float destroyTimer = 5f;

    protected void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    protected void Update()
    {
        transform.Translate(Vector2.up*speed*Time.deltaTime);
    }

    protected void OnEnable()
    {
        transform.parent = null;
        StartCoroutine(TimeToDisable());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.CompareTag("Enemy"))
        {
            gameObject.SetActive(false);
            collision.gameObject.SetActive(false);
        }
    }

    protected IEnumerator TimeToDisable()
    {       
        yield return new WaitForSeconds(destroyTimer);
        gameObject.SetActive(false);
    }
   
}
