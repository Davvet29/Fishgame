using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameScript : MonoBehaviour
{
    public bool startGame = false;
    void Update()
    {
        if(startGame == true)
        {
            StartGame();
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene("MainScene1");
    }
}
