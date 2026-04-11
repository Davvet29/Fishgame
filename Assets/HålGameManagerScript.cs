using UnityEngine;

public class HålGameManagerScript : Minigame
{
    PickupScript pickupScript;

    [SerializeField]
    GameObject square;
    [SerializeField]
    GameObject triangle;
    [SerializeField]
    GameObject circle;

    void Start()
    {

        pickupScript = GameObject.Find("TipPoint").GetComponent<PickupScript>();
        pickupScript.MakeHorizontal(true);

        InstanceShape(Random.Range(1,4));
    }

    public void gameOver(bool won)
    {
        gameManager.OnGameEnd(won);
    }

    public void InstanceShape(int shapeNumber)
    {
        if(shapeNumber == 1)
        {

        }
        else if (shapeNumber == 2)
        {
            
        }
        else
        {
            
        }
    }

    public HålGameManagerScript(float timeMultiplier, GameManager gameManager)
        : base(timeMultiplier, gameManager) { }
}
