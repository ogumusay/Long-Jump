using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{ 
    
    Animator animator;

    private void Start()
    {
        animator = transform.parent.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.name);

        if (other.CompareTag("Player"))
        {
            other.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            animator.enabled = false;
            FindObjectOfType<GameOver>(true).SetGameOverUI();
        }
        else
        {
            Destroy(gameObject);
        }

    }
}
