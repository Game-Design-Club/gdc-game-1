using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerPrefs
{
    private static PlayerPrefs playerPrefs;

    private KeyCode move_up = KeyCode.W;
    private KeyCode move_backward = KeyCode.A;
    private KeyCode move_down = KeyCode.S;
    private KeyCode move_forward = KeyCode.D;
    private KeyCode sprint = KeyCode.LeftShift;
    // TODO Fix jump so you can enter space as a key code in the key binds handler.
    private KeyCode jump = KeyCode.Space;
    private KeyCode use = KeyCode.E;
    private KeyCode menu = KeyCode.Escape;

    public KeyCode Move_Up
    {
        get => move_up;
        set => move_up = isValid(value) ? value : move_up;
    }

    public KeyCode Move_Backward
    {
        get => move_backward;
        set => move_backward = isValid(value) ? value : move_backward;
    }

    public KeyCode Move_Down
    {
        get => move_down;
        set => move_down = isValid(value) ? value : move_down;
    }

    public KeyCode Move_Forward
    {
        get => move_forward;
        set => move_forward = isValid(value) ? value : move_forward;
    }

    public KeyCode Sprint
    {
        get => sprint;
        set => sprint = isValid(value) ? value : sprint;
    }

    public KeyCode Jump
    {
        get => jump;
        set => jump = isValid(value) ? value : jump;
    }

    public KeyCode Use
    {
        get => use;
        set => use = isValid(value) ? value : use;
    }

    public KeyCode Menu
    {
        get => menu;
        set => menu = isValid(value) ? value : menu;
    }

    private bool isValid(KeyCode key)
    {
        return (key != Move_Up && key != Move_Backward && key != Move_Down && key != Move_Forward && key != Sprint && key != Jump && key != Use && key != Menu);
    }

    private PlayerPrefs() { }

    public static PlayerPrefs GetInstance()
    {
        if (playerPrefs == null)
            playerPrefs = new PlayerPrefs();

        return playerPrefs;
    }
}
