using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SwitchAction : MonoBehaviour {


    //static Sprite sprite;

    public SpriteRenderer AAA;
    public Sprite r_switch_f;
    public Sprite r_switch_t;

	// Use this for initialization
	void Start ()
    {
        AAA = gameObject.GetComponent<SpriteRenderer>();
        // SpriteRenderer.sprite = r_switch_t;
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    static public void Press(char color)
    {
        switch(color)
        {
            case 'r':
                AAA.sprite = SwitchAction.r_switch_t;
                break;
            default:
                break;
        }

        
    }
}
