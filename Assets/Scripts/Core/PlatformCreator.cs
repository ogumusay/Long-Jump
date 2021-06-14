using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCreator : MonoBehaviour
{

    [SerializeField] GameObject platformPrefab;
    [SerializeField] TrapSpawner trapSpawner;
    [SerializeField] float minDistance = 2f;
    [SerializeField] float maxDistance = 10f;
    [SerializeField] float yOffset = 1.5f;
    float lastXPos;

    int spawnCounter = 0;


    void Start()
    {
        lastXPos = UnityEngine.Random.Range(minDistance, maxDistance);
        BuildMultiPlatforms(7);    
    }

    private GameObject BuildPlatform(float x, float y)
    {
        GameObject platform = Instantiate(platformPrefab, new Vector3(x, y, 0), Quaternion.identity) as GameObject;
     
        return platform;
    }

    private void BuildMultiPlatforms(int amount)
    {
        float distance = 0;

        for (int i = 0; i < amount; i++)
        {
            BuildPlatform(lastXPos, yOffset);

            distance = UnityEngine.Random.Range(minDistance, maxDistance);

            lastXPos += distance;
        }
    }

    private void SpawnTraps()
    {
        if (lastXPos > 40f)
        {
            int randomNum = UnityEngine.Random.Range(0, 4);

            if (randomNum == 0 && spawnCounter < 1)
            {
                spawnCounter++;
                trapSpawner.SpawnTrap(lastXPos);
            }
            else
            {
                spawnCounter = 0;
            }

        }
    }

    public void RePositionPlatform(GameObject platform)
    {
        float distance = 0;

        platform.transform.position = new Vector3(lastXPos, yOffset, 0);

        SpawnTraps();

        distance = UnityEngine.Random.Range(minDistance, maxDistance);

        lastXPos += distance;
    }
}
