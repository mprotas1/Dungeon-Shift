using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private Button playButton;
    private Button optionsButton;
    private GameObject mainMenu;

    void Start()
    {
        mainMenu = GameObject.Find("MainMenuItem");
        playButton = GameObject.Find("PlayButton").GetComponent<Button>();
        optionsButton = GameObject.Find("OptionsButton").GetComponent<Button>();
    }

    public void ManageButtons(Button button)
    {
        if(button == playButton)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if(button == optionsButton)
        {
            mainMenu.SetActive(false);
        }
    }

    public void Quit()
    {
        Debug.Log("Qutting the game");
        Application.Quit();
    }
}
