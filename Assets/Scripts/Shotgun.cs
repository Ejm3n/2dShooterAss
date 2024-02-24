using UnityEngine;

public class Shotgun : Gun
{
    [SerializeField]
    protected float force;
    
    protected override void Update()
    {
        base.Update();
        if (Input.GetButtonDown("Fire1")&& !GameManager.Instance.GameFinished)
        {
           if( Shoot(audioKey))
                rb.AddRelativeForce(new Vector2(0, -force));
        }
    }

  
}
