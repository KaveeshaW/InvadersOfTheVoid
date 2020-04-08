using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameOver : MonoBehaviour
{
    public void Retry() {
        SceneManager.LoadScene("kaveesha");
    }
    public void QuitGame() {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
