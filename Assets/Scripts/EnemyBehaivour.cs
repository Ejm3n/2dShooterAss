using UnityEngine;

public class EnemyBehaivour : MonoBehaviour
{

    public float patrolRadius = 5f;
    public float moveSpeed = 2f;
    public float detectionRadius = 3f;
    public float rotationSpeed = 5f;
    public float thresholdAngle = 1f;
    [SerializeField] private Gun enemyGun;
    [SerializeField] private Vector2 minPositionBounders;
    [SerializeField] private Vector2 maxPositionBounders;
    private Vector2 targetPosition;
    private bool isPlayerDetected = false;


    void Start()
    {    
        if(enemyGun == null)
            enemyGun = GetComponent<EnemyGun>();
    }
    private void OnEnable()
    {
        SetRandomTarget();
        SetRandomRotation();
    }
    void Update()
    {
        if (!isPlayerDetected)
            Patrol();


        CheckForPlayer();
    }

    void Patrol()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, targetPosition) < 0.2f)
        {
            SetRandomTarget();
        }
    }

    void CheckForPlayer()
    {
        isPlayerDetected = false;
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, detectionRadius);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.gameObject.CompareTag("Player"))
            {
                isPlayerDetected = true;
                // �������� ������ ��� ������������� ������
                LookToPlayerAndShoot(hitCollider.transform);
                break;
            }
        }
    }

    void LookToPlayerAndShoot(Transform target)
    {

        Vector2 direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        if (Quaternion.Angle(transform.rotation, targetRotation) < thresholdAngle)
        {
            //Debug.Log("������ ��������� ���������� � ����");
            Shoot();
        }
    }

    void Shoot()
    {
        enemyGun.Shoot("Laser_Enemy");
    }
    void SetRandomTarget()
    {
        
        float randomX = Random.Range(-patrolRadius, patrolRadius);
        while (randomX + transform.position.x < minPositionBounders.x || randomX + transform.position.x > maxPositionBounders.x)
            randomX = Random.Range(-patrolRadius, patrolRadius);
        float randomY = Random.Range(-patrolRadius, patrolRadius);
        while (randomY + transform.position.y < minPositionBounders.y || randomY + transform.position.y > maxPositionBounders.y)
            randomY = Random.Range(-patrolRadius, patrolRadius);
        targetPosition = new Vector2(randomX, randomY) + (Vector2)transform.position;
        //Debug.Log("TARGET POS" + targetPosition);
    }
    void SetRandomRotation()
    {
        float randomAngle = Random.Range(0f, 360f);
        transform.rotation = Quaternion.Euler(0f, 0f, randomAngle);
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, patrolRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
  
}
