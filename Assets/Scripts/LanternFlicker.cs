using UnityEngine;

public class LanternFlicker : MonoBehaviour {
    public float flickerAmount = 0.55f;
    public float flickerSpeed = 12f;
    public float dropoutGap = 3f;
    public float dropoutLength = 0.2f;
    public float dropoutDip = 0.1f;

    private Light lantern;
    private float baseIntensity;
    private float noiseOffset;
    private float dropoutTimer;
    private float dropoutLeft;
    private float currentDip;

    private void Start() {
        lantern = GetComponent<Light>();
        baseIntensity = lantern.intensity;
        // without this every lantern flickers on the same beat and it looks fake
        noiseOffset = Random.Range(0f, 100f);
        // and this stops all nine from cutting out on the same frame at startup
        dropoutTimer = Random.Range(0f, dropoutGap);
    }

    private void Update() {
        float noise = Mathf.PerlinNoise(noiseOffset + Time.time * flickerSpeed, 0f);
        float level = 1f - flickerAmount + noise * flickerAmount;

        if (dropoutLeft > 0f) {
            dropoutLeft -= Time.deltaTime;
            level *= currentDip;
        } else {
            dropoutTimer -= Time.deltaTime;
            if (dropoutTimer <= 0f) {
                dropoutLeft = dropoutLength * Random.Range(0.5f, 1f);
                dropoutTimer = dropoutGap * Random.Range(0.5f, 1.5f);
                // some go almost black and some only dip, otherwise you start seeing a pattern
                currentDip = Random.Range(0f, dropoutDip);
            }
        }

        lantern.intensity = baseIntensity * level;
    }
}
