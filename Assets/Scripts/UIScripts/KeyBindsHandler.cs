using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KeyBindsHandler : MonoBehaviour
{
    [SerializeField]
    GameObject forwardInput;

    private PlayerPrefs playerPrefs = PlayerPrefs.GetInstance();
    private Text currentInput;
    private bool checkForKey = false;
    private string lastText, keyType;

    private void Start()
    {
        forwardInput.transform.GetChild(0).GetComponent<Text>().text = playerPrefs.Move_Forward;
    }

    private void OnGUI()
    {
        if(checkForKey)
        {
            Event e = Event.current;
            if (e != null && e.isKey && e.type == EventType.KeyDown)
            {
                SetKey(e.keyCode);
                checkForKey = false;
            }
        }
    }

    private void SetKey(KeyCode key)
    {
        if(key == KeyCode.Escape)
        {
            currentInput.text = lastText;
            currentInput = null;
            lastText = "";
            keyType = "";
            return;
        }

        if (keyType == "Move_Forward")
        {
            playerPrefs.Move_Forward = "" + key;
            currentInput.text = playerPrefs.Move_Forward;
            currentInput = null;
            lastText = "";
            keyType = "";
        }
    }

    public void SetMoveForward()
    {
        currentInput = forwardInput.transform.GetChild(0).GetComponent<Text>();
        lastText = currentInput.text;
        currentInput.text = "Enter Key";
        keyType = "Move_Forward";
        checkForKey = true;
    }

    public void Back()
    {
        SceneManager.LoadScene("Settings", LoadSceneMode.Single);
    }
}
