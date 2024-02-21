using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeam : Bullet
{
    [SerializeField] private float heatPerFrame = 0.01f;
    private List<EnemyHealth> enemiesToHeat = new List<EnemyHealth>();
  
  
    protected override void Update() {
        try
        {
foreach (EnemyHealth enemyHealth in enemiesToHeat)
        {
            if(enemyHealth != null)
                enemyHealth.HeatEnemy(heatPerFrame);
        }
        }
        catch
        {
            Debug.Log("something in laserbeam...");
        }
    }
    protected override void OnEnable() {
    
  } 
    public void LaserShoot(Quaternion rotation)
    {
        transform.rotation = rotation;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Enemy")&& other.TryGetComponent<EnemyHealth>(out EnemyHealth enemyHealth))
        {
            enemiesToHeat.Add(enemyHealth);
        }
        if(other.CompareTag("Asteroid"))
        {
            //idk
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Enemy")&& other.TryGetComponent<EnemyHealth>(out EnemyHealth enemyHealth))
        {
            enemiesToHeat.Remove(enemyHealth);
        }
    }
}
