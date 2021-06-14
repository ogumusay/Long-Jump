using UnityEngine;

public class LevelCreator : MonoBehaviour
{

    Level currentLevel;
    [SerializeField] GameObject platform;
    [SerializeField] GameObject movingPlatform;
    [SerializeField] GameObject flag;
    [SerializeField] GameObject star;
    [SerializeField] TrapSpawner trapSpawner;

    private void Awake()
    {
        int level = PlayerPrefs.GetInt("currentLevel");
        currentLevel = Resources.Load<Level>("Levels/" + level.ToString());
    }


    void Start()
    {
        SpawnPlatforms();
        SpawnMovingPlatforms();
        SpawnEnemies();
        SpawnStars();
    }

    private void SpawnPlatforms()
    {
        int platformCount = currentLevel.platformSpawns.Length;

        for (int i = 0; i < platformCount; i++)
        {
            Instantiate(platform, new Vector2(currentLevel.platformSpawns[i], 1.5f), Quaternion.identity);
        }

        flag.transform.position = new Vector2(currentLevel.platformSpawns[platformCount - 1], 4f);
    }

    private void SpawnEnemies()
    {
        float[] enemyPositions = currentLevel.enemySpawns;

        int enemyCount = enemyPositions.Length;

        for (int i = 0; i < enemyCount; i++)
        {
            trapSpawner.SpawnTrap(enemyPositions[i]);
        }
    }

    private void SpawnMovingPlatforms()
    {
        if (currentLevel.movingPlatformSpawns != null)
        {
            int platformCount = currentLevel.movingPlatformSpawns.Length;


            for (int i = 0; i < platformCount; i++)
            {
                Instantiate(movingPlatform, new Vector2(currentLevel.movingPlatformSpawns[i], 1.5f), Quaternion.identity);
            }

        }

    }

    private void SpawnStars()
    {
        int starCount = currentLevel.starSpawns.Length;


        for (int i = 0; i < starCount; i++)
        {
            Instantiate(star, new Vector2(currentLevel.starSpawns[i], 4f), Quaternion.identity);
        }
    }
}
