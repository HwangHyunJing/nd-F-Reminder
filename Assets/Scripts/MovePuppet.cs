using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePuppet : MonoBehaviour {

    public float movePower = 40f;
    public float jumpPower = 10f;


    public GameObject puppet;

    float horizontalMove;

    public bool rblock_exist;
    public bool bblock_exist;
    public bool yblock_exist;
    public bool gblock_exist;
    public bool vblock_exist;

    public bool rdoor_exist;
    public bool bdoor_exist;
    public bool ydoor_exist;

    public int r_1_block_boundary; //
    public int b_1_block_boundary;
    public int y_1_block_boundary;
    public int g_1_block_boundary;
    public int v_1_block_boundary;

    public int r_block_num;
    public int b_block_num;
    public int y_block_num;

    public Vector3 movement;
    public Rigidbody2D rb2D;
    public Collider2D Door;



    public GameObject[] r_1_block; //
    public GameObject[] b_1_block; 
    public GameObject[] y_1_block;
    public GameObject[] g_1_block; 
    public GameObject[] v_1_block;

    public GameObject Red_Object; //
    public GameObject Blue_Object;
    public GameObject[] Yellow_Object;
    public GameObject Green_Object;
    public GameObject Violet_Object;

    public GameObject r_door_A;
    public GameObject r_door_B;
    public GameObject b_door_A;
    public GameObject b_door_B;
    public GameObject y_door_A;
    public GameObject y_door_B;

    public GameObject Red_Switch; //
    public GameObject Blue_Switch;
    public GameObject Yellow_Switch;
    public GameObject Green_Switch;
    public GameObject Violet_Switch;

    public SpriteRenderer render;

    public GameObject[] Mem;
    // public Sprite Mem1;
    // public Sprite Mem2;


    bool isJumping = false;
    bool allowJump = false;
    bool passed = false;
    bool pressed = false;
    bool entered = false;

    public int score; // 여기서 이제 먹는 것 추가

    public int i;





    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        render = gameObject.GetComponentInChildren<SpriteRenderer>();

        // ex) colorblockCODE = 11000

        if (rblock_exist)
            r_1_block = GameObject.FindGameObjectsWithTag("r_1_block");

        if (bblock_exist)
            b_1_block = GameObject.FindGameObjectsWithTag("b_1_block");

        if (yblock_exist)
        {
            y_1_block = GameObject.FindGameObjectsWithTag("y_1_block");
            Yellow_Object = GameObject.FindGameObjectsWithTag("y_collideObj");
        }

        if (gblock_exist)
            g_1_block = GameObject.FindGameObjectsWithTag("g_1_block");

        if (vblock_exist)
            v_1_block = GameObject.FindGameObjectsWithTag("v_1_block");


        if (rdoor_exist)
        {
            r_door_A = GameObject.FindWithTag("r_door_A");
            r_door_B = GameObject.FindWithTag("r_door_B");
        }

        if (bdoor_exist)
        {
            b_door_A = GameObject.FindWithTag("b_door_A");
            b_door_B = GameObject.FindWithTag("b_door_B");
        }

        if (ydoor_exist)
        {
            y_door_A = GameObject.FindWithTag("y_door_A");
            y_door_B = GameObject.FindWithTag("y_door_B");
        }

        Mem = GameObject.FindGameObjectsWithTag("MemPiece");

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

        if (Input.GetButtonDown("Jump"))
        {
            if (allowJump == true)
                isJumping = true; 
            else 
                return;
        }

        if (Input.GetButtonDown("objectAction"))
        {
            puppet.transform.position = Door.gameObject.GetComponent<y_doorAction>().DoorEnter(Door);
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        // if (other.gameObject.tag == "blocks")
            allowJump = false;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
     
            allowJump = true;
            isJumping = false;

        if (other.gameObject.tag == "DeathPoint") //
        {
            Restart_MovePuppet();

            if(rblock_exist) Reset_Red_block();
            if(bblock_exist) Reset_Blue_block();
            if(yblock_exist) Reset_Yellow_block();

            if (ydoor_exist) Reset_Yellow_door();

            Reset_Mem();
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {

        if (!passed)
        {
            if (other.gameObject.CompareTag("MemPiece"))
            {
                passed = true;
                // Mem_Reset = GameObject.FindWithTag("MemPiece");
                // other.gameObject.SetActive(false);

                other.enabled = false;
                other.gameObject.GetComponent<SpriteRenderer>().enabled = false; ;
            }
            
        }

        if (!pressed)
        {
            if (other.gameObject.CompareTag("r_switch"))
            {
                pressed = true;

                if(bblock_exist) Reset_Blue_block();
                if(yblock_exist) Reset_Yellow_block();
                if (ydoor_exist) Reset_Yellow_door();

                if(rblock_exist)                Change_Red(other);
            }

            
            if (other.gameObject.CompareTag("b_switch"))
            {
                pressed = true;

                if(rblock_exist) Reset_Red_block();
                if(yblock_exist) Reset_Yellow_block();
                if (ydoor_exist) Reset_Yellow_door();

                if(bblock_exist) Change_Blue(other);
            }

            if (other.gameObject.CompareTag("y_switch"))
            {
                pressed = true;

                if(bblock_exist) Reset_Blue_block();
                if(rblock_exist) Reset_Red_block();

                if(yblock_exist) Change_Yellow_block(other);
                if (ydoor_exist) Change_Yellow_door ();
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
            }
            else if (other.gameObject.CompareTag("y_door_B"))
            {
                entered = true;
                Door = other;
            }
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("y_door_A"))
        {
            entered = false;
            Door = null;
        }

        else if (other.gameObject.CompareTag("y_door_B"))
        {
            entered = false;
            Door = null;
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

    void OnGUI()
    {
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


    public void Restart_MovePuppet()
    {
        // 케릭터 위치 초기화
        // 변수 초기화
        // 스위치 원상태
        // 블럭 원상태: 이건 나중에
        // 기억 조각 원상태

        // 케릭터 위치 초기화
        puppet.transform.position = new Vector2(0, 0);

        // 변수 초기화
        // Time.timeScale = 0f;
        isJumping = false;
        allowJump = false;
        passed = false;
        pressed = false;
        entered = false;

    }

    public void Reset_Red_block()
    {
        Red_Switch.GetComponent<r_switchAction>().Restart_r_switchAction();
        Red_Object.GetComponent<colliderAction>().Restart_colliderAction();
        for (i = 0; i <= r_1_block_boundary; i++)
        {
            r_1_block[i].GetComponent<r_changeAction>().Restart_r_changeAction();
        }
    }

    public void Reset_Blue_block()
    {
        Blue_Switch.GetComponent<b_switchAction>().Restart_b_switchAction();
        Blue_Object.GetComponent<colliderAction>().Restart_colliderAction();
        for (i = 0; i <= b_1_block_boundary; i++)
        {
            b_1_block[i].GetComponent<b_changeAction>().Restart_b_changeAction();
        }
    }

    public void Reset_Yellow_block()
    {
        Yellow_Switch.GetComponent<y_switchAction>().Restart_y_switchAction();

        for (i = 0; i <= y_block_num; i++)
        {
            Yellow_Object[i].GetComponent<colliderAction>().Restart_colliderAction();
        }
        
        for (i = 0; i <= y_1_block_boundary; i++)
        {
            y_1_block[i].GetComponent<y_changeAction>().Restart_y_changeAction();
        }
    }

    public void Reset_Yellow_door()
    {
        Yellow_Switch.GetComponent<y_switchAction>().Restart_y_switchAction();
        y_door_A.GetComponent<y_doorAction>().Restart_y_doorAction();
        y_door_B.GetComponent<y_doorAction>().Restart_y_doorAction();
    }

    public void Reset_Mem()
    {
        foreach (GameObject sign in Mem)
        {
            sign.GetComponent<memAction>().Restart_memAction();
        }
    }


    public void Change_Red(Collider2D other)
    {
        other.gameObject.GetComponent<r_switchAction>().Press('r', other);
        for (i = 0; i <= r_1_block_boundary; i++)
        {
            r_1_block[i].GetComponent<r_changeAction>().Change();
        }
        Red_Object.GetComponent<colliderAction>().Change();
    }

    public void Change_Blue(Collider2D other)
    {
        other.gameObject.GetComponent<b_switchAction>().Press('b', other);
        for (i = 0; i <= b_1_block_boundary; i++)
        {
            b_1_block[i].GetComponent<b_changeAction>().Change();
        }
        Blue_Object.GetComponent<colliderAction>().Change();
    }

    public void Change_Yellow_block(Collider2D other)
    {

            other.gameObject.GetComponent<y_switchAction>().Press('y', other);
            for (i = 0; i <= y_1_block_boundary; i++)
            {
                y_1_block[i].GetComponent<y_changeAction>().Change();
            }

        for (i=0; i <= y_block_num; i++)
        {
            Yellow_Object[i].GetComponent<colliderAction>().Change();
        }
            
    }
        
    
    public void Change_Yellow_door()
    {

            y_door_A.GetComponent<y_doorAction>().Change();
            y_door_B.GetComponent<y_doorAction>().Change();

    }
}
