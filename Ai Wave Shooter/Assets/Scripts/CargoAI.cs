using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CargoAI : MonoBehaviour
{

    private NavMeshAgent Agent;

    public GameObject AgentObject;
    DestroyScript destroy;
    public float DestroyPoint;
    public List<Transform> wayPoint;
    public int currentWaypointIndex = 0;

    void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
        destroy = AgentObject.GetComponent<DestroyScript>();
        Agent.SetDestination(wayPoint[currentWaypointIndex].position);
    }


    void Update()
    {

        Flying();

        if (currentWaypointIndex == DestroyPoint)
        {
            destroy.DestroyObject();
        }
    }

    public void Flying()
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
