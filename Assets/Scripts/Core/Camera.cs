using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    Player player;    

    [SerializeField] float cameraOffset = 5f;
    float size;

    private void Awake()
    {
        float aspect = UnityEngine.Camera.main.aspect;
        UnityEngine.Camera.main.orthographicSize = aspect > 1.7f ? (8 / aspect) : 4.5f; 
    }

    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    void Update()
    {
        if (player)
        {
            transform.position = new Vector3(player.transform.position.x + cameraOffset, transform.position.y, transform.position.z);
        }
    }

}
