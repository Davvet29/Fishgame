using Unity.Mathematics;
using UnityEngine;

public class ElectricityGameManagerScript : Minigame
{
    PickupScript pickupScript;

    [SerializeField]
    protected override void Start()
    {
        base.Start();
        timeMultiplier = 1;
    }

    protected override void Update() 
    {
        base.Update();
    }

    public void gameOver(bool won)
    {
        Debug.Log("I won? " + won);
        gameWon = won;
    }
}
