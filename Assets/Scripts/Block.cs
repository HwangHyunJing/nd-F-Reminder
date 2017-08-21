using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

	public int m_colorCode;

	// Use this for initialization
	void Start () {
		
		Renderer renderer = GetComponent<Renderer> ();

		switch (m_colorCode) {
		case 0:
			// black
			renderer.material.color = new Color (24 / 255, 25 / 255, 24 / 255);
			break;

		case 1:
			// red
			renderer.material.color = new Color (119 / 255f, 35 / 255f, 66 / 255f);
			break;

		case 2:
			// blue
			renderer.material.color = new Color (5 / 255f, 65 / 255f, 126 / 255f);
			break;
		}

	}


	public void SwitchTrigger(int colorCode) {

		gameObject.SetActive (m_colorCode != colorCode);

	}
}
