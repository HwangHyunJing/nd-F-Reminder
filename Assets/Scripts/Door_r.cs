using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_r : MonoBehaviour {


    public GameObject DoorA;
    public GameObject DoorB;

    
    // public GameObject Player; // 실제 케릭터
    // Vector2 CharPosition; // 케릭터 위치
    Vector2 DoorPosition; // 문 위치

    // public bool inDoor = false;

	// Use this for initialization
	void Start () {
        DoorA = GameObject.FindWithTag("r_door_A");
        DoorB = GameObject.FindWithTag("r_door_B");
	}

    public Vector2 DoorEnter(Collider2D other)
    {
        if (other.gameObject.CompareTag("r_door_A"))
        {
            
            DoorPosition.x = DoorB.transform.position.x;
            DoorPosition.y = DoorB.transform.position.y;

            // puppet.transform.position.x = DoorPosition.x;          
        }

        else if (other.gameObject.CompareTag("r_door_B"))
        {
            DoorPosition.x = DoorA.transform.position.x;
            DoorPosition.y = DoorA.transform.position.y;

        }

        return DoorPosition;
    }

    // Update is called once per frame
    void Update ()
    {
        // GameObject puppet = gameObject.GetComponent<Moving_4>().puppet;
	}


}
