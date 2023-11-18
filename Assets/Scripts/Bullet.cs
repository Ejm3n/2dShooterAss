using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rb;
    
    [SerializeField]
    float speed;

    [SerializeField]
    float destroyTimer = 5f;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();


        //rb.AddRelativeForce(new Vector2(0, speed));
        
    }
    private void Update()
    {
        transform.Translate(Vector2.up*speed*Time.deltaTime);
    }
    private void OnEnable()
    {
        transform.parent = null;
        StartCoroutine(TimeToDisable());
    }

    private IEnumerator TimeToDisable()
    {       
        yield return new WaitForSeconds(destroyTimer);
        gameObject.SetActive(false);
    }
   
}
