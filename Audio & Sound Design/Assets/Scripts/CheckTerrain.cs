using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTerrain : MonoBehaviour
{

    public Transform playerTransform;
    public Terrain terrainObject;
    public float[] cellMix;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = gameObject.transform;
    }

    void Update()
    {
        UpdatePosition();
    }

    public void UpdatePosition()
    {
        Vector3 terrainPosition = playerTransform.position - terrainObject.transform.position;
        TerrainData tData = terrainObject.terrainData;

        int mapX = Mathf.RoundToInt((playerTransform.position.x - terrainObject.transform.position.x) / tData.size.x * tData.alphamapWidth);
        int mapZ = Mathf.RoundToInt((playerTransform.position.z - terrainObject.transform.position.z) / tData.size.z * tData.alphamapHeight);

        float[,,] splatMap = terrainObject.terrainData.GetAlphamaps(mapX, mapZ, 1, 1);
        cellMix = new float[splatMap.GetUpperBound(2) + 1];
        for (int i = 0; i < cellMix.Length; i++)
        {
            cellMix[i] = splatMap[0, 0, i];
        }
    }
}