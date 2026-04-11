using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class DrawLetters : Minigame
{
    public float pointConfirmDistance;
    public float winPercent;

    public List<GameObject> splineHolders;
    public GameObject pen;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckCondition();
    }

    protected override void CheckCondition()
    {
        int confirmedPoints = 0;
        List<Vector3> drawnPoints = pen.GetComponent<Pen>().drawnPoints;

        foreach (GameObject splineHolder in splineHolders)
        {
            SplineContainer splineContainer = splineHolder.GetComponent<SplineContainer>();

            for (int i = 0; i < 100; i++)
            {
                Vector3 splinePoint = (Vector3)splineContainer.EvaluatePosition((float)i / 100f);
                float lastDistance = float.MaxValue;

                foreach (Vector3 drawnPoint in drawnPoints)
                {
                    float dist = Vector3.Distance(splinePoint, drawnPoint); 
                    if (dist < lastDistance)
                    {
                        lastDistance = dist; 
                    }
                }

                if (lastDistance < pointConfirmDistance)
                {
                    confirmedPoints++;
                }
            }
        }

        Debug.Log("Confirmed points: " + confirmedPoints);

        if (confirmedPoints >= winPercent)
        {
            gameWon = true;
        }
    }

    protected override void OnGameStart()
    {
        
    }
}
