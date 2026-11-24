using UnityEngine;
using UnityEngine.AI;

public class MonsterMovement : MonoBehaviour {
    [Header("Movement")]
    [SerializeField] private float patrolSpeed = 2f;
    [SerializeField] private float chaseSpeed = 4f;

    [Header("Detection")]
    [SerializeField] private float detectionDistance = 12f;
    [SerializeField] private float loseDistance = 18f;

    [Header("Patrol")]
    [SerializeField] private Transform[] patrolPoints;
    [SerializeField] private float pointStopDistance = 1f;

    private NavMeshAgent agent;
    private Animator animator;
    private Transform player;

    private int currentPatrolPoint;
    private bool chasing;

    private void Awake() {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Start() {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null) {
            player = playerObject.transform;
        }
        else {
            Debug.LogError("Monster could not find an object tagged Player.");
        }

        if (!agent.isOnNavMesh) {
            Debug.LogError("The Hound is not standing on the NavMesh.");
            return;
        }

        agent.speed = patrolSpeed;
        MoveToNextPatrolPoint();
    }

    private void Update() {
        if (!agent.isOnNavMesh) {
            return;
        }

        if (player != null) {
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            if (!chasing && distanceToPlayer <= detectionDistance) {
                StartChasing();
            }
            else if (chasing && distanceToPlayer > loseDistance) {
                StopChasing();
            }
        }

        if (chasing) {
            ChasePlayer();
        } else {
            Patrol();
        }

        if (animator != null) {
            animator.SetFloat("Speed", agent.velocity.magnitude);
        }
    }

    private void Patrol() {
        if (patrolPoints == null || patrolPoints.Length == 0) {
            return;
        }

        if (!agent.pathPending && agent.remainingDistance <= pointStopDistance) {
            currentPatrolPoint = (currentPatrolPoint + 1) % patrolPoints.Length;
            MoveToNextPatrolPoint();
        }
    }

    private void MoveToNextPatrolPoint() {
        if (patrolPoints == null || patrolPoints.Length == 0 || !agent.isOnNavMesh) {
            return;
        }

        agent.speed = patrolSpeed;
        agent.SetDestination( patrolPoints[currentPatrolPoint].position);
    }

    private void StartChasing() {
        chasing = true;
        agent.speed = chaseSpeed;

        Debug.Log("Hound started chasing the player.");
    }

    private void ChasePlayer() {
        if (player != null) {
            agent.SetDestination(player.position);
        }
    }

    private void StopChasing() {
        chasing = false;
        agent.speed = patrolSpeed;

        Debug.Log("Hound lost the player and returned to patrol.");

        MoveToNextPatrolPoint();
    }
}