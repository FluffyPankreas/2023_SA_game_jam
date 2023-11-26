using System;
using System.Collections.Generic;
using UnityEngine;

public class TileRuntimeObject : MonoBehaviour
{
        public List<GameObject> terrainTypes;

        public void SetTerrainType(int terrainIndex)
        {
                foreach (var terrain in terrainTypes)
                {
                        terrain.SetActive(false);
                }

                Debug.Log("Setting terrain: " + terrainIndex);
                terrainTypes[terrainIndex].SetActive(true);
        }
}
