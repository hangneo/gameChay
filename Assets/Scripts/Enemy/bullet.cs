using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //ánh xạ biến rb tới prefab bullet
        Destroy(gameObject,3f); //Hủy sau 3s 
    }

    void Update()
    {
        rb.velocity = new Vector2(-5f, rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            Time.timeScale = 0.0f;
            //TODO
            //Mở panel End game, hiện HighScore
        } else if (collision.gameObject.CompareTag("ground"))
        {
            Destroy(gameObject);
        }
    }
}
