using UnityEngine;
using UnityEngine.Events;

public class CheckShapeScript : MonoBehaviour
{
    [SerializeField]
    string shapeName;
    HålGameManagerScript HGMS;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Item" && collision.name == shapeName)
        {
            HGMS.gameOver(true);
        }
        if (collision.tag == "Item" && collision.name != shapeName)
        {
            HGMS.gameOver(false);
        }
    }
}
