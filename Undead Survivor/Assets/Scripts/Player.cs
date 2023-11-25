using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Vector2 inputVec;
    public float speed;
 
    Rigidbody2D rigid;
    SpriteRenderer render;
    Animator anim;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        render = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        // GetComponent<T> : 오브젝트에서 컴포넌트를 가져오는 함수
    }

    //void Update()
    //{
    //    inputVec.x = Input.GetAxisRaw("Horizontal"); // 수평
    //    inputVec.y = Input.GetAxisRaw("Vertical"); // 수직
    //}



    void FixedUpdate()
    {
       // // 1. 힘을 준다
       // rigid.AddForce(inputVec);
       //
       // // 2. 속도 제어
       // rigid.velocity = inputVec;
       //
       // // 3. 위치 이동
       // rigid.MovePosition(rigid.position + inputVec); // MovePosition는 위치 이동이라 현재 위치도 더해주어야 함

        Vector2 nextVec = inputVec * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);
    }

    private void LateUpdate()
    {
        anim.SetFloat("Speed", inputVec.magnitude);
        // Vector2.magnityde : 이동한 거리크기를 계산

        if (inputVec.x != 0)
        {
            render.flipX = inputVec.x < 0;
        }
    }

    void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
    }
}
