using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : ScriptableObject {

	private static GameManager _instance = (GameManager)CreateInstance ("GameManager");

	enum OBJECT_COLOR { NULL, RED, BLUE };

	private int inactive_color = (int)OBJECT_COLOR.NULL;


	private GameManager() {
	}

	public static GameManager GetInstance() {
		return _instance;
	}

	public void PutLog() {
		Debug.Log ("YES");
	}
}
