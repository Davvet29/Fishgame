using UnityEngine;
using UnityEngine.SceneManagement;

public class Minigame : MonoBehaviour
{
    protected float baseTime;
    public string sceneName;
    protected bool gameWon;

    public float timeMultiplier;
    private float gameTime;

    private float timePassed = 0;

    public GameManager gameManager; 

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
