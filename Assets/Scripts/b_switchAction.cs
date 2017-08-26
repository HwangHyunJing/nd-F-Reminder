﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class b_switchAction : MonoBehaviour {



    public Sprite CurrentSprite;
    public Sprite NextSprite;
    private SpriteRenderer spriteRenderer;


    public Collider2D b_Press;


    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = CurrentSprite;
        b_Press = GetComponent<Collider2D>();
    }


    void Update()
    {

    }

    public void Press(char color, Collider2D other)
    {
        switch (color)
        {
            case 'b':
                other.GetComponent<Collider2D>().enabled = false;

                spriteRenderer.sprite = NextSprite;

                break;
            default:
                break;
        }
    }

    public void Restart_b_switchAction()
    {
        spriteRenderer.sprite = CurrentSprite;
        b_Press.enabled = true;
    }
}
