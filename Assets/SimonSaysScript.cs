using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class SimonSaysScript : Minigame
{
    PickupScript pickupScript;

    [SerializeField]
    GameObject CircularBox;

    [SerializeField]
    GameObject TriangleBox;

    [SerializeField]
    GameObject SquareBox;

    [SerializeField]
    GameObject StarBox;

    Queue<int> queue = new();

    [SerializeField]
    protected override void Start()
    {
        MakeSimonSays(5);
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }

    public void gameOver(bool won)
    {
        Debug.Log("I won? " + won);
        gameWon = won;
        timePassed = 100;

    }

    private void MakeSimonSays(int times)
    {
        int lastNumber = 0;
        for (int i = 0; i < times; i++)
        {
            int random = Random.Range(1, 5);
            while(random == lastNumber)
            {
                random = Random.Range(1, 5);
            }
            queue.Enqueue(random);
            lastNumber = random;
            Debug.Log("Added " + random);
        }
        NextSimon();
    }

    public void NextSimon()
    {
        Debug.Log("current queue count " + queue.Count);

        if (queue.Count >= 1)
        {
            int current = queue.Dequeue();
            Debug.Log("current in queue " + current);
            if (current == 1)
            {
                CircularBox.SetActive(true);
            }
            else if (current == 2)
            {
                TriangleBox.SetActive(true);
            }
            else if (current == 3)
            {
                SquareBox.SetActive(true);
            }
            else if (current == 4)
            {
                StarBox.SetActive(true);
            }
        }
        else if (queue.Count == 0)
        {
            Debug.Log("YOU WIN!");
            gameWon = true;
        }
    }
}
