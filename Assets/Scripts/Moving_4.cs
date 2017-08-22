using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Moving_4 : MonoBehaviour
{

    public float movePower = 1f;
    public float jumpPower = 1f;

    float horizontalMove;
    float verticalMove;

    public Vector3 movement;
    public Rigidbody2D rb2D;

    public GameObject puppet;

    public SpriteRenderer render;

    bool isJumping = false;
    bool allowJump = false;

    //
    //
    public Collider2D DoorCollider;
    public bool inDoor = false;



    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        render = gameObject.GetComponentInChildren<SpriteRenderer>();
    }

    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        render = gameObject.GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");

        // 각 이름은 Edit/Project/Settings/Input에 있다

        if (Input.GetButtonDown("Jump"))
        {
            if (allowJump == true)
                isJumping = true; // able to jump
            else // if jump is not allowed
                return;
        }

        //
        //
        if (Input.GetButtonDown("UseObject"))
        {
            // Fade 함수 (예정)
            Fade();

            puppet.transform.position = DoorCollider.gameObject.GetComponent<Door_r>().DoorEnter(DoorCollider);
            // 넘어가는 문의 좌표를 반환하는 함수(Door_r에서 제작)
            // 반환 값을 바로 현 캐릭터 좌표에 대입
        }
        //
        //
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.tag == "blocks")
            allowJump = false;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "blocks")
        {
            allowJump = true;
            isJumping = false;
        }

        else if (other.gameObject.CompareTag("MemPiece"))
        {
            other.gameObject.SetActive(false);
        }
    }

    //
    //
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("r_door_A"))
        {
            inDoor = true;
            DoorCollider = other; // 해당 문의 값을 받음
        }

        else if (other.CompareTag("r_door_B"))
        {
            inDoor = true;
            DoorCollider = other; // 이하동문
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (inDoor)
        {
            inDoor = false;
            DoorCollider = null; // 이전 문의 값을 제거
        }
    }
    //
    //


    void FixedUpdate()
    {
        Run();
        Jump();
    }



    void Run()
    {

        Vector3 moveVelocity = Vector3.zero;

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            render.flipX = true;
            moveVelocity = Vector3.left;
        }

        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            render.flipX = false;
            moveVelocity = Vector3.right;
        }
        transform.position += moveVelocity * movePower * Time.deltaTime/1f; // 여기서 움직이는 정도 변경

    }

    void Jump()
    {

        if (isJumping == false)
            return;


        else // isJumping == true
        {

            rb2D.velocity = Vector2.zero;
            Vector2 jumpVelocity = new Vector2(0, jumpPower);
            rb2D.AddForce(jumpVelocity / 2f, ForceMode2D.Impulse); // 여기서 점프하는 정도 변경


            isJumping = false; // 추락
            allowJump = false; // 점프키 방지
            return;
        }
        

    }


    IEnumerator Fade()
    {
        for (float f = 1f; f >= 0; f -= 0.5f)
        {
            Color c = GetComponent<Renderer>().material.color;
            c.a = f;
            GetComponent<Renderer>().material.color = c;
            
            yield return null;
        }
    }




}
 