using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageScrollAuto : MonoBehaviour
{
    RawImage image;
    [SerializeField] float scrollSpeed;
    float scrollXAxis = 0f;


    private void Start()
    {
        image = GetComponent<RawImage>();

    }

    void Update()
    {
        ScrollImageAuto();
    }

    private void ScrollImageAuto()
    {
        scrollXAxis += Time.deltaTime / scrollSpeed;
        image.uvRect = new Rect(scrollXAxis, 0f, 1f, 1f);
    }
}
