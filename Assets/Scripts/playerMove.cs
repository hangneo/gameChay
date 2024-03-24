using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pm2 : MonoBehaviour
{
    //Khai báo biến tham số
    //Khai báo biến nhân vật
    public Rigidbody2D rb; //private Rigidbody2D rb;
    //Tốc độ di chuyển
    public float moveSpeed;
    //Tốc độ nhảy
    public float jumpSpeed;
    //Số lần nhảy tối đa
    public int jumpMax;
    public int jumpCount; //Đếm số lần nhảy
    //Chế độ di chuyển
    public bool autoMove;

    void Start()
    {
        //Gán giá trị mặc định ban đầu cho tốc độ di chuyển, nhảy
        moveSpeed = 4.5f;
        jumpSpeed = 6f;
        jumpMax = 2;
        jumpCount = 0;
        autoMove = true;

        //Khi chạy, tự tìm 1 Rigidbody2D để gắn vào,
        //Chỉ tìm các component bên trong nó
        //rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Nếu phím space được bấm, có kiểm tra số lần nhảy tối đa
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (jumpCount < jumpMax)
            {
                jumpCount++;
                playerJump(jumpSpeed);
            }   
        }
    }
  
    private void FixedUpdate()
    {
        if (autoMove)
        {
            playerRun(moveSpeed);
        }
    }

    void playerJump(float jumpSpeed)
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
    }

    void playerRun(float moveSpeed)
    {
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            jumpCount = 0;
        }
    }
}
