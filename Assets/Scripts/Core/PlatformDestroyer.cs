using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroyer : MonoBehaviour
{
    PlatformCreator platformCreator;
    float xOffset = 10f;
    float yOffset = 4f;

    private void Start()
    {
        platformCreator = FindObjectOfType<PlatformCreator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {        
         platformCreator.RePositionPlatform(other.gameObject);                
    }
}
