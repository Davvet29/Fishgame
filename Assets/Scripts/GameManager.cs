using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int lives;

    public List<string> minigames;
    public List<Minigame> minigameScripts;

    public VoicePlayer player;

    public float timeMultiplier;

    float timeToWait;

    enum GameState
    {

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    
    }

    

    // Update is called once per frame
    void Update()
    {
        if (timeToWait != 0)
        {
            timeToWait -= Time.deltaTime;

            if (timeToWait < 0)
            {
                timeToWait = 0;
                NextGame();
            }
        }
    }

    public void OnGameEnd(bool won)
    {
        if (!won)
        {
            lives--;
            if (lives == 0)
            {
                HandleGameEnd(VoicePlayer.AudioClips.GAMEOVER);
                return;
            }

            HandleGameEnd(VoicePlayer.AudioClips.LOSECLIP);
        }
        else
        {
            HandleGameEnd(VoicePlayer.AudioClips.WINCLIP);
        }
    }

    void HandleGameEnd(VoicePlayer.AudioClips clip)
    {
        if (clip == VoicePlayer.AudioClips.GAMEOVER)
        {
            player.PlayAudio(clip);
            //Do gameover logic
            return;
        }
        timeToWait = player.PlayAudio(clip);
    }

    void NextGame()
    {
        int selectedGame = Random.Range(0, minigames.Count); //i think its right;

        SceneManager.LoadScene(minigames[selectedGame], LoadSceneMode.Additive);

        GameObject.Find(minigames[selectedGame]).GetComponent<Minigame>().gameManager = this;
        GameObject.Find(minigames[selectedGame]).GetComponent<Minigame>().timeMultiplier = this.timeMultiplier;




    }

    void GameOver()
    {

    }
}
