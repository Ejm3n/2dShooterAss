using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private Camera mainCamera;
    private Rigidbody2D rb;
    private Vector2 movement;
    [SerializeField] private float dash;
    [SerializeField] private GameObject particle;
    [SerializeField] private Transform particleEmit;

    private LaserGun LaserGun;
    private Shotgun shotgun;
    [SerializeField]
    private LaserBeam laserBeam;
    public float laserCharge, maxCharge;
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        LaserGun = GetComponent<LaserGun>();
        shotgun = gameObject.GetComponent<Shotgun>();
    }


    void FixedUpdate()
    {
        if(!GameManager.Instance.GameFinished)
        {
            WeaponManager();
            Move();
            RotateTowardsMousePointer();
        }      
    }

    private void Update()
    {
        Dash();
    }

    void WeaponManager()
    {
        if (laserCharge > maxCharge) laserCharge = maxCharge;

        if (laserCharge > 0)
        {
            LaserGun.enabled = true;
            shotgun.enabled = false;
        }
        else
        {
            LaserGun.enabled = false;
            shotgun.enabled = true;
            laserBeam.gameObject.SetActive(false);
        }
    }

    public void AddCharge(float chargeToAdd)
    {
        laserCharge += chargeToAdd;
        UIManager.Instance.UpdateLaserCharge(laserCharge / maxCharge);
    }
    public void RemoveCharge(float chargeToSubtract)
    {
        laserCharge -= chargeToSubtract;
        UIManager.Instance.UpdateLaserCharge(laserCharge / maxCharge);
    }

    /// <summary>
    /// rotating towards mouse
    /// </summary>
    void RotateTowardsMousePointer()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePosition - transform.position).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f; // -90 degree offset if your sprite is upright
        rb.rotation = angle;
    }
    private void Move()
    {
        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxis("Vertical"));

        if (movement.magnitude > 1)
            movement = movement.normalized;

        rb.AddForce(movement * moveSpeed);
    }
    private void Dash()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rb.AddRelativeForce(new Vector2(0, dash));
            GameObject part = Instantiate(particle, particleEmit);
            Destroy(part, 1f);
        }
    }
}


