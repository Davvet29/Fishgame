using UnityEngine;

public class SweatWipe : Minigame
{
    public Sweat sweat;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        
    }

    // Update is called once per frame
    protected override void Update()
    {
        if (sweat.sweatWiped)
        {
            gameWon = true;
            timePassed = 100;
        }
    }
}
