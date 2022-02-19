using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AttackEnemy : MonoBehaviour
{
    private CharacterInstance character;
    private EnemyInstance enemy;
    private NavMeshAgent navAgent;

    private void Start()
    {
        character = GameObject.Find("Player").GetComponent<CharacterInstance>();
        navAgent = GetComponent<NavMeshAgent>();
    }
    
    private float calculateDistance(RaycastHit hit, GameObject object3d) => Vector3.Distance(hit.point, object3d.transform.position);
    public void enemyClicked(RaycastHit hit)
    {
        float distance = calculateDistance(hit, character.gameObject);
        if (distance <= character.player.AttackRange)
        {
            enemy = hit.transform.gameObject.GetComponent<EnemyInstance>();
            character.player.Attack(enemy);
            navAgent.isStopped = false;
        }
        else if (distance >= character.player.AttackRange)
        {
            StopAllCoroutines();
            StartCoroutine(goWhileInDistance(hit));
        }
    }

    IEnumerator goWhileInDistance(RaycastHit hit)
    {
        bool isInReach = true;

        while (isInReach)
        {
            if (calculateDistance(hit, character.gameObject) <= character.player.AttackRange)
            {
                navAgent.isStopped = true;
                isInReach = false;
            }
            else
            {
                isInReach = true;
            }
            yield return null;
        }
        yield return null;
    }
}
