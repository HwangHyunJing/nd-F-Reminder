using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class y_changeAction : MonoBehaviour {
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

    public void Restart_y_changeAction()
    {
        spriterenderer.sprite = origin;
    }
}
