﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_3 : MonoBehaviour
{
    
    public float speed = 3f;
    public float jumpPower = 5f;

    float horizontalMove;
    float verticalMove;

    public Vector2 movement;
    public Rigidbody2D rb2D;
    public Animator animator;
    public Collision2D blocks;

    bool isJumping = false;
    bool allowJump = false;
    //string blocks;



    void Awake()
    {
        // 최초로 로딩될 때 단 한번 실행
        // 여러 기본 값을 설정하는 곳
        rb2D = GetComponent<Rigidbody2D>();
        // GetComponent<T> () 함수는 스크립트를 가지고 있는 다른 컴포넌트를 가져온다
        animator = GetComponent<Animator>();
    }

    /* void Enable()
    {
        // 오브젝트가 켜질 때 실행
        // 여러 번 실행 가능
    }*/

    void Start()
    {
        // Update 사이클 진입 전 실행
        // 여러 기본 값을 설정하는 곳
        // Awake와는 다르게 여러 번 실행 가능
        rb2D = GetComponent<Rigidbody2D>();

    }


    void Update()
    {
        // 하나의 프레임 마다 실행
        // 주요 로직을 두는 곳
        // 최대 1초당 60프레임 까지만 실행 (초과시 60)
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

        AnimationUpdate();

    }

    void OnCollisionExit2D()
    {
        allowJump = false;
    }

    void OnCollisionEnter2D()
    {
        allowJump = true;
        isJumping = false;
    }

    // 위에서 입력하고
    // 아래에서 처리
    void FixedUpdate()
    {
        // 하나의 고정 프레임마다 실행
        // 물리, rigidbody에 대한 로직을 두는 곳
        // 정확한 물리 시뮬레이팅을 위해 사용

        Run();
        Jump();
    }

    /* void Disalbe ()
    {
        // 오브젝트가 꺼질 때 실행
        // 여러번 실행 가능
    }

    void Destory ()
    {
        // 오브젝트에 삭제 명령이 내려지거나
        // Scene이 바뀔 때 실행
    } */
    
    void Run()
    {
        movement.Set(horizontalMove, 0f); // 3D에서는 h가 x축, v가 z축 이지만
        // 여기서는 h가 x축, v가 y축 값이다

        movement = movement.normalized * speed * Time.deltaTime;
        // normalized는 중간 값
        rb2D.MovePosition(rb2D.position + movement);


        
        if (Input.GetAxisRaw ("Horizontal") < 0)
        {
            transform.localScale = new Vector2(-1, 1);
        }

        else if(Input.GetAxisRaw ("Horizontal") > 0)
        {
            transform.localScale = new Vector2(1, 1);
        }



        // rb2D에서 x값, movement(Vector2 구조체)에서 x값을 가져오기
    }

    void Jump()
    {
        
            if (isJumping == false)
                return;


            else // isJumping == true
            {
                float jumpPower = 7f;
                rb2D.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            // 딜레이 함수
                isJumping = false; // 추락
                allowJump = false; // 점프키 방지
                
            }
        
            
    }









    void AnimationUpdate ()
    {
        if (!isJumping)
            animator.SetBool("isAbove", false);
        else
            animator.SetBool("isAbove", true);

        /*if (horizontalMove > 0f)
            animator.SetBool("isHorizon", true);
        else if (horizontalMove < 0f)
            animator.SetBool("isHorizon", false);
        else
            return;*/
    }
}