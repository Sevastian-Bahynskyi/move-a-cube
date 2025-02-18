using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TerrainScript : MonoBehaviour
{
    private Terrain terrain;

    // Start is called before the first frame update
    void Start()
    {
    }

    void OnValidate()
    {
        CenterTerrain();
    }

    private void CenterTerrain()
    {
        terrain = GetComponent<Terrain>();

        if (terrain != null)
        {
            Vector3 terrainSize = terrain.terrainData.size;
            Vector3 terrainCenter = terrainSize;
            terrainCenter.x /= 2;
            terrainCenter.y = 0;
            terrainCenter.z /= 2;

            // Position the terrain so that its center is at the origin
            transform.position = -terrainCenter;

            Debug.Log("Terrain size: " + terrainSize);
            Debug.Log("Terrain position: " + transform.position);
        }
        else
        {
            Debug.LogError("Terrain component not found on this GameObject.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
