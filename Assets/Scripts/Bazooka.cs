using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bazooka : Gun
{
    [SerializeField] private int startBullets = 5;
    private int currentBullets;

    [SerializeField] private float force;

    private void OnEnable()
    {
        currentBullets = startBullets;
        MainController.Instance.UIManager.UpdateBazookaCharge(currentBullets);
    }
    protected override void Update()
    {
       base.Update();
        if (Input.GetButtonDown("Fire1") && !GameManager.Instance.GameFinished)
        {
            if (Shoot(audioKey))
            {
                rb.AddRelativeForce(new Vector2(0, -force));

                currentBullets--;
                MainController.Instance.UIManager.UpdateBazookaCharge(currentBullets);
                if (currentBullets <= 0)
                {
                    GetComponent<PlayerMove>().ChangeGuns(false);
                }
            }
                
        }
    }
}
