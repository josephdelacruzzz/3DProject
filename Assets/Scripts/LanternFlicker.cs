using UnityEngine;

public class LanternFlicker : MonoBehaviour {
    public float flickerAmount = 0.25f;
    public float flickerSpeed = 7f;

    private Light lantern;
    private float baseIntensity;
    private float noiseOffset;

    private void Start() {
        lantern = GetComponent<Light>();
        baseIntensity = lantern.intensity;
        // without this every lantern flickers on the same beat and it looks fake
        noiseOffset = Random.Range(0f, 100f);
    }

    private void Update() {
        float noise = Mathf.PerlinNoise(noiseOffset + Time.time * flickerSpeed, 0f);
        lantern.intensity = baseIntensity * (1f - flickerAmount + noise * flickerAmount);
    }
}
