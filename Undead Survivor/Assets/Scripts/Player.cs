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
        // GetComponent<T> : ������Ʈ���� ������Ʈ�� �������� �Լ�
    }

    //void Update()
    //{
    //    inputVec.x = Input.GetAxisRaw("Horizontal"); // ����
    //    inputVec.y = Input.GetAxisRaw("Vertical"); // ����
    //}



    void FixedUpdate()
    {
       // // 1. ���� �ش�
       // rigid.AddForce(inputVec);
       //
       // // 2. �ӵ� ����
       // rigid.velocity = inputVec;
       //
       // // 3. ��ġ �̵�
       // rigid.MovePosition(rigid.position + inputVec); // MovePosition�� ��ġ �̵��̶� ���� ��ġ�� �����־�� ��

        Vector2 nextVec = inputVec * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);
    }

    private void LateUpdate()
    {
        anim.SetFloat("Speed", inputVec.magnitude);
        // Vector2.magnityde : �̵��� �Ÿ�ũ�⸦ ���

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
