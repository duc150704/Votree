using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector2 moveDirection;
    [SerializeField] float moveSpeed;
    public Rigidbody2D rb2d;


    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // goi moi KHUNG HINH
    // vd: 60fps chay 60 lan; 120fps chay 120 lan => phu thuoc so khung hinh;
    // can than hieu nang
    private void Update()
    {
        PlayerInput();
    }

    // duoc goi sau moi 0.02s => 1p chay 50 lan;
    // thuong dung de xu li tac vu lien quan den vat li;
    private void FixedUpdate()
    {
        Move();
    }

    private void PlayerInput()
    {
        moveDirection = Vector2.zero;
        if (Input.GetKey(KeyCode.A))
            moveDirection.x = -1;
        if (Input.GetKey(KeyCode.D))
            moveDirection.x = 1;
        if (Input.GetKey(KeyCode.W))
            moveDirection.y = 1;
        if (Input.GetKey(KeyCode.S))
            moveDirection.y = -1;

        moveDirection = moveDirection.normalized;
    }

    private void Move()
    {
        rb2d.MovePosition(rb2d.position + moveDirection * moveSpeed * Time.fixedDeltaTime);
    }
}
