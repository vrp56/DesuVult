﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PausePage : OptionsPage
{
    public Text ActiveQuestsText, CompletedQuestsText;

    void OnEnable()
    {
        // ActiveQuestsText.text = Get the active quests
        // CompletedQuestsText.text = Get the number of completed quests
        
        Time.timeScale = 0;

        Initialize();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Unpause()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        gameObject.SetActive(false);
    }
}
