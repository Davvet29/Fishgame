using UnityEngine;
using UnityEngine.Events;

public class CheckShapeScript : MonoBehaviour
{
    [SerializeField]
    string shapeName;
    HålGameManagerScript HGMS;

    void Start()
    {
        HGMS = GameObject.Find("HålGameManager").GetComponent<HålGameManagerScript>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Item" && collision.name == shapeName)
        {
            Debug.Log("WIN!");
            HGMS.gameOver(true);
        }
        if (collision.tag == "Item" && collision.name != shapeName)
        {
            Debug.Log("LOSE!");
            HGMS.gameOver(false);
        }
    }
}
