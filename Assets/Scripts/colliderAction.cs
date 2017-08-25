using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colliderAction : MonoBehaviour {

    public Collider2D Itself;
    
    // Use this for initialization
	void Start () {
        Itself = GetComponent<Collider2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Change()
    {
        Itself.enabled = false;
    }

    public void Restart_colliderAction()
    {
        Itself.enabled = true;
    }
}
