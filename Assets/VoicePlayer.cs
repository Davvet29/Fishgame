using System.Collections.Generic;
using UnityEngine;

public class VoicePlayer : MonoBehaviour
{
    public AudioClip introClip;
    public AudioClip gameOverClip;

    public List<AudioClip> winClips;
    public List<AudioClip> loseClips;

    public AudioSource source;

    public enum AudioClips
    {
        INTRO,
        GAMEOVER,
        WINCLIP,
        LOSECLIP
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float PlayAudio(AudioClips clip)
    {
        if (clip == AudioClips.INTRO)
        {
            source.clip = introClip;
        }
        else if (clip == AudioClips.GAMEOVER)
        {
            source.clip = gameOverClip;
        }
        else if (clip == AudioClips.WINCLIP)
        {
            source.clip = winClips[Random.Range(0, winClips.Count)];
        }
        else if (clip == AudioClips.LOSECLIP)
        {
            source.clip = winClips[Random.Range(0, loseClips.Count)];
        }

        source.Play();


        return source.clip.length;

    }
}