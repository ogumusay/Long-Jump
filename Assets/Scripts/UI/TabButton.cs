using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabButton : MonoBehaviour
{
    public GameObject panel;

    public TabGroup tabGroup;

    Button tabButton;    

    private void Awake()
    {
        tabButton = GetComponent<Button>();
    }

    private void Start()
    {        
        tabButton.onClick.AddListener(() => tabGroup.Select(this));    
    }
}
