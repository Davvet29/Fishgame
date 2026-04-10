using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int lives;

    public List<Minigame> minigames;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnGameEnd(bool won)
    {
        if (!won)
        {
            lives--;
            if (lives == 0)
            {
                GameOver();
                return;
            }

            HandleGameEnd();
        }
        else
        {
            HandleGameEnd();
        }
    }

    void HandleGameEnd()
    {
        //Do cutscene etc

        NextGame();
    }

    void NextGame()
    {
        int selectedGame = Random.Range(0, minigames.Count); //i think its right;

        SceneManager.LoadScene(minigames[selectedGame].sceneName, LoadSceneMode.Additive);

    }

    void GameOver()
    {

    }
}
