using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class BazookaBullet : Bullet
{
    [SerializeField] private float detectionRadius;
    [SerializeField] private bool foundEnemy = false;
    [SerializeField] private float rotationSpeed = 100f;
    [SerializeField] private GameObject explotionPrefab;
    private Transform target;
    protected override void Update()
    {
              
        if(!foundEnemy)
        {
            Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, detectionRadius);
            base.Update();
            foreach (var hit in hits)
            {
                // Check if the GameObject has the enemy tag
                if (hit.CompareTag("Enemy"))
                {
                    foundEnemy = true;
                    // Perform your homing missile logic here
                    Debug.Log("Enemy detected: " + hit.name);

                    // For example, if you want to home in on this target:
                    target = hit.transform;

                    // You might want to break the loop if you only want to home in on one target
                    break;
                }
            }
        }
        else
        {
            if(target!=null && target.gameObject.activeInHierarchy)            
                Seek(target);
            else
                foundEnemy = false;
           
        }
    }

    void Seek(Transform targetTransform)
    {
        if(!targetTransform.gameObject.activeInHierarchy)
        {
            foundEnemy = false;
            return;
        }
        //Calculate direction to the target
        Vector2 directiototarget = (targetTransform.position - transform.position).normalized;

        //Calculate the angle to rotate towards to the target
        float targetangle = Mathf.Atan2(directiototarget.y, directiototarget.x) * Mathf.Rad2Deg + 90.0f;

        //Smoothly Rotate towards the target
        float angledifference = Mathf.DeltaAngle(targetangle, transform.eulerAngles.z);
        float rotationStep = rotationSpeed * Time.deltaTime;
        float rotationamount = Mathf.Clamp(angledifference, -rotationStep, rotationStep);

        transform.Rotate(Vector3.forward, rotationamount);

        //move along the forward vector using rigidbody2d

        rb.velocity = transform.up * speed;
    }
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy") || collision.CompareTag("Asteroid"))
        {
            MainController.Instance.SoundManager.PlaySound("Bazooka_Explode");
            Instantiate(explotionPrefab,transform.position,Quaternion.identity);
            gameObject.SetActive(false);
        }
    }
}
