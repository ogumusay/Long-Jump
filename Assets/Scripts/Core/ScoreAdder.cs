using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class ScoreAdder : Score
    {
        ScoreDisplay scoreDisplay;
        GoldHandler coinHandler;

        private void Awake()
        {
            scoreDisplay = FindObjectOfType<ScoreDisplay>();
            coinHandler = FindObjectOfType<GoldHandler>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.name == "Player")
            {
                AddScore(scoreValue);
                //transform.position = new Vector3(PlatformCreator.lastXPos, 0, 0);
                //coinHandler.HaveCoin(scoreValue);
                //Destroy(this.gameObject);
            }
        }

        private void AddScore(int scoreValue)
        {
            scoreDisplay.score += scoreValue;
            scoreDisplay.UpdateScore();
        }


    }

}
