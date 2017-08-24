using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    static int score = 0;
    public static int get = 0;

    public static void Announce()
    {
        get++;
    }

    /*public static void setScore()
    {
        score += 1;
    }

    public static int getScore()
    {
        return score;
    }*/

    void OnGUI()
    {
        //GUILayout.Label("Score : " + score.ToString());
        GUILayout.Label("Announcement:" + get.ToString());
    }
}
