using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FlyingAiContorler : MonoBehaviour
{
    public Transform Hub;
    [SerializeField] private LayerMask whatIsHub;

    public float UpdateSpeed = 0.1f;
    public float FarSpeed = 10;
    public float CloseSpeed = 5;

    public float Speed;

    private NavMeshAgent Agent;

    public List<Transform> wayPoint;
    public int currentWaypointIndex = 0;


    public float attackRange, FarRange, CloseRange;
    public bool hubInAttackRange, hubInFarRange, hubInCloseRange;

    private void Awake()
    {
        Agent = GetComponent<NavMeshAgent>();
        Hub = GameObject.Find("Hub").transform;
        Agent.SetDestination(wayPoint[currentWaypointIndex].position);
    }

    void Start()
    {

    }

    void Update()
    {
        Speed = Agent.speed;

        hubInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsHub);
        hubInFarRange = Physics.CheckSphere(transform.position, FarRange, whatIsHub);
        hubInCloseRange = Physics.CheckSphere(transform.position, CloseRange, whatIsHub);

        if (hubInFarRange && !hubInCloseRange && !hubInAttackRange) { Far(); }
        if (hubInFarRange && hubInCloseRange && !hubInAttackRange) { Close(); }
        if (hubInFarRange && hubInCloseRange && hubInAttackRange) { AttacHub(); }

        AttackingHub();
    }
    public void Far()
    {
        Agent.speed = + FarSpeed;     
    }

    public void Close()
    {
        Agent.speed = + CloseSpeed;
    }

    public void AttacHub()
    {       

    }

    public void AttackingHub()
    {
        if (wayPoint.Count == 0)
        {

            return;
        }


         float distanceToWaypoint = Vector3.Distance(wayPoint[currentWaypointIndex].position, transform.position);

        if (distanceToWaypoint <= 8)
        {

            currentWaypointIndex = (currentWaypointIndex + 1) % wayPoint.Count;
        }

        Agent.SetDestination(wayPoint[currentWaypointIndex].position);
    }
}


