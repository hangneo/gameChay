using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Lưu ý, Game Object cần có Collision2D và có Rigibody2D (lưu ý Body type phải ở mode Dynamic) 
public class Recycle : MonoBehaviour
{
    //Camera chính
    private new Camera camera;
    private float _y;
    private float _z;
    void Start()
    {
        camera = Camera.main;
        _y = transform.position.y;
        _z = transform.position.z;
    }

    void Update()
    {
        //Cập nhật trục x Bộ máy xử lý rác theo camera
        transform.position = new Vector3(camera.transform.position.x, _y, _z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }
}

//test test test test test An 2