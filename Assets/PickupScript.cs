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
            if (item != null)
            {
                OnPickup();
            }

        }
        else
        {
            if (item != null && itemGrabbed == true)
            {
                OnLetGo();
            }
            itemGrabbed = false;
        }
        if (itemGrabbed)
        {
            if (item != null)
            {
                item.transform.position = transform.position;
            }
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
        if (item.TryGetComponent(out Rigidbody2D rb))
        {
            rb.gravityScale = 0;
        }
    }

    void OnLetGo()
    {
        if (item.TryGetComponent(out Rigidbody2D rb))
        {
            rb.gravityScale = 1;
        }
    }
}
