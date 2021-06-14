using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Level")]
public class Level : ScriptableObject
{

    public string levelName;

    public float[] platformSpawns;

    public float[] movingPlatformSpawns;

    public float[] enemySpawns;

    public float[] starSpawns;

}
