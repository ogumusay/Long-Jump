using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    Text scoreText;
    public int score = 0;

    private void Start()
    {
        scoreText = GetComponent<Text>();
        UpdateScore();
    }

    public void UpdateScore()
    {
        scoreText.text = score.ToString();
    }


    private void OnDestroy()
    {
        SaveObject saveObject = SaveSystem.GetSaveObject();
        int totalGoldAmount = saveObject.totalGoldAmount;
        saveObject.totalGoldAmount = totalGoldAmount + score;

        string json = JsonUtility.ToJson(saveObject);
        SaveSystem.Save(json);
    }

}
