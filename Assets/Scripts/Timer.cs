using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer: MonoBehaviour {

    public Text text;
	// Use this for initialization
	void Start () {
        text.text = "0";
        StartCoroutine(timerLogic());
	}

    IEnumerator timerLogic()
    {
        float t = 0;
        while(true)
        {
            text.text = t.ToString();
            t += Time.deltaTime;
            yield return null;
        }
    }
}
