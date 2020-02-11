using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsHandler : MonoBehaviour
{
    // Loads the Key Binds Scene.
    public void KeyBinds()
    {
        SceneManager.LoadScene("KeyBindsSettings", LoadSceneMode.Single);
    }

    // Loads the Main Menu Scene.
    public void Back()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}
