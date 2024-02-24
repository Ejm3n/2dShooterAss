using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bazooka : Shotgun
{
    [SerializeField] private int startBullets = 5;
    private int currentBullets;

    private void OnEnable()
    {
        currentBullets = startBullets;
        UIManager.Instance.UpdateBazookaCharge(currentBullets);
    }
    protected override void Update()
    {
        base.Update();
        if (Input.GetButtonDown("Fire1") && !GameManager.Instance.GameFinished)
        {
            if (Shoot(audioKey))
                rb.AddRelativeForce(new Vector2(0, -force));
            UIManager.Instance.UpdateBazookaCharge(currentBullets);
            currentBullets--;
            if(currentBullets<=0)
            {
                GetComponent<PlayerMove>().ChangeGuns(false);
            }
        }
    }
}
