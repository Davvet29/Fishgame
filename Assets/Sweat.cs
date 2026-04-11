using UnityEngine;
public class Sweat : MonoBehaviour
{
    public float distanceToTravel = 10;
    float distanceTraveled;
    public SpriteRenderer sweatSprite;
    public bool sweatWiped;

    private Color originalColor; 

    void Start()
    {
        originalColor = sweatSprite.color; 
    }

    void Update()
    {
        float alpha = (distanceToTravel - distanceTraveled) / distanceToTravel;
        sweatSprite.color = new Color(originalColor.r, originalColor.g, originalColor.b, Mathf.Clamp01(alpha));

        if (distanceTraveled >= distanceToTravel)
        {
            sweatWiped = true;
        }
    }

    Vector3 lastPosition;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name == "TipPoint")
        {
            if (lastPosition != Vector3.zero)
            {
                distanceTraveled += Vector3.Distance(transform.position, lastPosition);
            }
            lastPosition = collision.transform.position;
        }
    }
}