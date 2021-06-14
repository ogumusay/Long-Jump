using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    public delegate void StarEvent();
    public static event StarEvent starEvent;

    [SerializeField] AudioClip audioClip;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        starEvent?.Invoke();
        AudioSource.PlayClipAtPoint(audioClip, transform.position);
        Destroy(gameObject);
    }

}
