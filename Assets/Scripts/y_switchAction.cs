using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class y_switchAction : MonoBehaviour {

    public Sprite CurrentSprite;
    public Sprite NextSprite;
    private SpriteRenderer spriteRenderer;


    public Collider2D y_Press;


    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = CurrentSprite;
        y_Press = GetComponent<Collider2D>();
    }


    void Update()
    {

    }

    public void Press(char color, Collider2D other)
    {
        switch (color)
        {
            case 'y':
                other.GetComponent<Collider2D>().enabled = false;

                spriteRenderer.sprite = NextSprite;

                break;
            default:
                break;
        }
    }

    public void Restart_y_switchAction()
    {
        spriteRenderer.sprite = CurrentSprite;
        y_Press.enabled = true;
    }
}
