using UnityEngine;
using UnityEngine.EventSystems;

public class LevelSelector : MonoBehaviour
{
    [SerializeField] LevelCreator levelCreator;
    [SerializeField] LevelLoader levelLoader;

    public void SetLevel()
    {
        int index = EventSystem.current.currentSelectedGameObject.transform.GetSiblingIndex();

        PlayerPrefs.SetInt("currentLevel", index + 1);

        levelLoader.LoadGame();
    }

    
}
