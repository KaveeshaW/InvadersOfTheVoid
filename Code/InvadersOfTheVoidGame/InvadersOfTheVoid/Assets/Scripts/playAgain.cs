﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playAgain : MonoBehaviour
{
    public void PlayAgain() {
        SceneManager.LoadScene("Main_Menu");
    }

    public void QuitGame() {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
