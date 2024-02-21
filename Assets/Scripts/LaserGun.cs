using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGun : MonoBehaviour
{
    [SerializeField] private LaserBeam laserBeam;
    [SerializeField]
    private float chargeDrain;
    private PlayerMove player;

    private void Awake()
    {
        player = GetComponentInParent<PlayerMove>();
    }
    void Update()
    {       
        if (Input.GetButton("Fire1")&& !GameManager.Instance.GameFinished&&player.laserCharge>0)
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
        player.RemoveCharge(chargeDrain);
    }
    private void StopShoot()
    {
        laserBeam.gameObject.SetActive(false);
    }
}
