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

    void Start()
    {
        summonPosition = GameObject.Find("SummonPosition").transform.position;
        InstanceShape(UnityEngine.Random.Range(1, 4));

        timeMultiplier = 1;
    }

    void Update()
    {
        baseTime = 5766876;
    }

    public void gameOver(bool won)
    {
        gameManager.OnGameEnd(won);
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
