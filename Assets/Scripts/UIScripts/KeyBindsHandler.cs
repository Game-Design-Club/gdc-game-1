using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


// TODO Add warning when crossing binds.
public class KeyBindsHandler : MonoBehaviour
{
    [SerializeField]
    GameObject forwardInput, backwardInput, upInput, downInput, sprintInput, jumpInput, useInput, menuInput;

    private PlayerPrefs playerPrefs = PlayerPrefs.GetInstance();
    private Text currentInput;
    private bool checkForKey = false;
    private string lastText, keyType;

    // Initializes the current values saved to each key.
    private void Start()
    {
        forwardInput.transform.GetChild(0).GetComponent<Text>().text = "" + playerPrefs.Move_Forward;
        backwardInput.transform.GetChild(0).GetComponent<Text>().text = "" + playerPrefs.Move_Backward;
        upInput.transform.GetChild(0).GetComponent<Text>().text = "" + playerPrefs.Move_Up;
        downInput.transform.GetChild(0).GetComponent<Text>().text = "" + playerPrefs.Move_Down;
        sprintInput.transform.GetChild(0).GetComponent<Text>().text = "" + playerPrefs.Sprint;
        jumpInput.transform.GetChild(0).GetComponent<Text>().text = "" + playerPrefs.Jump;
        useInput.transform.GetChild(0).GetComponent<Text>().text = "" + playerPrefs.Use;
        menuInput.transform.GetChild(0).GetComponent<Text>().text = "" + playerPrefs.Menu;
    }

    // Key Listener to get input from user.
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

    // Sets the key bind to the user's input.
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

        switch(keyType)
        {
            case "Forward":
                playerPrefs.Move_Forward = key;
                currentInput.text = "" + playerPrefs.Move_Forward;
                currentInput = null;
                lastText = "";
                keyType = "";
                break;
            case "Backward":
                playerPrefs.Move_Backward = key;
                currentInput.text = "" + playerPrefs.Move_Backward;
                currentInput = null;
                lastText = "";
                keyType = "";
                break;
            case "Up":
                playerPrefs.Move_Up = key;
                currentInput.text = "" + playerPrefs.Move_Up;
                currentInput = null;
                lastText = "";
                keyType = "";
                break;
            case "Down":
                playerPrefs.Move_Down = key;
                currentInput.text = "" + playerPrefs.Move_Down;
                currentInput = null;
                lastText = "";
                keyType = "";
                break;
            case "Sprint":
                playerPrefs.Sprint = key;
                currentInput.text = "" + playerPrefs.Sprint;
                currentInput = null;
                lastText = "";
                keyType = "";
                break;
            case "Jump":
                playerPrefs.Jump = key;
                currentInput.text = "" + playerPrefs.Jump;
                currentInput = null;
                lastText = "";
                keyType = "";
                break;
            case "Use":
                playerPrefs.Use = key;
                currentInput.text = "" + playerPrefs.Use;
                currentInput = null;
                lastText = "";
                keyType = "";
                break;
            case "Menu":
                playerPrefs.Menu = key;
                currentInput.text = "" + playerPrefs.Menu;
                currentInput = null;
                lastText = "";
                keyType = "";
                break;
            default:
                throw new System.InvalidOperationException("unknown key type");
        }
    }

    // Action listener for input.
    public void SetMoveForward()
    {
        currentInput = forwardInput.transform.GetChild(0).GetComponent<Text>();
        lastText = currentInput.text;
        currentInput.text = "Enter Key";
        keyType = "Forward";
        checkForKey = true;
    }

    // Action listener for input.
    public void SetMoveBackward()
    {
        currentInput = backwardInput.transform.GetChild(0).GetComponent<Text>();
        lastText = currentInput.text;
        currentInput.text = "Enter Key";
        keyType = "Backward";
        checkForKey = true;
    }

    // Action listener for input.
    public void SetMoveUp()
    {
        currentInput = upInput.transform.GetChild(0).GetComponent<Text>();
        lastText = currentInput.text;
        currentInput.text = "Enter Key";
        keyType = "Up";
        checkForKey = true;
    }

    // Action listener for input.
    public void SetMoveDown()
    {
        currentInput = downInput.transform.GetChild(0).GetComponent<Text>();
        lastText = currentInput.text;
        currentInput.text = "Enter Key";
        keyType = "Down";
        checkForKey = true;
    }

    // Action listener for input.
    public void SetSprint()
    {
        currentInput = sprintInput.transform.GetChild(0).GetComponent<Text>();
        lastText = currentInput.text;
        currentInput.text = "Enter Key";
        keyType = "Sprint";
        checkForKey = true;
    }

    // Action listener for input.
    public void SetJump()
    {
        currentInput = jumpInput.transform.GetChild(0).GetComponent<Text>();
        lastText = currentInput.text;
        currentInput.text = "Enter Key";
        keyType = "Jump";
        checkForKey = true;
    }

    // Action listener for input.
    public void SetUse()
    {
        currentInput = useInput.transform.GetChild(0).GetComponent<Text>();
        lastText = currentInput.text;
        currentInput.text = "Enter Key";
        keyType = "Use";
        checkForKey = true;
    }

    // Action listener for input.
    public void SetMenu()
    {
        currentInput = menuInput.transform.GetChild(0).GetComponent<Text>();
        lastText = currentInput.text;
        currentInput.text = "Enter Key";
        keyType = "Menu";
        checkForKey = true;
    }

    // Loads the Settings scene.
    public void Back()
    {
        SceneManager.LoadScene("Settings", LoadSceneMode.Single);
    }
}
