using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boar : MonoBehaviour
{
    private int _direction; //1 right; -1 left
    private Rigidbody2D _rb; //ánh xạ tới con boar
    public float _speedBoar; //Tốc độ di chuyển con bò
    void Start()
    {
        _direction= -1; //Ban đầu đi từ phải sang trái
        _speedBoar = 5f; 
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _rb.velocity = new Vector3(_speedBoar * _direction, _rb.velocity.y, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("fence"))
        {
            _direction *= -1; //Đổi hướng
            //Xoay đầu bằng transform scale theo trục x
            _rb.gameObject.transform.localScale = new Vector3(_rb.gameObject.transform.localScale.x * -1, 1, 1);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            Destroy(collision.gameObject);
            Time.timeScale = 0.0f;
            //TODO
            //Mở panel End game, hiện HighScore
        }
    }
}
