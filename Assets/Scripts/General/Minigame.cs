using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Minigame : MonoBehaviour
{
    public float baseTime;
    public string sceneName;
    protected bool gameWon;

    public float timeMultiplier;
    private float gameTime;

    public float timePassed = 0;

    public GameManager gameManager; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {
        OnGameStart();
        gameTime = baseTime * timeMultiplier;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        timeMultiplier = gameManager.timeMultiplier;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        timePassed += Time.deltaTime;
        if (timePassed > gameTime)
        {
            EndGame(gameWon);
            timePassed = 0;
        }

        GameObject.Find("Timer").transform.GetChild(0).GetComponent<Slider>().maxValue = gameTime;
        GameObject.Find("Timer").transform.GetChild(0).GetComponent<Slider>().value = timePassed;
    }

    protected virtual void CheckCondition()
    {

    }

    void EndGame(bool won)
    {
        gameManager.OnGameEnd(won);
        SceneManager.LoadScene("MainScene");
    }

    protected virtual void OnGameStart()
    {
    }

    
}
