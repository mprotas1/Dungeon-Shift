using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public event Action OnExpGain;
    public event Action LeveledUp;
    private PlayerCharacter character;

    private void Start()
    {
        character = GetComponent<CharacterInstance>().player;
    }

    public void AddExp(int value)
    {
        character.ExperiencePoints += value;
        if(CheckIfLeveledUp())
        {
            LeveledUp();
        }
        OnExpGain();

    }

    private bool CheckIfLeveledUp()
    {
        if (character.ExperiencePoints >= character.CharacterLevel * 500)
        {
            character.CharacterLevel++;
            return true;
        }
        else
        {
            return false; 
        }
    }


}
