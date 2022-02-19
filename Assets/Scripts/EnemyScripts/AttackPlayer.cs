using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AttackPlayer : MonoBehaviour
{
    private GameObject player; 
    private NavMeshAgent agent; 
    private EnemyInstance instance; 
    private Vector3 InitialPosition; 
    private PlayerCharacter playerInstance; 
    private float delayBetweenAttacks = 1.5f;

    private float rangeOfSight = 4.0f; 

    private float rangeOfAttack = 2.0f;

    private bool canAttack = true;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerInstance = player.GetComponent<CharacterInstance>().player;
        agent = GetComponent<NavMeshAgent>();
        instance = GetComponent<EnemyInstance>();
        InitialPosition = GetComponent<Transform>().position;
    }

    private void Update()
    {
        ScoutAttack();
    }

    private void ScoutAttack()
    {
        float distance = calculateDistance(transform.position, player.transform.position);
        if (distance <= rangeOfSight)
        {
            ChasePlayer();

            if (distance <= rangeOfAttack && canAttack)
            {
                StartCoroutine(AttackDelay());
                instance.Attack(playerInstance);
            }

        }

        else GoToInitialPosition();

    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.transform.position);
    }

    private void GoToInitialPosition()
    {
        agent.SetDestination(InitialPosition);
    }

    private float calculateDistance(Vector3 enemy, Vector3 player)
    {
        return Vector3.Distance(enemy, player);
    }
    IEnumerator AttackDelay()
    {
        agent.isStopped = true;
        canAttack = false;
        yield return new WaitForSeconds(delayBetweenAttacks);
        agent.isStopped = false;
        canAttack = true;
    }

}
