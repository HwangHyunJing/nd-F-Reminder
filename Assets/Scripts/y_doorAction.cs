using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class y_doorAction : MonoBehaviour {

    public GameObject DoorA;
    public GameObject DoorB;

    public Collider2D doorCollider;

    public bool OriginDoor;

    public SpriteRenderer spriterenderer;
    public Sprite origin;
    public Sprite reversed;


    Vector2 DoorPosition; // 문 위치


    void Start()
    {
        DoorA = GameObject.FindWithTag("y_door_A");
        DoorB = GameObject.FindWithTag("y_door_B");
    }

    public Vector2 DoorEnter(Collider2D other)
    {
        if (other.gameObject.CompareTag("y_door_A"))
        {

            DoorPosition.x = DoorB.transform.position.x;
            DoorPosition.y = DoorB.transform.position.y;

            // puppet.transform.position.x = DoorPosition.x;          
        }

        if (other.gameObject.CompareTag("y_door_B"))
        {
            DoorPosition.x = DoorA.transform.position.x;
            DoorPosition.y = DoorA.transform.position.y;

        }

        return DoorPosition;
    }

    public void Change()
    {
        doorCollider.enabled = !OriginDoor;
        spriterenderer.sprite = reversed;
    }

    public void Restart_y_doorAction()
    {
        doorCollider.enabled = OriginDoor;
        spriterenderer.sprite = origin;
    }


}
