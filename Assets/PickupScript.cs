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
            OnPickup();
        }
        else
        {
            itemGrabbed = false;
            OnLetGo();
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

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Item")
        {
            item = null;
        }
    }

    void OnPickup()
    {
        item.GetComponent<Rigidbody2D>().gravityScale = 0;
    }

    void OnLetGo()
    {
        item = null;
        item.GetComponent<Rigidbody2D>().gravityScale = 1;

    }
}
