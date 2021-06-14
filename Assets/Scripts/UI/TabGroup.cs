using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class TabGroup : MonoBehaviour
{
    public List<TabButton> tabButtons;

    TabButton selectedButton;

    public void Select(TabButton button)
    {

        selectedButton = button;

        foreach (var tabButton in tabButtons)
        {
            if(tabButton != selectedButton)
            {
                tabButton.panel.SetActive(false);
            }
        }

        selectedButton.panel.SetActive(true);

        GC.Collect();
    }
}
