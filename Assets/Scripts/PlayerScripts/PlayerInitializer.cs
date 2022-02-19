using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInitializer : MonoBehaviour
{
    private PlayerCharacter selectedClass;

    public void InitializePlayer(PlayerCharacter character)
    {
        selectedClass = character;
    }

    public PlayerCharacter GetPlayerClass()
    {
        return selectedClass;
    }
}
