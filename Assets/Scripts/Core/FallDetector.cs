using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallDetector : MonoBehaviour
{
    [SerializeField] Canvas gameUI;
    [SerializeField] Canvas gameOverUI;

    float yOffset = -1.5f;

    void Update()
    {
        float cameraXPos = UnityEngine.Camera.main.transform.position.x;

        transform.position = new Vector3(cameraXPos, yOffset, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<GameOver>(true).SetGameOverUI();
        Destroy(collision.gameObject);
    }
}
