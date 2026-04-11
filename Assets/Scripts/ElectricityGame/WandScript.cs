using UnityEngine;

public class WandScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    ElectricityGameManagerScript electricityGameManager;

    void Start()
    {
        electricityGameManager = GameObject
            .Find("ElectricityGameManager")
            .GetComponent<ElectricityGameManagerScript>();
    }

    // Update is called once per frame
    void Update() { }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision);
        if (collision.tag == "Win")
        {
            electricityGameManager.gameOver(true);
        }
        else if (collision.tag == "Lose")
        {
            electricityGameManager.gameOver(false);
        }
    }
}
