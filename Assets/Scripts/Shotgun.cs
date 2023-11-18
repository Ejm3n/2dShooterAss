using UnityEngine;

public class Shotgun : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField]
    private float force;

    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject shootPoint;


    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            shoot();
            rb.AddRelativeForce(new Vector2(0, -force));
        }
    }

    void shoot()
    {
        Instantiate(bullet, shootPoint.transform);
    }
}
