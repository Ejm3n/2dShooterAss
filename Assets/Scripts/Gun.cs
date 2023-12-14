using UnityEngine;

public class Gun : MonoBehaviour
{

    protected Rigidbody2D rb;

    [SerializeField] private AudioSource shotSound;
    [SerializeField] protected KilledBy attacker;
    [SerializeField] protected Bullet bullet;
    [SerializeField] protected GameObject shootPoint;
    [SerializeField] protected float delayBtwShots = 1f;
    private float timeToReload;
    protected ObjectPool<Bullet> pool;

    protected void Awake()
    {
        pool = new ObjectPool<Bullet>(bullet, 10, shootPoint.transform);
        pool.AutoExpand = true;
        timeToReload = delayBtwShots;
    }
    // Start is called before the first frame update
    protected void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();

    }
    protected virtual void Update()
    { 
        if (timeToReload >= 0)
            timeToReload -= Time.deltaTime;
    }
    public bool Shoot()
    {
        if (timeToReload <= 0)
        {
            shotSound.Play();
            Bullet newBullet = pool.GetFreeElement();
            newBullet.gameObject.SetActive(true);
            newBullet.transform.position = shootPoint.transform.position;
            newBullet.transform.rotation = shootPoint. transform.rotation;
            newBullet.Attacker = attacker;
            timeToReload = delayBtwShots;
            return true;
        }
        return false;
        //Instantiate(bullet, shootPoint.transform);
    }
}
