using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Transform player;
    [SerializeField]
    private float distance;
    private float yPos;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        distance = 10;
        yPos = transform.position.y;
    }

    void Update()
    {
        transform.position = player.position + new Vector3(distance, yPos, -distance);   
    }
}
