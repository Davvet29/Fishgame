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

    float timeMultiplierDelta = 0.025f;

    bool gameOver;

    enum GameState { }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        HandleGameEnd(VoicePlayer.AudioClips.INTRO);

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (timeToWait != 0)
        {
            timeToWait -= Time.deltaTime;

            if (gameOver && timeToWait < 0)
            {
                SceneManager.LoadScene("Creditsscene");
            }
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

        timeMultiplier -= timeMultiplierDelta;
    }

    void HandleGameEnd(VoicePlayer.AudioClips clip)
    {
        if (clip == VoicePlayer.AudioClips.GAMEOVER)
        {
            player.PlayAudio(clip);
            gameOver = true;
        }
        timeToWait = player.PlayAudio(clip);
    }

    int lastGameNum;

    void NextGame()
    {
        int selectedGame = 1000;
        while (selectedGame == lastGameNum || selectedGame == 1000)
        {
            selectedGame = Random.Range(0, minigames.Count); //i think its right;
        }

        SceneManager.LoadScene(minigames[selectedGame]);
        lastGameNum = selectedGame;
    }
}
