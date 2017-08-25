using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class r_changeAction : MonoBehaviour {

    public Sprite origin;
    public Sprite reversed;
    
    public SpriteRenderer spriterenderer;
    public Collider2D r_bCollider;

    void Awake()
    {
        spriterenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {

    }

	public void Change()
    {
        // 그냥 태그에 따라 sprite를 다르게 (전역) 배정
        spriterenderer.sprite = reversed;
        // r_bCollider.enabled = !(r_bCollider.enabled);


        // if tag == r1
        // sprite = 0, collider enabled = false;

        // else is tag == r0: 이건 다음 단계에서.
        // sprite = 1, collider enabled = true;
    }

    public void Restart_r_changeAction()
    {
        spriterenderer.sprite = origin;
    }
}
