using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGun : MonoBehaviour
{
    [SerializeField] private LaserBeam laserBeam;
      void Update()
    {       
        if (Input.GetButton("Fire1")&& !GameManager.Instance.GameFinished)
        {
            Shoot();                     
        }
        else if(Input.GetButtonUp("Fire1")&& !GameManager.Instance.GameFinished)
        {
            StopShoot();
        }
    }
    private void Shoot()
    {
        laserBeam.gameObject.SetActive(true);
        laserBeam.LaserShoot(transform.rotation);
    }
    private void StopShoot()
    {
        laserBeam.gameObject.SetActive(false);
    }
}
