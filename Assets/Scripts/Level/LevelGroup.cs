using Assets.Scripts;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelGroup : MonoBehaviour
{
    SaveObject saveObject;
    [SerializeField] public Button[] levelButtons;
    [SerializeField] Image[] levelStars;
    [SerializeField] Sprite zeroStar;
    [SerializeField] Sprite oneStar;
    [SerializeField] Sprite twoStar;
    [SerializeField] Sprite threeStar;

    private void Awake()
    {
        saveObject = SaveSystem.GetSaveObject();
    }

    private void Start()
    {
        int totalLevels = levelButtons.Length;
        int unlockedLevelsCount = saveObject.unlockedLevels.Count;
        

        for (int i = 0; i < unlockedLevelsCount; i++)
        {
            levelButtons[i].interactable = true;
        }

        SetLevelStars();
    }

    private void SetLevelStars()
    {
        List<int> levelStarsCount = saveObject.levelStars;

        int levelStarsLength = levelStarsCount.Count;

        Sprite starSprite;

        for (int i = 0; i < levelStarsLength; i++)
        {
            

            switch (levelStarsCount[i])
            {
                case 0:
                    starSprite = zeroStar;
                    break;
                case 1:
                    starSprite = oneStar;
                    break;
                case 2:
                    starSprite = twoStar;
                    break;
                case 3:
                    starSprite = threeStar;
                    break;
                default:
                    starSprite = null;
                    break;
            }

            levelStars[i].sprite = starSprite;
        }

        for (int i = levelStarsLength; i < levelStars.Length; i++)
        {
            levelStars[i].enabled = false;
        }
    }
}
