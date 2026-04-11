using System.Collections.Generic;
using UnityEngine;

public class DrawLetters : Minigame
{
    public float pointConfirmDistance;
    public float winPercent;

    public 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckCondition();
    }

    public DrawLetters(float timeMultiplier, GameManager gameManager) : base(timeMultiplier, gameManager)
    {

    }

    protected override void CheckCondition()
    {
        
    }

    protected override void OnGameStart()
    {
        
    }
}
