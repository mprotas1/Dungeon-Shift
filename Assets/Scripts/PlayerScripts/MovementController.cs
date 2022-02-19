using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovementController : MonoBehaviour
{
    private NavMeshAgent navAgent;

    // Start is called before the first frame update
    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
    }

    public void MovePlayer(Vector3 destination)
    {
        navAgent.isStopped = false;
        navAgent.destination = destination;
    }

    public void StopPlayer()
    {
        navAgent.isStopped = true;
    }
}
