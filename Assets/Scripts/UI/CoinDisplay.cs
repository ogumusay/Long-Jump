using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinDisplay : MonoBehaviour
{
    Text coinText;
    GoldHandler coinHandler;

    private void Start()
    {
        coinText = GetComponent<Text>();
        coinHandler = FindObjectOfType<GoldHandler>();
        UpdateCoinDisplay();
    }

    public void UpdateCoinDisplay()
    {
        coinHandler.UpdateCoin();
        int gold = coinHandler.totalCoinAmount;
        coinText.text = gold.ToString();
    }

}
