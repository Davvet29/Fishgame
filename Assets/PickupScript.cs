using UnityEngine;
using UnityEngine.InputSystem;

public class PickupScript : MonoBehaviour
{
    InputAction leftClick;
    InputAction rightClick;

    GameObject item = null;
    bool itemGrabbed;

    void Start()
    {
        leftClick = InputSystem.actions.FindAction("Attack");
    }

    // Update is called once per frame
    void Update()
    {
        if (leftClick.IsPressed())
        {
            Debug.Log("isClicking");
            itemGrabbed = true;
        }
        else
        {
            itemGrabbed = false;
        }
        if (itemGrabbed)
        {
            item.transform.position = transform.position;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Item")
        {
            Debug.Log("FOUND ITEM!!");
            item = collision.gameObject;
        }
    }
}
