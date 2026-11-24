using UnityEngine;

public class OrbGlow : MonoBehaviour {
    public float spinSpeed = 45f;
    public float bobHeight = 0.15f;
    public float bobSpeed = 1.5f;
    public float pulseSpeed = 2f;

    private Light orbLight;
    private Material orbMaterial;
    private Color emissionColor;
    private float baseIntensity;
    private Vector3 startPos;

    private void Start() {
        startPos = transform.localPosition;

        orbLight = GetComponentInChildren<Light>();
        if (orbLight != null) {
            baseIntensity = orbLight.intensity;
        }

        Renderer orbRenderer = GetComponentInChildren<Renderer>();
        if (orbRenderer != null) {
            // .material and not .sharedMaterial, otherwise all six pulse as one
            orbMaterial = orbRenderer.material;
            emissionColor = orbMaterial.GetColor("_EmissionColor");
        }
    }

    private void Update() {
        transform.Rotate(0f, spinSpeed * Time.deltaTime, 0f);
        transform.localPosition = startPos + Vector3.up * (Mathf.Sin(Time.time * bobSpeed) * bobHeight);

        float pulse = 0.65f + 0.35f * Mathf.Sin(Time.time * pulseSpeed);
        if (orbLight != null) {
            orbLight.intensity = baseIntensity * pulse;
        }
        if (orbMaterial != null) {
            orbMaterial.SetColor("_EmissionColor", emissionColor * pulse);
        }
    }
}
