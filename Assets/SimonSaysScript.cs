using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class SimonSaysScript : Minigame
{
    PickupScript pickupScript;

    GameObject CircularBox;
    GameObject TriangleBox;

    GameObject SquareBox;

    GameObject StarBox;

    Queue<int> queue = new();

    [SerializeField]
    void Start()
    {
        timeMultiplier = 1;

        MakeSimonSays(1);
    }

    void Update() { }

    public void gameOver(bool won)
    {
        Debug.Log("I won? " + won);
        gameWon = won;
    }

    private void MakeSimonSays(int times)
    {

        for (int i = 0; i < times; i++)
        {
            int random = Random.Range(1, 5);

        }
    }

    private void NextSimon()
    {
            int current = queue.Dequeue();
            if (current == 1)
            {
                // CircularBox;
            }
            else if (current == 2)
            {
                // TriangleBox
            }
            else if (current == 3)
            {
                // SquareBox
            }
            else if (current == 4)
            {
                // StarBox;
            }
    }
}
