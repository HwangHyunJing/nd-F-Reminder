using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player_Move : MonoBehaviour
{
	public float movePower = 1f;
	public float jumpPower = 1f;

	public GameManager gameManager;

	float horizontalMove;
	float verticalMove;

	public Vector3 movement;
	public Rigidbody2D rb2D;

	public SpriteRenderer render;

	bool isJumping = false;
	bool allowJump = false;



	void Awake()
	{
		rb2D = GetComponent<Rigidbody2D>();
		render = gameObject.GetComponentInChildren<SpriteRenderer>();
	}

	void Start()
	{
		GameManager.GetInstance ().PutLog ();
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
	}

	void OnCollisionExit2D(Collision2D other)
	{
		if(other.gameObject.tag == "Block")
			allowJump = false;
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Block")
		{
			allowJump = true;
			isJumping = false;
		}
		/*
		else if (other.gameObject.CompareTag("MemPiece"))
		{
			other.gameObject.SetActive(false);
		}*/
	}

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
			render.flipX = false;
			moveVelocity = Vector3.left;
		}

		else if (Input.GetAxisRaw("Horizontal") > 0)
		{
			render.flipX = true;
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