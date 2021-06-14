using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] Canvas gameUI;
    [SerializeField] Text scoreText;
    [SerializeField] public Button watchAdButton;
    AdMobReward adMobReward;

    public void SetGameOverUI()
    {
        gameUI.gameObject.SetActive(false);
        gameObject.SetActive(true);

        int score = FindObjectOfType<ScoreDisplay>(true).score;
        scoreText.text = score.ToString();
    }

    private void OnEnable()
    {
        adMobReward = FindObjectOfType<AdMobReward>();

        if (adMobReward.counter == 5)
        {
            watchAdButton.onClick.AddListener(() => adMobReward.ShowAd());

            if (adMobReward.rewardedAd.IsLoaded())
            {
                watchAdButton.interactable = true;
            }

            adMobReward.counter = 0;
        }
        else
        {
            adMobReward.counter++;

        }
    }
}
