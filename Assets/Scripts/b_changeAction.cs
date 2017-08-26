using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class b_changeAction : MonoBehaviour {

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

    public void Restart_b_changeAction()
    {
        spriterenderer.sprite = origin;
    }
}
