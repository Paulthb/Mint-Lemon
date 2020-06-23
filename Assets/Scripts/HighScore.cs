using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HighScore", menuName = "NewScore")]
public class HighScore : ScriptableObject
{
    public List<float> scoreList;

    public float GetHighScore()
    {
        float highScore = 0;
        foreach(float score in scoreList)
        {
            if (score > highScore)
                highScore = score;
        }

        return highScore;
    }
}
