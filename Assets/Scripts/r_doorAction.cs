using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class r_doorAction : MonoBehaviour {

    public GameObject DoorA;
    public GameObject DoorB;

    public Collider2D doorCollider;

    public bool OriginDoor;

    public SpriteRenderer spriterenderer;
    public Sprite origin;
    public Sprite reversed;


    Vector3 DoorPosition; // 문 위치


    void Start()
    {
        DoorA = GameObject.FindWithTag("r_door_A");
        DoorB = GameObject.FindWithTag("r_door_B");
    }

    public Vector3 DoorEnter(Collider2D other)
    {
        if (other.gameObject.CompareTag("r_door_A"))
        {

            DoorPosition.x = DoorB.transform.position.x;
            DoorPosition.y = DoorB.transform.position.y;
            DoorPosition.z = -0.5f;

            // puppet.transform.position.x = DoorPosition.x;          
        }

        if (other.gameObject.CompareTag("r_door_B"))
        {
            DoorPosition.x = DoorA.transform.position.x;
            DoorPosition.y = DoorA.transform.position.y;
            DoorPosition.z = -0.5f;
        }

        return DoorPosition;
    }

    public void Change()
    {
        doorCollider.enabled = !OriginDoor;
        spriterenderer.sprite = reversed;
    }

    public void Restart_r_doorAction()
    {
        doorCollider.enabled = OriginDoor;
        spriterenderer.sprite = origin;
    }

}
