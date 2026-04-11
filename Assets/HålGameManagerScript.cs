using UnityEngine;

public class HålGameManagerScript : Minigame
{
    PickupScript pickupScript;

    void Start()
    {
        pickupScript = GameObject.Find("TipPoint").GetComponent<PickupScript>();
        pickupScript.MakeHorizontal(true);
    }

    public void gameOver(bool won)
    {
        gameManager.OnGameEnd(won);
    }

    public HålGameManagerScript(float timeMultiplier, GameManager gameManager)
        : base(timeMultiplier, gameManager) { }
}
