using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageScroll : MonoBehaviour
{
    RawImage image;
    [SerializeField] float scrollSpeed;
    float scrollXAxis;


    private void Start()
    {
        image = GetComponent<RawImage>();

    }

    void Update()
    {
        ScrollImage();
    }

    private void ScrollImage()
    {
        scrollXAxis = transform.position.x / scrollSpeed;
        image.uvRect = new Rect(scrollXAxis, 0f, 1f, 1f);
    }

}
