using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour {
  Terrain terrain;

  [Range(0, 10)]
  public int depth = 20;
  public int width = 128;
  public int height = 128;

  [Range(0.5f, 20f)]
  public float scale = 20f;

  public float offSetX = 100f;
  public float offSetY = 100f;

  // Start is called before the first frame update
  void Start() {
    terrain = GetComponent<Terrain>();
    terrain.terrainData = GenerateTerrain(terrain.terrainData);
  }

  public void UpdateTerrain() {
    terrain = GetComponent<Terrain>();
    terrain.terrainData = GenerateTerrain(terrain.terrainData);
  }

  TerrainData GenerateTerrain(TerrainData terrainData) {
    terrainData.heightmapResolution = width + 1;

    terrainData.size = new Vector3(width, depth, height);
    terrainData.SetHeights(0, 0, GenerateHeights());
    return terrainData;
  }

  float[,] GenerateHeights() {
    float[,] heights = new float[width, height];

    for (int x = 0; x < width; x++) {
      for (int y = 0; y < height; y++) {
        heights[x, y] = CalculateHeight(x, y);
      }
    }
    return heights;
  }

  float CalculateHeight(int x, int y) {
    float xCoord = ((float)x / width) * scale + offSetX;
    float yCoord = ((float)y / height) * scale + offSetY;

    float sample = Mathf.PerlinNoise(xCoord, yCoord);

    return sample;
  }
}
