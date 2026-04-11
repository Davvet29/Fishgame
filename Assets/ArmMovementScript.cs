using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class ArmMovementScript : MonoBehaviour
{
    Rigidbody2D rb;
    Vector3 oldMousePos;
    Vector3 newMousePos;
    Vector3 mouseDelta;
    BoxCollider2D cameraBounds;
    float cameraBoundsX;
    float cameraBoundsY;
    bool touchingBorders;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        oldMousePos = Input.mousePosition;

        rb = GetComponent<Rigidbody2D>();
        cameraBounds = Camera.main.GetComponent<BoxCollider2D>();

        cameraBoundsX = cameraBounds.bounds.size.x;
        cameraBoundsY = cameraBounds.bounds.size.y;
    }

    // Update is called once per frame
    void Update()
    {
        ClampObject();
        IsTouchingBorders();

        rb.AddForce(MouseDelta());
    }

    public Vector3 MouseDelta()
    {
        mouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        Mathf.Clamp(mouseDelta.x, -10, 10);
        Mathf.Clamp(mouseDelta.y, -10, 10);

        return mouseDelta * 10;
    }

    public void ClampObject()
    {
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, -cameraBoundsX / 2, cameraBoundsX / 2),
            Mathf.Clamp(transform.position.y, -cameraBoundsY / 2, cameraBoundsY / 2),
            transform.position.z
        );
    }

    public void IsTouchingBorders()
    {
        if (
            transform.position.x < (-cameraBoundsX / 2) + 0.01
            || transform.position.x > (cameraBoundsX / 2) - 0.01
            || transform.position.y < (-cameraBoundsY / 2) + 0.01
            || transform.position.y > (cameraBoundsY / 2) - 0.01 && !touchingBorders
        )
        {
            touchingBorders = true;
            rb.linearVelocity = Vector3.zero;
        }
        else
        {
            touchingBorders = false;
        }
    }
}
