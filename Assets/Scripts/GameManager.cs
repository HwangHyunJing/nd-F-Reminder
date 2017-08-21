using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	private static GameObject[] blocks;


	void Start() {

		blocks = GameObject.FindGameObjectsWithTag ("Block");

	}


	public static void ChangeInactiveColor(int colorCode) {
		
		foreach (GameObject block in blocks) {
			block.SetActive (true);
			block.SendMessage ("SwitchTrigger", colorCode);
			Debug.Log (block);
		}

	}
}
