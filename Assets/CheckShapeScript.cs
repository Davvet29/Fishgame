using UnityEngine;

public class CheckShapeScript : MonoBehaviour
{
    [SerializeField]
    string shapeName;
    GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Item" && collision.name == shapeName)
        {
            gameManager.OnGameEnd(true);
        }
        if (collision.tag == "Item" && collision.name != shapeName)
        {
            gameManager.OnGameEnd(false);
        }
    }
}
