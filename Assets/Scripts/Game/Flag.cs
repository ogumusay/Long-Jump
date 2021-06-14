using Assets.Scripts;
using UnityEngine;

public class Flag : MonoBehaviour
{


    [SerializeField] GameObject destroyVFX;
    [SerializeField] GameObject winUI;
    [SerializeField] GameObject gameUI;
    [SerializeField] GameObject endGameUI;
    [SerializeField] LevelGroup levelGroup;
    int starCount = 0;

    private void Start()
    {
        Star.starEvent += GetStar;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        Instantiate(destroyVFX, transform.position, Quaternion.identity);
        other.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;

        SaveObject saveObject = SaveSystem.GetSaveObject();
        int currentLevel = PlayerPrefs.GetInt("currentLevel");

        gameUI.SetActive(false);

        if (currentLevel == 15)
        {
            endGameUI.SetActive(true);
        }
        else
        {
            winUI.SetActive(true);
        }



        UnlockNextLevel(saveObject, currentLevel);
        SaveStars(saveObject, currentLevel);
    }

    void UnlockNextLevel(SaveObject saveObject, int currentLevel)
    {
        int nextLevel = currentLevel + 1;

        if (nextLevel > levelGroup.levelButtons.Length)
        {
            return;
        }

        if (!saveObject.unlockedLevels.Contains(nextLevel))
        {
            saveObject.unlockedLevels.Add(nextLevel);
            saveObject.levelStars.Add(0);
            string json = JsonUtility.ToJson(saveObject);
            SaveSystem.Save(json);
        }

    }

    private void GetStar()
    {
        starCount++;
    }

    private void SaveStars(SaveObject saveObject, int currentLevel)
    {
        int previousStarCount = saveObject.levelStars[currentLevel - 1];

        if (previousStarCount >= starCount)
        {
            return;
        }

        saveObject.levelStars[currentLevel - 1] = starCount;

        string json = JsonUtility.ToJson(saveObject);
        SaveSystem.Save(json);
    }

    private void OnDestroy()
    {
        Star.starEvent -= GetStar;
    }
}
