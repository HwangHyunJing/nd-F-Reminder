﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class g_switchAction : MonoBehaviour {

    public Sprite CurrentSprite;
    public Sprite NextSprite;
    private SpriteRenderer spriteRenderer;


    public Collider2D g_Press;


    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = CurrentSprite;
        g_Press = GetComponent<Collider2D>();
    }


    void Update()
    {

    }

    public void Press(char color, Collider2D other)
    {
        switch (color)
        {
            case 'g':
                other.GetComponent<Collider2D>().enabled = false;

                spriteRenderer.sprite = NextSprite;

                break;
            default:
                break;
        }
    }

    public void Restart_g_switchAction()
    {
        spriteRenderer.sprite = CurrentSprite;
        g_Press.enabled = true;
    }



}
