using System.Collections;
using UnityEngine;

public class AIEnemy : MonoBehaviour
{
    public float velocity;
    public float patrolSpeed;
    public float attackSpeed;
    public float chaseSpeed;

    [Header("Player")]

    public GameObject playerObj;
    public Vector3 distance;

    [Header("Shooting")]

    public GameObject enemyBullet;
    public GameObject shootingPosition;
    public Transform bulletsStore;

    [Header("Prediction Values")]

    public float chaseThreshold = 10f;
    public float attackThreshold = 5f;
    public EnemyBehaviour enemyBehaviour;

    [Header("Booleans")]

    public bool isIdle = true;
    public bool isPatrolling = false;
    public bool isAttacking = false;
    public bool isChasing = false;
    public bool canShoot = true;
    private void Start()
    {
        if(playerObj == null)
        {
            playerObj = GameObject.FindGameObjectWithTag("Player");
        }
        
        if(bulletsStore == null)
        {
            bulletsStore = GameObject.FindGameObjectWithTag("bulletStore").transform;
        }

        enemyBehaviour = EnemyBehaviour.Idle;
    }

    private void Update()
    {
        distance = new Vector3(transform.position.x - playerObj.transform.position.x, 0f, transform.position.z - playerObj.transform.position.z);
        if (isIdle && distance.z > chaseThreshold && distance.z > attackThreshold)
        {
            IdleMovement();
        }

        if(isPatrolling && distance.z < chaseThreshold && distance.z > attackThreshold)
        {
            ChaseMovement();
        }

        if(isChasing && distance.z < attackThreshold)
        {
            AttackMovement();
        }

        DestroyEnemy();
    }

    void IdleMovement()
    {
        enemyBehaviour = EnemyBehaviour.Patrol;
        isPatrolling = true;
        velocity = patrolSpeed;
        float targetPosX = Random.Range(transform.position.x, transform.position.x + 15f);
        float targetPosZ = Random.Range(transform.position.z, transform.position.z + 25f);
        transform.Translate(new Vector3(0f, 0f, velocity * Time.deltaTime));
        Debug.Log("I AM PATROLLING!");
    }

    void ChaseMovement()
    {
        enemyBehaviour = EnemyBehaviour.Chase;
        isChasing = true;
        velocity = chaseSpeed;
        transform.position += distance * velocity * Time.deltaTime;
        Debug.Log("I AM CHASING!");
    }

    void AttackMovement()
    {
        enemyBehaviour = EnemyBehaviour.Attack;
        isAttacking = true;
        velocity = attackSpeed;
        transform.position += distance * velocity * Time.deltaTime;
        Debug.Log("I AM ATTACKING BRO!");
        if (canShoot)
        {
            StartCoroutine(ShootBullet(0.5f));
        }
    }

    void DestroyEnemy()
    {
        if (HasDied())
        {
            GameManager gameManager = FindObjectOfType<GameManager>();
            gameManager.IncreaseKills();
        }
    }

    public bool HasDied()
    {
        var enemyHealthManager = GetComponent<HealthManager>();
        return enemyHealthManager.currentHealth <= 0;
    }

    private IEnumerator ShootBullet(float time)
    {
        var bulletSpawned = Instantiate(enemyBullet, shootingPosition.transform.position, Quaternion.identity, bulletsStore.transform);
        canShoot = false;
        yield return new WaitForSeconds(time);
        canShoot = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BulletPlayer"))
        {
            var enemyHealth = GetComponent<HealthManager>();
            enemyHealth.TakeDamage(30f);
            Destroy(other.gameObject);
        }
    }

}

public enum EnemyBehaviour
{
    Idle,
    Patrol,
    Chase,
    Attack
}