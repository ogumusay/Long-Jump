using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Upgrade : MonoBehaviour
{
    protected SaveObject saveObject;
    protected UpgradeSaveObject upgradeSaveObject;
    [SerializeField] Button buyButton;
    [SerializeField] Text upgradeLevelText;
    [SerializeField] Text upgradeCostText;

    protected int upgradeCost { get; set; }
    protected int upgradeLevel { get; set; }
    protected int upgradeMaxLevel { get; set; }

    protected void Start()
    {
        SetBuyButton();
        GetUpgradeLevelFromSaveObject();
        SetUpgradeLevelText();
        SetUpgradeCostText();
        SetButtonDisabledIfLevelMax(); 
    }


    public virtual void Buy()
    {
        if (upgradeLevel < upgradeMaxLevel)
        {
            saveObject = SaveSystem.GetSaveObject();

            int totalCoin = saveObject.totalGoldAmount;

            if (upgradeCost <= totalCoin)
            {
                saveObject.totalGoldAmount = totalCoin - upgradeCost;
            }
            else
            {
                return;
            }

            upgradeLevel++;
            upgradeSaveObject.upgradeLevel = upgradeLevel;

            WriteToSaveObject();
            SetUpgradeLevelText();
            SetUpgradeCostText();
            SetButtonDisabledIfLevelMax();
        }
    }

    protected virtual void WriteToSaveObject()
    {
        string json = JsonUtility.ToJson(saveObject);
        SaveSystem.Save(json);
        FindObjectOfType<CoinDisplay>().UpdateCoinDisplay();
    }

    protected void SetBuyButton()
    {
        buyButton.onClick.AddListener(() => Buy());
    }

    public virtual void GetUpgradeLevelFromSaveObject()
    {
        
    }

    protected void SetButtonDisabledIfLevelMax()
    {
        if (upgradeLevel >= upgradeMaxLevel)
        {
            buyButton.interactable = false;
            upgradeCostText.text = "MAX";
        }
    }

    protected void SetUpgradeLevelText()
    {
        upgradeLevelText.text = upgradeLevel.ToString() + "/" + upgradeMaxLevel.ToString();
    }

    protected virtual void SetUpgradeCostText()
    {
        upgradeCostText.text = upgradeCost.ToString();
    }
}
