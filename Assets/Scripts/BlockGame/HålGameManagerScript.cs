using Unity.Mathematics;
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

    Vector3 summonPosition;

    protected override void Start()
    {
        base.Start();
        summonPosition = GameObject.Find("SummonPosition").transform.position;
        InstanceShape(UnityEngine.Random.Range(1, 4));

        timeMultiplier = 1;
    }

    protected override void Update()
    {
        base.Update();
    }

    public void gameOver(bool won)
    {
        gameWon = won;
        timePassed = 100;
    }

    public void InstanceShape(int shapeNumber)
    {
        if (shapeNumber == 1)
        {
            Instantiate(square, summonPosition, quaternion.identity);
        }
        else if (shapeNumber == 2)
        {
            Instantiate(triangle, summonPosition, quaternion.identity);
        }
        else
        {
            Instantiate(circle, summonPosition, quaternion.identity);
        }
    }
}
