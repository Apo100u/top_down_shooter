using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Health health;
    [SerializeField] private float movementSpeed = 2.5f;
    [SerializeField] private float attackRange = 0.5f;
    [SerializeField] private float attackCooldown = 2f;
    [SerializeField] private float minDamage = 5f;
    [SerializeField] private float maxDamage = 10f;

    public bool Initialized { get; private set; }

    private Player player;
    private GameObjectPool enemyPool;
    private bool playerInAttackRange;
    private float lastAttackTime;

    public void Init(Player player, GameObjectPool enemyPool)
    {
        this.player = player;
        this.enemyPool = enemyPool;
        health.OnAllHealthLost += OnAllHealthLost;
        Initialized = true;
    }

    private void Update()
    {
        if (player.Health.CurrentHealth > 0)
        {
            playerInAttackRange = Vector2.Distance(
                Vector2.right * transform.position.x + Vector2.up * transform.position.z,
                Vector2.right * player.transform.position.x + Vector2.up * player.transform.position.z) <= attackRange;


            if (playerInAttackRange)
            {
                AttackPlayer();
            }
            else
            {
                ChasePlayer();
            }
        }
    }

    private void ChasePlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, movementSpeed * Time.deltaTime);
        transform.LookAt(player.transform, Vector2.up);
    }

    private void AttackPlayer()
    {
        if (Time.time > lastAttackTime + attackCooldown)
        {
            player.Health.ChangeCurrentBy(-Random.Range(minDamage, maxDamage));
            lastAttackTime = Time.time;
        }
    }

    private void OnAllHealthLost()
    {
        enemyPool.Return(this.gameObject);
        player.AddScore();
    }
}