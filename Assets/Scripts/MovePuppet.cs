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
    public int g_block_num;
    public int v_block_num;

    public Vector3 movement;
    public Rigidbody2D rb2D;
    public Collider2D Door;



    public GameObject[] r_1_block; //
    public GameObject[] b_1_block; 
    public GameObject[] y_1_block;
    public GameObject[] g_1_block; 
    public GameObject[] v_1_block;

    public GameObject[] Red_Object; //
    public GameObject[] Blue_Object;
    public GameObject[] Yellow_Object;
    public GameObject[] Green_Object;
    public GameObject[] Violet_Object;

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

        if (rblock_exist)
        {
            r_1_block = GameObject.FindGameObjectsWithTag("r_1_block");
            Red_Object = GameObject.FindGameObjectsWithTag("r_collideObj");
        }

        if (bblock_exist)
        {
            b_1_block = GameObject.FindGameObjectsWithTag("b_1_block");
            Blue_Object = GameObject.FindGameObjectsWithTag("b_collideObj");
        }

        if (yblock_exist)
        {
            y_1_block = GameObject.FindGameObjectsWithTag("y_1_block");
            Yellow_Object = GameObject.FindGameObjectsWithTag("y_collideObj");
        }

        if (gblock_exist)
        {
            g_1_block = GameObject.FindGameObjectsWithTag("g_1_block");
            Green_Object = GameObject.FindGameObjectsWithTag("g_collideObj");
        }

        if (vblock_exist)
        {
            v_1_block = GameObject.FindGameObjectsWithTag("v_1_block");
            Violet_Object = GameObject.FindGameObjectsWithTag("v_collideObj");
        }



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
            if (gblock_exist) Reset_Green_block();
            if (vblock_exist) Reset_Violet_block();

            if (rdoor_exist) Reset_Red_door();
            if (bdoor_exist) Reset_Blue_door();
            if (ydoor_exist) Reset_Yellow_door();

            Reset_Mem();
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Finish"))
            stage1to2.move1to2();

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

                if (bblock_exist) Reset_Blue_block();
                if (bdoor_exist) Reset_Blue_door();
                if (yblock_exist) Reset_Yellow_block();
                if (ydoor_exist) Reset_Yellow_door();
                if (gblock_exist) Reset_Green_block();
                if (vblock_exist) Reset_Violet_block();
                

                if (rblock_exist) Change_Red_block(other);
                if (rdoor_exist) Change_Red_door();
            }

            
            if (other.gameObject.CompareTag("b_switch"))
            {
                pressed = true;

                if (rblock_exist) Reset_Red_block();
                if (rdoor_exist) Reset_Red_door();
                if (yblock_exist) Reset_Yellow_block();
                if (ydoor_exist) Reset_Yellow_door();
                if (gblock_exist) Reset_Green_block();
                if (vblock_exist) Reset_Violet_block();


                if (bblock_exist) Change_Blue_block(other);
                if (bdoor_exist) Change_Blue_door();
            }

            if (other.gameObject.CompareTag("y_switch"))
            {
                pressed = true;

                if (rblock_exist) Reset_Red_block();
                if (rdoor_exist) Reset_Red_door();
                if (bblock_exist) Reset_Blue_block();
                if (bdoor_exist) Reset_Blue_door();
                if (gblock_exist) Reset_Green_block();
                if (vblock_exist) Reset_Violet_block();


                if (yblock_exist) Change_Yellow_block(other);
                if (ydoor_exist) Change_Yellow_door ();
            }

            if (other.gameObject.CompareTag("g_switch"))
            {
                pressed = true;

                if (rblock_exist) Reset_Red_block();
                if (rdoor_exist) Reset_Red_door();
                if (bblock_exist) Reset_Blue_block();
                if (bdoor_exist) Reset_Blue_door();
                if (yblock_exist) Reset_Yellow_block();
                if (ydoor_exist) Reset_Yellow_door();
                if (vblock_exist) Reset_Violet_block();


                if (gblock_exist) Change_Green_block(other);
            }

            if (other.gameObject.CompareTag("v_switch"))
            {
                pressed = true;

                if (rblock_exist) Reset_Red_block();
                if (rdoor_exist) Reset_Red_door();
                if (bblock_exist) Reset_Blue_block();
                if (bdoor_exist) Reset_Blue_door();
                if (yblock_exist) Reset_Yellow_block();
                if (ydoor_exist) Reset_Yellow_door();
                if (gblock_exist) Reset_Green_block();

                if (vblock_exist) Change_Violet_block(other);
            }

        }
 
    
        if (!entered)
        {
            if (other.gameObject.CompareTag("r_door_A"))
            {
                entered = true;
                Door = other;
            }
            else if (other.gameObject.CompareTag("r_door_B"))
            {
                entered = true;
                Door = other;
            }

            
            if (other.gameObject.CompareTag("b_door_A"))
            {
                entered = true;
                Door = other;
            }
            else if (other.gameObject.CompareTag("b_door_B"))
            {
                entered = true;
                Door = other;
            }


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

    public void OnTriggerStay2D(Collider2D other)
    {
        if (!entered)
        {
            if (other.gameObject.CompareTag("r_door_A"))
            {
                entered = true;
                Door = other;
            }
            else if (other.gameObject.CompareTag("r_door_B"))
            {
                entered = true;
                Door = other;
            }

            if (other.gameObject.CompareTag("b_door_A"))
            {
                entered = true;
                Door = other;
            }
            else if (other.gameObject.CompareTag("b_door_B"))
            {
                entered = true;
                Door = other;
            }

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
        if (other.gameObject.CompareTag("r_door_A"))
        {
            entered = true;
            Door = other;
        }
        else if (other.gameObject.CompareTag("r_door_B"))
        {
            entered = true;
            Door = other;
        }

        if (other.gameObject.CompareTag("b_door_A"))
        {
            entered = true;
            Door = other;
        }
        else if (other.gameObject.CompareTag("b_door_B"))
        {
            entered = true;
            Door = other;
        }

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
        puppet.transform.position = new Vector3(0, 0, -0.5f);

        isJumping = false;
        allowJump = false;
        passed = false;
        pressed = false;
        entered = false;

    }

    public void Reset_Red_block()
    {
        Red_Switch.GetComponent<r_switchAction>().Restart_r_switchAction();
        for (i = 0; i <= r_block_num; i++)
        {
            Red_Object[i].GetComponent<colliderAction>().Restart_colliderAction();
        }
        for (i = 0; i <= r_1_block_boundary; i++)
        {
            r_1_block[i].GetComponent<r_changeAction>().Restart_r_changeAction();
        }
    }

    public void Reset_Blue_block()
    {
        Blue_Switch.GetComponent<b_switchAction>().Restart_b_switchAction();

        for (i = 0; i <= b_block_num; i++)
        {
            Blue_Object[i].GetComponent<colliderAction>().Restart_colliderAction();
        }

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

    public void Reset_Green_block()
    {
        Green_Switch.GetComponent<g_switchAction>().Restart_g_switchAction();

        for (i = 0; i <= g_block_num; i++)
        {
            Green_Object[i].GetComponent<colliderAction>().Restart_colliderAction();
        }

        for (i = 0; i <= g_1_block_boundary; i++)
        {
            g_1_block[i].GetComponent<g_changeAction>().Restart_g_changeAction();
        }
    }

    public void Reset_Violet_block()
    {
        Violet_Switch.GetComponent<v_switchAction>().Restart_v_switchAction();

        for (i = 0; i <= v_block_num; i++)
        {
            Violet_Object[i].GetComponent<colliderAction>().Restart_colliderAction();
        }

        for (i = 0; i <= v_1_block_boundary; i++)
        {
            v_1_block[i].GetComponent<v_changeAction>().Restart_v_changeAction();
        }
    }

    public void Reset_Red_door()
    {
        Red_Switch.GetComponent<r_switchAction>().Restart_r_switchAction();
        r_door_A.GetComponent<r_doorAction>().Restart_r_doorAction();
        r_door_B.GetComponent<r_doorAction>().Restart_r_doorAction();
    }

    public void Reset_Blue_door()
    {
        Blue_Switch.GetComponent<b_switchAction>().Restart_b_switchAction();
        b_door_A.GetComponent<b_doorAction>().Restart_b_doorAction();
        b_door_B.GetComponent<b_doorAction>().Restart_b_doorAction();
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


    public void Change_Red_block(Collider2D other)
    {
        other.gameObject.GetComponent<r_switchAction>().Press('r', other);
        for (i = 0; i <= r_1_block_boundary; i++)
        {
            r_1_block[i].GetComponent<r_changeAction>().Change();
        }
        for (i = 0; i <= r_block_num; i++)
        {
            Red_Object[i].GetComponent<colliderAction>().Change();
        }
    }

    public void Change_Blue_block(Collider2D other)
    {
        other.gameObject.GetComponent<b_switchAction>().Press('b', other);
        for (i = 0; i <= b_1_block_boundary; i++)
        {
            b_1_block[i].GetComponent<b_changeAction>().Change();
        }
        for (i = 0; i <= b_block_num; i++)
        {
            Blue_Object[i].GetComponent<colliderAction>().Change();
        }
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

    public void Change_Green_block(Collider2D other)
    {

        other.gameObject.GetComponent<g_switchAction>().Press('g', other);
        for (i = 0; i <= g_1_block_boundary; i++)
        {
            g_1_block[i].GetComponent<g_changeAction>().Change();
        }

        for (i = 0; i <= g_block_num; i++)
        {
            Green_Object[i].GetComponent<colliderAction>().Change();
        }

    }

    public void Change_Violet_block(Collider2D other)
    {

        other.gameObject.GetComponent<v_switchAction>().Press('v', other);
        for (i = 0; i <= v_1_block_boundary; i++)
        {
            v_1_block[i].GetComponent<v_changeAction>().Change();
        }

        for (i = 0; i <= v_block_num; i++)
        {
            Violet_Object[i].GetComponent<colliderAction>().Change();
        }

    }


    public void Change_Red_door()
    {

        r_door_A.GetComponent<r_doorAction>().Change();
        r_door_B.GetComponent<r_doorAction>().Change();

    }

    public void Change_Blue_door()
    {

        b_door_A.GetComponent<b_doorAction>().Change();
        b_door_B.GetComponent<b_doorAction>().Change();

    }

    public void Change_Yellow_door()
    {

            y_door_A.GetComponent<y_doorAction>().Change();
            y_door_B.GetComponent<y_doorAction>().Change();

    }
}
