using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public KilledBy Attacker;
    protected Rigidbody2D rb;
    
    [SerializeField]
    protected float speed;

    [SerializeField]
    protected float destroyTimer = 5f;

    [SerializeField]
    protected int damage = 1;


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
        if(collision.transform.CompareTag("Enemy") || collision.transform.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            try
            {
                collision.gameObject.GetComponent<Health>().TakeDamage(damage,Attacker);
            }
               
            catch
            {
                Debug.Log("NO HEALTH COMP ON " + collision.name);
                collision.gameObject.SetActive(false);
            }
        }
        if(collision.transform.CompareTag("Asteroid"))
            gameObject.SetActive(false);
    }

    protected IEnumerator TimeToDisable()
    {       
        yield return new WaitForSeconds(destroyTimer);
        gameObject.SetActive(false);
    }
   
}
