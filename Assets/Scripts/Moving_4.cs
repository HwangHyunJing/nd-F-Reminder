using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Moving_4 : MonoBehaviour
{

    public float speed = 3f;
    public float jumpPower = 5f;

    float horizontalMove;
    float verticalMove;

    public Vector2 movement;
    public Rigidbody2D rb2D;

    bool isJumping = false;
    bool allowJump = false;

    public Collision other;



    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");
        // verticalMove = Input.GetAxisRaw("Vertical");
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
        if(other.gameObject.tag == "blocks")
            allowJump = true;
            isJumping = false;
    }

    void FixedUpdate()
    {
        Run();
        Jump();
    }

    void Run()
    {
        movement.Set(horizontalMove, 0f); // 3D에서는 h가 x축, v가 z축 이지만
        // 여기서는 h가 x축, v가 y축 값이다

        movement = movement.normalized * speed * Time.deltaTime;
        // normalized는 중간 값
        rb2D.MovePosition(rb2D.position + movement);



        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.localScale = new Vector2(-1, 1);
        }

        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.localScale = new Vector2(1, 1);
        }

    }

    void Jump()
    {

        if (isJumping == false)
            return;


        else // isJumping == true
        {
            float jumpPower = 7f;
            rb2D.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            isJumping = false; // 추락
            allowJump = false; // 점프키 방지

        }

    }
}
 