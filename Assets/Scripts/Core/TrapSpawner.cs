using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSpawner : MonoBehaviour
{
    [SerializeField] GameObject trapPrefab;
    private const float Y_OFFSET = 4f;

    public void SpawnTrap(float x)
    {
        Instantiate(trapPrefab, new Vector3(x, Y_OFFSET, 0), Quaternion.identity);
    }
}
