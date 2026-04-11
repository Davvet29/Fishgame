using UnityEngine;
using UnityEngine.Rendering;

public class CircleScript : MonoBehaviour
{
    SimonSaysScript SSS;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SSS = GameObject.Find("SimonSays").GetComponent<SimonSaysScript>();
    }

    // Update is called once per frame
    void Update() { }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision + " has touched me");
        if (collision.tag == "Player")
        {
            Debug.Log("officially touched");
            SSS.NextSimon();
            gameObject.SetActive(false);
        }
    }
}
