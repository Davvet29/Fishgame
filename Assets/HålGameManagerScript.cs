using UnityEngine;

public class HålGameManagerScript : MonoBehaviour
{

    GameManager gameManager;
    PickupScript pickupScript;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        pickupScript = GameObject.Find("TipPoint    ").GetComponent<PickupScript>();

    }

    // Update is called once per frame
    void Update()
    {
        pickupScript.MakeHorizontal(true);
    }
}
