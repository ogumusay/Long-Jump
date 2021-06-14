using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GoldHandler : MonoBehaviour
{
    public int totalCoinAmount= 0;
    SaveObject saveObject;
    
    private void Start()
    {
        saveObject = SaveSystem.GetSaveObject();
        TransferSaveObjectToGameObject(saveObject);
    }

    public void HaveCoin(int coinAmount)
    {
        totalCoinAmount += coinAmount;
        Save();
    }

    public void Save()
    {
        TransferGameObjectToSaveObject(saveObject);

        string json = JsonUtility.ToJson(saveObject);
        SaveSystem.Save(json);        

    }

    private void TransferGameObjectToSaveObject(SaveObject saveObject)
    {
        if (saveObject != null)
        {
            saveObject.totalGoldAmount = totalCoinAmount;
        }
    }

    public void TransferSaveObjectToGameObject(SaveObject saveObject)
    {
        if(saveObject != null)
        {
            totalCoinAmount = saveObject.totalGoldAmount;
        }
    }

    public void UpdateCoin()
    {
        saveObject = SaveSystem.GetSaveObject();
        TransferSaveObjectToGameObject(saveObject);
    }

}
