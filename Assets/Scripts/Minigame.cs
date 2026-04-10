using UnityEngine;
using UnityEngine.SceneManagement;

public class Minigame : MonoBehaviour
{
    protected float baseTime;
    public string sceneName;
    protected bool gameWon;

    private float timeMultiplier;
    private float gameTime;

    private float timePassed;

    private GameManager gameManager; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timePassed > gameTime)
        {
            EndGame(gameWon);
        }
    }

    public Minigame(float timeMultiplier, GameManager gameManager)
    {
        gameTime = timeMultiplier * baseTime;
        this.gameManager = gameManager;
    }

    void EndGame(bool won)
    {
        SceneManager.UnloadSceneAsync(sceneName);
        gameManager.OnGameEnd(won);
    }

    
}
