using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class PlayerPrefs
{
    private static PlayerPrefs playerPrefs;

    private string move_forward = "W";
    private string move_left = "A";
    private string move_down = "S";
    private string move_right = "D";
    private string jump = "Space";
    private string use = "E";
    private string menu = "Escape";

    public string Move_Forward
    {
        get => move_forward;
        set
        {
            if (value == null) return;

            if (value.Length == 1)
                move_forward = value.ToUpper();
            else if(value.Length > 1)
                move_forward = value;
        }
    }
    public string Move_Left
    {
        get => move_left;
        set
        {
            if (value == null) return;

            if (value.Length == 1)
                move_left = value.ToUpper();
            else if (value.Length > 1)
                move_left = value;
        }
    }
    public string Move_Down
    {
        get => move_down;
        set
        {
            if (value == null) return;

            if (value.Length == 1)
                move_down = value.ToUpper();
            else if (value.Length > 1)
                move_down = value;
        }
    }
    public string Move_Right
    {
        get => move_right;
        set
        {
            if (value == null) return;

            if (value.Length == 1)
                move_right = value.ToUpper();
            else if (value.Length > 1)
                move_right = value;
        }
    }
    public string Jump
    {
        get => jump;
        set
        {
            if (value == null) return;

            if (value.Length == 1)
                jump = value.ToUpper();
            else if (value.Length > 1)
                jump = value;
        }
    }

    public string Use
    {
        get => use;
        set
        {
            if (value == null) return;

            if (value.Length == 1)
                use = value.ToUpper();
            else if (value.Length > 1)
                use = value;
        }
    }

    public string Menu
    {
        get => menu;
        set
        {
            if (value == null) return;

            if (value.Length == 1)
                menu = value.ToUpper();
            else if (value.Length > 1)
                menu = value;
        }
    }

    private PlayerPrefs() { }

    public static PlayerPrefs GetInstance()
    {
        if (playerPrefs == null)
            playerPrefs = new PlayerPrefs();

        return playerPrefs;
    }
}
