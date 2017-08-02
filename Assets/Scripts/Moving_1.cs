using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_1 : MonoBehaviour {

    public float speed = 10f;
    public Vector2 movement;
    public Rigidbody2D rb2D;


	void Awake ()
    {
        // 최초로 로딩될 때 단 한번 실행
        // 여러 기본 값을 설정하는 곳
        rb2D = GetComponent<Rigidbody2D>();
        // GetComponent<T> () 함수는 스크립트를 가지고 있는 다른 컴포넌트를 가져온다
    }

    /* void Enable()
    {
        // 오브젝트가 켜질 때 실행
        // 여러 번 실행 가능
    }*/

    void Start ()
    {
        // Update 사이클 진입 전 실행
        // 여러 기본 값을 설정하는 곳
        // Awake와는 다르게 여러 번 실행 가능
        rb2D = GetComponent<Rigidbody2D>();
    }

	
	/*void Update ()
    {
		// 하나의 프레임 마다 실행
        // 주요 로직을 두는 곳
        // 최대 1초당 60프레임 까지만 실행 (초과시 60)
	} */

    void FixedUpdate()
    {
        // 하나의 고정 프레임마다 실행
        // 물리, rigidbody에 대한 로직을 두는 곳
        // 정확한 물리 시뮬레이팅을 위해 사용

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        // 각 이름은 Edit/Project/Settings/Input에 있다

        Run(h, v); // 만든 함수
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

    void Run (float h, float v)
    {
        movement.Set(h, v); // 3D에서는 h가 x축, v가 z축 이지만
        // 여기서는 h가 x축, v가 y축 값이다
        movement = movement.normalized * speed * Time.deltaTime / 10;
        // normalized는 중간 값
        rb2D.MovePosition(rb2D.position + movement);
    }
}
