using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsHandler : MonoBehaviour
{
    public void KeyBinds()
    {
        SceneManager.LoadScene("KeyBindsSettings", LoadSceneMode.Single);
    }

    public void Back()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}
