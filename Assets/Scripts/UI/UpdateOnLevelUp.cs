using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpdateOnLevelUp : MonoBehaviour
{
    //classes
    private PlayerCharacter character;
    private LevelManager levelManager;
    //buttons
    private Button healthUpButton;
    private Button manaUpButton;
    private Button closeButton;
    //texts
    private TextMeshProUGUI pointsText;
    private TextMeshProUGUI healthText;
    private TextMeshProUGUI manaText;
    //variables
    private int skillPoints = 0;
    private bool canUpgrade = true;
    
    // Start is called before the first frame update
    void Start()
    {
        //classes
        character = GameObject.Find("Player").GetComponent<CharacterInstance>().player;
        levelManager = GameObject.Find("Player").GetComponent<LevelManager>();
        //buttons
        healthUpButton = GameObject.Find("HealthUpButton").GetComponent<Button>();
        manaUpButton = GameObject.Find("ManaUpButton").GetComponent<Button>();
        closeButton = GameObject.Find("CloseBtn").GetComponent<Button>();
        //texts
        healthText = GameObject.Find("AddHealthText").GetComponent<TextMeshProUGUI>();
        manaText = GameObject.Find("AddManaText").GetComponent<TextMeshProUGUI>();
        pointsText = GameObject.Find("PointsText").GetComponent<TextMeshProUGUI>();
        UpdateTexts();
        levelManager.LeveledUp += ShowWindow;
        gameObject.SetActive(false);
    }

    private void ShowWindow()
    {
        skillPoints += 3;
        UpdateTexts();
        Time.timeScale = 0.0f;
        canUpgrade = true;
        gameObject.SetActive(true);
    }

    public void CloseWindow()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1.0f;
    }

    private void UpdateTexts()
    {
        healthText.text = "Health: " + character.MaxHitPoints;
        manaText.text = "Mana: " + character.ManaPoints;
        pointsText.text = "Points: " + skillPoints;
    }

    public void ManageButtons(Button button)
    {
        if(button.Equals(healthUpButton) && canUpgrade)
        {
            character.MaxHitPoints += 10;
            healthText.SetText("Health: " + character.MaxHitPoints.ToString());
            skillPoints--;
            pointsText.text = "Points: " + skillPoints.ToString();
            if (skillPoints <= 0)
            {
                canUpgrade = false;
            }
        }
        if (button.Equals(manaUpButton) && canUpgrade)
        {
            character.ManaPoints += 10;
            healthText.SetText("Mana: " + character.ManaPoints.ToString());
            skillPoints--;
            pointsText.text = "Points: " + skillPoints.ToString();
            if (skillPoints <= 0)
            {
                canUpgrade = false;
            }
        }
    }
}
