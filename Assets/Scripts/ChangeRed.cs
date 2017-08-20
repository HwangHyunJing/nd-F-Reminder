using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRed : MonoBehaviour {


    public bool r_state;


    public Sprite r1;
    public Sprite r0;


    private SpriteRenderer spriteRenderer;


    void Start() {
        IsTrue();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update() {

    }

    public void r_chn(bool state)
    {
        if (state == true) // switch ON
        {
            spriteRenderer.sprite = r0;
        }

        else
        {
            spriteRenderer.sprite = r1;
        }// state == false

    }


    void IsTrue()
    {
        if (gameObject.CompareTag("r1"))
        {
            r_state = true;
            Moving_4.SendStatement(r_state);
            spriteRenderer.sprite = r1;
        }
        else
        {
            r_state = false;
            Moving_4.SendStatement(r_state);
            spriteRenderer.sprite = r0;
        }
    }
}
