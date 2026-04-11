using System.Collections.Generic;
using UnityEngine;

public class Pen : MonoBehaviour
{
    public List<Vector3> drawnPoints;

    public float drawInterval;

    public GameObject drawPoint;

    public GameObject penPoint;

    float passedTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        passedTime += Time.deltaTime;
        if (passedTime > drawInterval)
        {
            passedTime = 0;

            drawnPoints.Add(Instantiate(drawPoint, penPoint.transform.position, transform.rotation).transform.position);

        }
    }
}
