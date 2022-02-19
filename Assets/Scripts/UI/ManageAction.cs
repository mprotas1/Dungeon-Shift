using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManageAction : MonoBehaviour
{
    [SerializeField]
    private PlayerData[] playerDatas;
    private PlayerCharacter selectedClass;

    private Button warriorButton;
    private Button thiefButton;
    private Button mageButton;
    private Button paladinButton;

    private PlayerInitializer playerInit;

    void Start()
    {
        playerInit = GameObject.Find("GameManager").GetComponent<PlayerInitializer>();
        warriorButton = GameObject.Find("WarriorButton").GetComponent<Button>();
        thiefButton = GameObject.Find("RogueButton").GetComponent<Button>();
        mageButton = GameObject.Find("MageButton").GetComponent<Button>();
        paladinButton = GameObject.Find("PaladinButton").GetComponent<Button>();
    }

    public void ManageClassButtons(Button button)
    {
        if (button == warriorButton)
        {
            selectedClass = new WarriorClass(playerDatas[0]);
            playerInit.InitializePlayer(selectedClass);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (button == thiefButton)
        {
            selectedClass = new RogueClass(playerDatas[1]);
            playerInit.InitializePlayer(selectedClass);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (button == mageButton)
        {
            selectedClass = new MageClass(playerDatas[2]);
            playerInit.InitializePlayer(selectedClass);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }
        if (button == paladinButton)
        {
            selectedClass = new PaladinClass(playerDatas[3]);
            playerInit.InitializePlayer(selectedClass);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

    }

}
