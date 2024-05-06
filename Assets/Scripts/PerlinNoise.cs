using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinNoise : MonoBehaviour {
    [SerializeField]
    private int perlinWidth;
    [SerializeField]
    private int perlinHeight;

    [SerializeField]
    [Range(1, 10)]
    private float perlinScale;

    /*       -=TODO=-
     * Make code more my own
     * implement seed system
     * understand/find alternate for (float)x/y
     * research fractal noise, octaves, lacunarity, persistence
     * 
     */

    private void Start() {
        Renderer meshRenderer = GetComponent<Renderer>();
        meshRenderer.sharedMaterial.mainTexture = GenerateNoise();
    }

    public void UpdateNoise() {
        Renderer meshRenderer = GetComponent<Renderer>();
        meshRenderer.sharedMaterial.mainTexture = GenerateNoise();
    }

    private void OnValidate() {
        UpdateNoise();
    }


    public Texture2D GenerateNoise() {
        Texture2D texture = new(perlinWidth, perlinHeight);

        int prng = Random.Range(0, 10000);

        for (int y = 0; y < perlinHeight; y++) {
            for (int x = 0; x < perlinWidth; x++) {
                float xCoord = (float)x / perlinWidth * perlinScale;
                float yCoord = (float)y / perlinHeight * perlinScale;

                float sample = Mathf.PerlinNoise(xCoord + prng, yCoord + prng);
                Color color = new(sample, sample, sample);
                texture.SetPixel(x, y, color);
            }
        }

        texture.Apply();
        return texture;
    }
}
