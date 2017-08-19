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

    public SpriteRenderer render;

    bool isJumping = false;
    bool allowJump = false;
    bool passed = false;
    bool pressed = false;

    public int score; // 여기서 이제 먹는 것 추가

    public char r;


    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        render = gameObject.GetComponentInChildren<SpriteRenderer>();
    }

    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        render = gameObject.GetComponentInChildren<SpriteRenderer>();
        Cursor.visible = false; // 사라져라 마우스야!
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
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!passed)
        {            
            if (other.gameObject.CompareTag("MemPiece"))
            {
                passed = true;
                ScoreManager.setScore();
                other.gameObject.SetActive(false);
            }
        }

        if (!pressed)
        {
            if (other.gameObject.CompareTag("switch"))
            {
                pressed = true;
                SwitchAction.Press(r); // 
            }
        }

    }

    void FixedUpdate()
    {
        Run();
        Jump();
    }

    void LateUpdate()
    {
        passed = false;
        pressed = false;
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
            Vector2 jumpVelocity = new Vector2 (0, jumpPower);
            rb2D.AddForce (jumpVelocity/2f, ForceMode2D.Impulse); // 여기서 점프하는 정도 변경
            

            isJumping = false; // 추락
            allowJump = false; // 점프키 방지

        }

    }




}
 