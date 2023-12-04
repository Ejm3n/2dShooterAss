using UnityEngine;

public class Shotgun : Gun
{
    [SerializeField]
    private float force;
    protected override void Update()
    {
        base.Update();
        if (Input.GetButtonDown("Fire1")&& !GameManager.Instance.GameFinished)
        {
           if( Shoot())
                rb.AddRelativeForce(new Vector2(0, -force));
        }
    }

  
}
