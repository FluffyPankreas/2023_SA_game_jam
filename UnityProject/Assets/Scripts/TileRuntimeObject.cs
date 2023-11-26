using System;
using System.Collections.Generic;
using UnityEngine;

public class TileRuntimeObject : MonoBehaviour
{
        public List<GameObject> terrainTypes;
        public List<GameObject> animalTypes;
        public float moveSpeed;
        
        private float targetZ;

        private bool moving = false;

        public void SetTerrainType(int terrainIndex)
        {
                foreach (var terrain in terrainTypes)
                {
                        terrain.SetActive(false);
                }

                terrainTypes[terrainIndex].SetActive(true);
        }

        public void SetAnimalType(int animalIndex)
        {
                foreach (var animal in animalTypes)
                {
                        animal.SetActive(false);
                }

                if (animalIndex > 0)
                {
                        Debug.Log("activating an animal. " + animalIndex);
                        animalTypes[animalIndex - 1].SetActive(true);
                }
        }

        public void SetNewTargetPosition(float _targetZ)
        {
                targetZ = _targetZ;
                moving = true;
        }

        public void Update()
        {
                if (transform.position.z != targetZ && moving)
                {
                        var newZ = transform.position.z - (moveSpeed * Time.deltaTime);
                        if (newZ <= targetZ)
                        {
                                newZ = targetZ;
                                moving = false;
                        }

                        transform.localPosition = new Vector3(0, 0, newZ);
                }
        }
}
