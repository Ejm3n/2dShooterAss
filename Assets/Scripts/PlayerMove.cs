using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private Camera mainCamera;
    private Rigidbody2D rb;
    private Vector2 movement;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxis("Vertical"));

        if (movement.magnitude > 1)
            movement = movement.normalized;

        rb.AddForce(movement * moveSpeed);
        RotateTowardsMousePointer();
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
}


