using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class Stats : MonoBehaviour
{
    private TextMeshProUGUI ExperienceText;
    private TextMeshProUGUI LevelText;
    private PlayerCharacter character;
    private LevelManager levelManager;

    void Start()
    {
        ExperienceText = GameObject.Find("ExperienceText").GetComponent<TextMeshProUGUI>();
        LevelText = GameObject.Find("LevelText").GetComponent<TextMeshProUGUI>();
        character = GameObject.Find("Player").GetComponent<CharacterInstance>().player;
        levelManager = GameObject.Find("Player").GetComponent<LevelManager>();
        levelManager.OnExpGain += UpdateElement;
    }

    private void UpdateElement()
    {
        LevelText.SetText("LEVEL: " + character.CharacterLevel.ToString());
        ExperienceText.SetText("EXP: " + character.ExperiencePoints.ToString());
    }
}
