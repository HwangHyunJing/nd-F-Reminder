using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class g_changeAction : MonoBehaviour {

    public Sprite origin;
    public Sprite reversed;

    public SpriteRenderer spriterenderer;


    void Awake()
    {
        spriterenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {

    }

    public void Change()
    {
        spriterenderer.sprite = reversed;
    }

    public void Restart_g_changeAction()
    {
        spriterenderer.sprite = origin;
    }
}
