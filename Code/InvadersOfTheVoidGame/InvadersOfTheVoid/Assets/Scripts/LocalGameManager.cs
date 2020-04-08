using UnityEngine;
using UnityEngine.SceneManagement;
public class LocalGameManager : MonoBehaviour
{
    public void YouWin() {
        Debug.Log("YOU WIN");
        //Restart();
    }

    void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
