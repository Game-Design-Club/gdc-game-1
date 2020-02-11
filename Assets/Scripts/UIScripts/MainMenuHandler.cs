using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour
{
    // TODO Implement actual scenes.
    [SerializeField]
    Text loadGameText;
    [SerializeField]
    Text settingsText;
    [SerializeField]
    Text exitText;
    [SerializeField]
    Text creditsText;

    // TODO Add a loading screen when loading a scene.
    public void NewGame()
    {
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }

    // TODO Add load ability when we have actual levels @designers
    public void LoadGame()
    {
        loadGameText.text = "Ask design to make a level";
    }


    public void Settings()
    {
        SceneManager.LoadScene("Settings", LoadSceneMode.Single);
    }

    // TODO Don't forget to uncomment before building and running game.
    public void Exit()
    {
        exitText.text = "There is no escape";
        //Application.Quit();
    }

    // TODO Add credits screen when we are done making the game (maybe, maybe not).
    public void Credits()
    {
        creditsText.text = "No one cares";
    }
}
