using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMovement : MonoBehaviour
{
    public Transform Hub;
    public Transform Player;
    [SerializeField] private LayerMask whatIsPlayer;
    [SerializeField] private LayerMask whatIsHub;

    public float UpdateSpeed = 0.1f;

    private NavMeshAgent Agent;

    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange, hubInAttackRange;

    private void Awake()
    {
        Agent = GetComponent<NavMeshAgent>();
        Player = GameObject.Find("Player").transform;
        Hub = GameObject.Find("Hub").transform;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        hubInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsHub);

        if (!playerInSightRange && !playerInAttackRange && !hubInAttackRange) { GoToHub(); }
        if (!playerInSightRange && !playerInAttackRange && hubInAttackRange) { AttacHub(); }
        if (playerInSightRange && !playerInAttackRange && !hubInAttackRange) { GoToPlayer(); }
        if (playerInSightRange && playerInAttackRange && !hubInAttackRange) { AttackPlayer(); }

    }

    public void GoToHub()
    {
        Agent.SetDestination(Hub.transform.position);
    }
    public void AttacHub()
    {
        Destroy(gameObject);
    }

    public void GoToPlayer()
    {
        Agent.SetDestination(Player.transform.position);
    }

    public void AttackPlayer()
    {
        Agent.SetDestination(Player.transform.position);
    }
}
