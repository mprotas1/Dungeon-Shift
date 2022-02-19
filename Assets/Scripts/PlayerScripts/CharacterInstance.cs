using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInstance : MonoBehaviour
{
    private PlayerInitializer playerInit;
    public PlayerCharacter player;

    void Awake()
    {

        playerInit = GameObject.Find("GameManager").GetComponent<PlayerInitializer>();
        if (playerInit.GetPlayerClass() != null)
        {

            player = playerInit.GetPlayerClass();
        }
        else
        {
            player = new WarriorClass((PlayerData)PlayerData.CreateInstance("PlayerData"));
        }
    }
}
