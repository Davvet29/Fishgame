using UnityEngine;

public class BounceScript : MonoBehaviour
{
    public float bounceAmount = 0.1f;   // how strong the bounce is
    public float smoothSpeed = 10f;     // smoothing

    private AudioSource audioSource;
    private Vector3 baseScale;

    private float[] samples = new float[256];

    void Start()
    {
        audioSource = GameObject.Find("Audio player").GetComponent<AudioSource>();
        baseScale = transform.localScale;
    }

    void Update()
    {
        float volume = GetVolume();

        // squash & stretch
        Vector3 targetScale = baseScale + new Vector3(volume * bounceAmount, -volume * bounceAmount, 0);

        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.deltaTime * smoothSpeed);
    }

    float GetVolume()
    {
        audioSource.GetOutputData(samples, 0);

        float sum = 0f;
        for (int i = 0; i < samples.Length; i++)
        {
            sum += samples[i] * samples[i];
        }

        return Mathf.Sqrt(sum / samples.Length); // RMS volume
    }
}
