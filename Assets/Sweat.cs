using UnityEngine;

public class Sweat : MonoBehaviour
{
    public float distanceToTravel = 10;
    float distanceTraveled;

    public SpriteRenderer sweatSprite;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        sweatSprite.color = new Vector4(sweatSprite.color.r, sweatSprite.color.b, sweatSprite.color.g, (distanceToTravel - distanceTraveled) / 10);
    }

    Vector3 lastPosition;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name == "TipPoint")
        {
            Debug.Log("Tip point");
            if (lastPosition != Vector3.zero)
            {
                distanceTraveled += Mathf.Abs(Vector3.Distance(transform.position, lastPosition));
            }
            lastPosition = collision.transform.position;
        }
    }
}
