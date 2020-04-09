using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchToMainMenu : MonoBehaviour
{
    //Switches the scene to the main menu
    public void switchSceneToMM()
    {
        SceneManager.LoadScene(sceneName: "Main_Menu");
    }
}
