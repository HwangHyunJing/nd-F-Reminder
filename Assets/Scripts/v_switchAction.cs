using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class v_switchAction : MonoBehaviour {

    public Sprite CurrentSprite;
    public Sprite NextSprite;
    private SpriteRenderer spriteRenderer;


    public Collider2D v_Press;


    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = CurrentSprite;
        v_Press = GetComponent<Collider2D>();
    }


    void Update()
    {

    }

    public void Press(char color, Collider2D other)
    {
        switch (color)
        {
            case 'v':
                other.GetComponent<Collider2D>().enabled = false;

                spriteRenderer.sprite = NextSprite;

                break;
            default:
                break;
        }
    }

    public void Restart_v_switchAction()
    {
        spriteRenderer.sprite = CurrentSprite;
        v_Press.enabled = true;
    }



}
