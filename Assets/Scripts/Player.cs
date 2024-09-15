using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Vector2 moveDirection;
    [SerializeField] float moveSpeed;
    public Rigidbody2D rb2d;
    public Animator anim;



    public float boostSpeed = 10.0f;
    public float BoostTime = 0.2f;
    public bool isBoosting = false;
    private float boostTime;


    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
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
        if(Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
        {
            anim.SetFloat("isWalking",0);
        }

        // di chuyen
        Vector2 idelBoostDirection = moveDirection;
        moveDirection = Vector2.zero;
        if (Input.GetKey(KeyCode.A))
        {
            moveDirection.x = -1;
            idelBoostDirection = moveDirection;
            transform.localScale = new Vector3(-0.1f, 0.1f, 0.1f); // xoay trai nhan vat
            anim.SetFloat("isWalking", 1);
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveDirection.x = 1;
            idelBoostDirection = moveDirection;
            transform.localScale = new Vector3(0.1f, 0.1f, 0.1f); // xoay phai nhan vat
            anim.SetFloat("isWalking", 1);
        }
        if (Input.GetKey(KeyCode.W))
        {
            moveDirection.y = 1;
            anim.SetFloat("isWalking", 1);
        }
           
        if (Input.GetKey(KeyCode.S))
        {
            moveDirection.y = -1;
            anim.SetFloat("isWalking", 1);
        }

        moveDirection = moveDirection.normalized;

        

        // tan cong
        if (Input.GetKey(KeyCode.J))
        {
            anim.SetBool("isHitting", true);
        }
        if (Input.GetKeyUp(KeyCode.J))
        {
            anim.SetBool("isHitting", false);
        }


        // boost
        if (Input.GetKeyDown(KeyCode.K) && boostTime <= 0) 
        {
            moveSpeed += boostSpeed;
            isBoosting = true;
            boostTime = BoostTime;
            anim.SetBool("isBoosting", isBoosting);
        }

        if (isBoosting && moveDirection == Vector2.zero)
        {
            rb2d.MovePosition(rb2d.position + idelBoostDirection * moveSpeed * Time.fixedDeltaTime);
        }

        if (boostTime <= 0 && isBoosting)
        {
            moveSpeed -= boostSpeed;
            isBoosting = false;
            anim.SetBool("isBoosting", isBoosting);

        } else
        {
            boostTime -= Time.deltaTime;
        }
        
    }

    private void Move()
    {
        rb2d.MovePosition(rb2d.position + moveDirection * moveSpeed * Time.fixedDeltaTime);
    }
}
