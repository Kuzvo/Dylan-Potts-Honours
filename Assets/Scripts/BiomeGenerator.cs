using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiomeGenerator : MonoBehaviour {
    public static BiomeType[] biomes;

    static BiomeGenerator() {
        biomes = new BiomeType[]
        {

            new BiomeType { name = "Land", height = 1.0f, minTemperature = 0.0f, maxTemperature = 0.0f, colour = new Color(0.5f, 0.5f, 0.5f) },
            new BiomeType { name = "Desert", height = 0.9f, minTemperature = 0.05f, maxTemperature = 0.2f, colour = new Color(0.8f, 0.7f, 0.4f) },
            new BiomeType { name = "Grassland", height = 0.8f, minTemperature = 0.21f, maxTemperature = 0.3f, colour = new Color(0.4f, 0.6f, 0.2f) },
            new BiomeType { name = "Forest", height = 0.7f, minTemperature = 0.31f, maxTemperature = 0.4f, colour = new Color(0.1f, 0.5f, 0.1f) },
            new BiomeType { name = "Savanna", height = 0.6f, minTemperature = 0.41f, maxTemperature = 0.5f, colour = new Color(0.8f, 0.5f, 0.5f) },
            new BiomeType { name = "Aquatic", height = 0.5f, minTemperature = 0.51f, maxTemperature = 0.6f, colour = new Color(0.0f, 0.1f, 0.5f) },
            new BiomeType { name = "Taiga", height = 0.4f, minTemperature = 0.61f, maxTemperature = 0.7f, colour = new Color(0.8f, 0.8f, 1.0f) },
            new BiomeType { name = "Tropics", height = 0.3f, minTemperature = 0.71f, maxTemperature = 0.8f, colour = new Color(0.8f, 1.0f, 0.8f) },
            new BiomeType { name = "Mangrove", height = 0.2f, minTemperature = 0.81f, maxTemperature = 0.9f, colour = new Color(1.0f, 1.0f, 0.2f) },
            new BiomeType { name = "Tundra", height = 0.1f, minTemperature = 0.91f, maxTemperature = 1.0f, colour = new Color(1.0f, 1.0f, 1.0f) }
        };
    }

    public static int[,] GenerateBiomeMap(float[,] noiseMap) {
        int width = noiseMap.GetLength(0);
        int height = noiseMap.GetLength(1);
        int[,] biomeMap = new int[width, height];

        for (int y = 0; y < height; y++) {
            for (int x = 0; x < width; x++) {
                float temperature = Mathf.Abs((float)x / width - 0.5f) + Mathf.Abs((float)y / height - 0.5f);

                biomeMap[x, y] = AssignBiomeType(noiseMap[x, y], temperature);
            }
        }

        return biomeMap;
    }

    public static int AssignBiomeType(float noiseValue, float temperature) {
        for (int i = 0; i < biomes.Length; i++) {
            BiomeType biome = biomes[i];
            if (noiseValue <= biome.height && temperature >= biome.minTemperature && temperature <= biome.maxTemperature) {
                return i;
            }
        }

        return 0;
    }
}

[System.Serializable]
public struct BiomeType {
    public string name;
    public float height;
    public float minTemperature;
    public float maxTemperature;
    public float minMoisture;
    public float maxMoisture;
    public Color colour;
}
