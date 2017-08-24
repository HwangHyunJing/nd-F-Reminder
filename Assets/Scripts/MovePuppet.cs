using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePuppet : MonoBehaviour {

    public float movePower = 40f;
    public float jumpPower = 10f;

    public GameObject R_on; // 처음에는 exist 상태인 것
    public GameObject R_off; // 처음에는 non exist 상태인 것
    public GameObject puppet;

    float horizontalMove;
    // float verticalMove;


    public Vector3 movement;
    public Rigidbody2D rb2D;
    public Collider2D Door;

    public SpriteRenderer render;

    bool isJumping = false;
    bool allowJump = false;
    bool passed = false;
    bool pressed = false;
    bool entered = false;
    static bool r_state;

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

        if (Input.GetButtonDown("objectAction"))
        {
            puppet.transform.position = Door.gameObject.GetComponent<y_doorAction>().DoorEnter(Door);
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "blocks")
            allowJump = false;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "blocks")
        {
            allowJump = true;
            isJumping = false;
        }

        else if (other.gameObject.tag == "r1")
        {
            allowJump = true;
            isJumping = false;
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (!passed)
        {
            if (other.gameObject.CompareTag("MemPiece"))
            {
                passed = true;
                // ScoreManager.setScore();
                other.gameObject.SetActive(false);
            }
        }

        if (!pressed)
        {
            if (other.gameObject.CompareTag("r_switch"))
            {
                pressed = true;
                other.gameObject.GetComponent<r_switchAction>().Press('r', other);
                r_state = !r_state;

                // other.gameObject.GetComponent<ChangeRed>().r_chn(r_state);
            }
        }
 
    
        if (!entered)
        {
            if (other.gameObject.CompareTag("y_door_A"))
            {
                entered = true;
                Door = other;
                ScoreManager.Announce();

            }
            else if (other.gameObject.CompareTag("y_door_B"))
            {
                entered = true;
                Door = other;
                ScoreManager.Announce();
            }
        }
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (!entered)
        {
            if (other.gameObject.CompareTag("y_door_A"))
            {
                entered = true;
                Door = other;
                ScoreManager.Announce();

            }
            else if (other.gameObject.CompareTag("y_door_B"))
            {
                entered = true;
                Door = other;
                ScoreManager.Announce();
            }
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("y_door_A"))
        {
            entered = false;
            Door = null;
            //ScoreManager.Announce();
        }

        else if (other.gameObject.CompareTag("y_door_B"))
        {
            entered = false;
            Door = null;
            //ScoreManager.Announce();
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
        // entered = false;
        // Door = null;
    }

    void OnGUI()
    {
        //GUILayout.Label("Score : " + score.ToString());
        GUILayout.Label("                           " + entered.ToString() );
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
        transform.position += moveVelocity * movePower * Time.deltaTime * 2f;
    }

    void Jump()
    {

        if (isJumping == false)
            return;


        else // isJumping == true
        {

            rb2D.velocity = Vector2.zero;
            Vector2 jumpVelocity = new Vector2(0, jumpPower);
            rb2D.AddForce(jumpVelocity*5f, ForceMode2D.Impulse); // 여기서 점프하는 정도 변경


            isJumping = false; // 추락
            allowJump = false; // 점프키 방지

        }

    }

    static public void SendStatement(bool state)
    {
        r_state = state;
    }

}
