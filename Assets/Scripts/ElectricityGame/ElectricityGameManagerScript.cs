using Unity.Mathematics;
using UnityEngine;

public class ElectricityGameManagerScript : Minigame
{
    PickupScript pickupScript;

    [SerializeField]
    void Start()
    {
        timeMultiplier = 1;
    }

    void Update()
    {
        baseTime = 5766876;
    }

    public void gameOver(bool won)
    {
        Debug.Log("I won? " + won);
        gameWon = won;
    }
}
