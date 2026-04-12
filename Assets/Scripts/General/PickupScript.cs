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
    Sprite closedNormalHand;

    [SerializeField]
    Sprite openGrabHand;

    [SerializeField]
    Sprite closedGrabHand;

    [SerializeField]
    bool horizontalArm = false;
    GameObject holdPos;

    public Sprite penSprite;

    void Start()
    {
        leftClick = InputSystem.actions.FindAction("Attack");
        sr = GameObject.Find("Hand").GetComponent<SpriteRenderer>();
        holdPos = GameObject.Find("HoldingPosition");

        if (horizontalArm)
        {
            MakeHorizontal(true);
        }
        else
        {
            MakeHorizontal(false);
        }
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
            else
            {
                sr.sprite = closedNormalHand;
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
            else
            {
                sr.sprite = normalHand;
            }
        }
        if (itemGrabbed)
        {
            if (item != null)
            {
                item.transform.position = transform.position;
                if (horizontalArm)
                {
                    item.transform.position = holdPos.transform.position;
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

            if (item.name == "Pen")
            {

            }
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
            Debug.Log(sr.sprite);
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
