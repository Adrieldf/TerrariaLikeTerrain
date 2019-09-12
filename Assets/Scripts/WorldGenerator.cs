using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGenerator : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    private GameObject GrassPrefab = null;
    [SerializeField]
    private GameObject DirtPrefab = null;
    [SerializeField]
    private GameObject StonePrefab = null;
    [SerializeField]
    private int ChunkSize = 32;
    [SerializeField]
    private int Smoothness = 15;
    [SerializeField]
    private float MapSeed = 0;
    #endregion


    void Start()
    {
        MapSeed = Random.Range(-1000f, 1000f);
        GenerateChunk();
    }


    private void GenerateChunk()
    {
        int chunkHeight = 0;
        for (int i = 0; i < ChunkSize; i++)
        {
            int totalHeight = Mathf.RoundToInt(Mathf.PerlinNoise(MapSeed, i / Smoothness) * ChunkSize) + chunkHeight;

            for (int j = 0; j < totalHeight; j++)
            {
                Instantiate(GetHeightPrefab(j, totalHeight), new Vector3(i, j), Quaternion.identity);
            }
        }

    }
    private GameObject GetHeightPrefab(int height, int maxHeight)
    {
        return DirtPrefab;
    }
}
