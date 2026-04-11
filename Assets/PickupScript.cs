using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PickupScript : MonoBehaviour
{
    InputAction leftClick;

    GameObject item = null;
    bool itemGrabbed;

    SpriteRenderer sr;

    [SerializeField]
    Sprite normalHand;

    [SerializeField]
    Sprite openGrabHand;

    [SerializeField]
    Sprite closedGrabHand;

    bool horizontalArm = false;

    void Start()
    {
        leftClick = InputSystem.actions.FindAction("Attack");
        sr = GameObject.Find("Hand").GetComponent<SpriteRenderer>();
        MakeHorizontal(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (leftClick.IsPressed())
        {
            itemGrabbed = true;
            if (item != null)
            {
                OnPickup();
            }

            if (horizontalArm)
            {
                sr.sprite = closedGrabHand;
            }
        }
        else
        {
            if (item != null && itemGrabbed == true)
            {
                OnLetGo();
            }
            itemGrabbed = false;

            if (horizontalArm)
            {
                sr.sprite = openGrabHand;
            }
        }
        if (itemGrabbed)
        {
            if (item != null)
            {
                item.transform.position = transform.position;
                if (horizontalArm)
                {
                    item.transform.position += new Vector3(1, -1, 0);
                }
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
            rb.linearVelocity = Vector2.zero;
        }
    }

    public void MakeHorizontal(bool rotate)
    {
        if (rotate)
        {
            transform.rotation = Quaternion.Euler(0, 0, 65);
            sr.sprite = openGrabHand;
            horizontalArm = true;
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 30);
            sr.sprite = normalHand;
            horizontalArm = false;
        }
    }
}
