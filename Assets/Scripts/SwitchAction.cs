using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SwitchAction : MonoBehaviour
{
    public Sprite CurrentSprite;
    public Sprite NextSprite;
    private SpriteRenderer spriteRenderer;


    
    void Start ()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = CurrentSprite;

    }
	

	void Update ()
    {

    }

    public void Press(char color)
    {
        switch(color)
        {
            case 'r':
                spriteRenderer.sprite = NextSprite;

                break;
            default:
                break;
        }  
    }


}
