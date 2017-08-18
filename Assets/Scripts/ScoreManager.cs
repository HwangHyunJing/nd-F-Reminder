using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {


    static int score = 0;

    public static void setScore()
    {
        score += 1;
    }

    public static int getScore()
    {
        return score;
    }

    void OnGUI()
    {
        GUILayout.Label("Score : " + score.ToString());
    }
}
