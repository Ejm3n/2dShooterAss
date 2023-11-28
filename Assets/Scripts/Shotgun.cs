using UnityEngine;

public class Shotgun : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField]
    private float force;

    [SerializeField] private Bullet bullet;
    [SerializeField] private GameObject shootPoint;
    private ObjectPool<Bullet> pool;

    private void Awake()
    {
        pool = new ObjectPool<Bullet>(bullet, 10, shootPoint.transform);
        pool.AutoExpand = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")&& !GameManager.Instance.GameFinished)
        {
            shoot();
            rb.AddRelativeForce(new Vector2(0, -force));
        }
    }

    void shoot()
    {
        Bullet newBullet = pool.GetFreeElement();
        newBullet.gameObject.SetActive(true);
        newBullet.transform.position = shootPoint.transform.position;
        newBullet.transform.rotation = transform.rotation;
        //Instantiate(bullet, shootPoint.transform);
    }
}
