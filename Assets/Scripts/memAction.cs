using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class memAction : MonoBehaviour {

    public GameObject memObject;
    public Collider2D memCollider;
    public Sprite memSprite;
    public SpriteRenderer spriterenderer;

    public void Restart_memAction()
    {
        memCollider.enabled = true;
        memObject.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        // spriterenderer.sprite = memSprite;

    }

}
