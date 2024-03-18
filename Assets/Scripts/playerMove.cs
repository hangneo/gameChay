using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pm2 : MonoBehaviour
{
    //Khai báo biến nhân vật
    public Rigidbody2D rb; //private Rigidbody2D rb;

    //Khai báo biến tham số
    //Tốc độ di chuyển
    public float moveSpeed;
    //Tốc độ nhảy
    public float jumpSpeed;

    // Start is called before the first frame update

    void Start()
    {
        //Gán giá trị mặc định ban đầu cho tốc độ di chuyển, nhảy
        moveSpeed = 10f;
        jumpSpeed = 6f;

        //Khi chạy, tự tìm 1 Rigidbody2D để gắn vào,
        //Chỉ tìm các component bên trong nó
        //rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Nếu phím space được bấm
        if (Input.GetKeyDown(KeyCode.Space)) playerJump(jumpSpeed);
    }
  
    private void FixedUpdate()
    {
        playerRun(moveSpeed);
    }

    void playerJump(float jumpSpeed)
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
    }

    void playerRun(float moveSpeed)
    {
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
    }
}
