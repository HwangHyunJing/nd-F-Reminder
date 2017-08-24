using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class r_switchAction : MonoBehaviour
{
    public Sprite CurrentSprite;
    public Sprite NextSprite;
    private SpriteRenderer spriteRenderer;
    

    public Collider2D r_Press;

    
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = CurrentSprite;

    }


    void Update()
    {

    }

    public void Press(char color, Collider2D other)
    {
        switch (color)
        {
            case 'r':
                other.GetComponent<Collider2D>().enabled = false;
                
                spriteRenderer.sprite = NextSprite;

                break;
            default:
                break;
        }
    }


}


