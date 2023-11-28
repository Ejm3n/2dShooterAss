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
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        if(!GameManager.Instance.GameFinished)
        {
            Move();
            RotateTowardsMousePointer();
        }      
    }

    private void Update()
    {
        Dash();
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


