using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaypointPatrol : MonoBehaviour
{
    public NavMeshAgent NavMeshAgent;
    public Transform[] waypoints;
    int m_CurrentWaypointIndex;
    // Start is called before the first frame update
    void Start()
    {
        NavMeshAgent.SetDestination(waypoints[0].position);
    }

    // Update is called once per frame
    void Update()
    {
        if(NavMeshAgent.remainingDistance < NavMeshAgent.stoppingDistance)
        {
            m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % waypoints.Length;
            NavMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
        }
    }
}
