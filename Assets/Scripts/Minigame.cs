using UnityEngine;
using UnityEngine.SceneManagement;

public class Minigame : MonoBehaviour
{
    protected float baseTime;
    public string sceneName;
    protected bool gameWon;

    protected float timeMultiplier;
    private float gameTime;

    private float timePassed = 0;

    protected GameManager gameManager; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
        if (timePassed > gameTime)
        {
            EndGame(gameWon);
            timePassed = 0;
        }
    }

    public Minigame(float timeMultiplier, GameManager gameManager)
    {
        gameTime = timeMultiplier * baseTime;
        this.gameManager = gameManager;
    }

    protected virtual void CheckCondition()
    {

    }

    void EndGame(bool won)
    {
        SceneManager.UnloadSceneAsync(sceneName);
        gameManager.OnGameEnd(won);
    }

    protected virtual void OnGameStart()
    {

    }

    
}
