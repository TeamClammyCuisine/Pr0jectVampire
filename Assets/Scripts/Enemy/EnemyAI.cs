using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Transform player;
    [SerializeField] private LayerMask groundLayerMask, playerLayerMask;
    [SerializeField] private float health;

    private Vector3 _walkPoint;
    private bool _walkPointSet;
    [SerializeField] private float walkPointRange;

    //Attacking
    [SerializeField] private float timeBetweenAttacks;

    private bool _alreadyAttacked;
    //[SerializeField] private GameObject projectile;

    //States
    [SerializeField] private float sightRange, attackRange;
    private bool _playerInSightRange, _playerInAttackRange;

    private void Awake()
    {
        player ??= GameObject.Find("Character").transform;
        agent ??= GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        var position = transform.position;
        _playerInSightRange = Physics.CheckSphere(position, sightRange, playerLayerMask);
        _playerInAttackRange = Physics.CheckSphere(position, attackRange, playerLayerMask);

        if (!_playerInSightRange && !_playerInAttackRange) Patrolling();
        if (_playerInSightRange && !_playerInAttackRange) ChasePlayer();
        if (_playerInAttackRange && _playerInSightRange) AttackPlayer();
    }

    private void Patrolling()
    {
        if (!_walkPointSet) SearchWalkPoint();

        if (_walkPointSet)
            agent.SetDestination(_walkPoint);

        var distanceToWalkPoint = transform.position - _walkPoint;

        if (distanceToWalkPoint.magnitude < 1f)
            _walkPointSet = false;
    }

    private void SearchWalkPoint()
    {
        //Calculate random point in range
        var randomZ = Random.Range(-walkPointRange, walkPointRange);
        var randomX = Random.Range(-walkPointRange, walkPointRange);

        var position = transform.position;
        _walkPoint = new Vector3(position.x + randomX, position.y, position.z + randomZ);

        if (Physics.Raycast(_walkPoint, -transform.up, 2f, groundLayerMask))
            _walkPointSet = true;
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        //Make sure enemy doesn't move
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (_alreadyAttacked) return;
        //Attack code here
        /*var rigidBody = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
        rigidBody.AddForce(transform.forward * 32f, ForceMode.Impulse);
        rigidBody.AddForce(transform.up * 8f, ForceMode.Impulse);*/
        //End of attack code

        _alreadyAttacked = true;
        Invoke(nameof(ResetAttack), timeBetweenAttacks);
    }

    private void ResetAttack()
    {
        _alreadyAttacked = false;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0) Invoke(nameof(DestroyEnemy), 0.5f);
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        var position = transform.position;
        Gizmos.DrawWireSphere(position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(position, sightRange);
    }
}