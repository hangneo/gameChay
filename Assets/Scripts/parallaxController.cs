using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Build;
using UnityEngine;

//Tự động căn cứ trên khoảng cách giữa các lớp nền với Camera mà hiệu chính tốc độ hiệu ứng thị sai cho phù hợp
//Càng xa càng chậm
public class parallaxController : MonoBehaviour
{
    //Ánh xạ Camera để lấy vị trí
    private Transform _cam;
    //Vị trí bắt đầu của Camera
    private Vector3 _camStartPos;
    //Khoảng cách Camera hiện tại so với ban đầu
    private float _distance;

    //Mảng hình nền
    private GameObject[] _backgrounds;
    //Mảng vật liệu hình nền tương ứng
    private Material[] _mat;
    //Mảng tốc độ hình nền sau hiệu chỉnh
    private float[] _backSpeed;
    //Nền xa nhất
    float _farthestBack = 0;
    //Tọa độ trục Y Z của layer gốc chưa nền
    private float _y;
    private float _z;

    //Tốc độ hiệu chỉnh thị sai nhóm
    [Range(0.005f, 0.1f)]
    public float _parallaxSpeed = 0.01f;

    void Start()
    {
        _y = transform.position.y;
        _z = transform.position.z;
        _farthestBack = 0;
        _parallaxSpeed = 0.1f;
        _cam = Camera.main.transform;
        _camStartPos = _cam.position;
        //Tính số nền
        int _backCount = transform.childCount;
        //Khởi tạo các mảng tương ứng với số lượng đếm được
        _mat = new Material[_backCount];
        _backSpeed = new float[_backCount];
        _backgrounds = new GameObject[_backCount];
        //Gán nền, vật liệu
        for (int i = 0; i < _backCount; i++)
        {
            _backgrounds[i] = transform.GetChild(i).gameObject;
            _mat[i] = _backgrounds[i].GetComponent<Renderer>().material;
        }
        //Gọi hàm hiệu chỉnh lại tốc độ chuyển động hiệu ứng thị sai
        BackSpeedCalculate(_backCount);
    }

    void BackSpeedCalculate(int _backCount)
    {
        //Tính khoảng cách nền xa nhất
        for (int i = 0; i < _backCount; i++)
        {
            if (_backgrounds[i].transform.position.z - _cam.position.z > _farthestBack)
            {
                _farthestBack = _backgrounds[i].transform.position.z - _cam.position.z;
            }
        }
        //Hiệu chỉnh lại toàn bộ tốc độ
        for (int i = 0; i < _backCount; i++)
        {
            _backSpeed[i] = 1 - (_backgrounds[i].transform.position.z - _cam.position.z) / _farthestBack;
        }
    }

    void LateUpdate()
    {
        //Chỉ hiệu chỉnh tọa độ x của nền
        transform.position = new Vector3(_cam.position.x, _y, _z);
        //Khoảng cách camera đã di chuyển, trừ ngược lấy âm vì trôi ngược lại sang trái
        _distance = _cam.position.x - _camStartPos.x;
        
        for (int i = 0; i < _backgrounds.Length; i++)
        {
            float speed = -1f * _backSpeed[i] * _parallaxSpeed * _distance;
            _mat[i].SetTextureOffset("_MainTex", new Vector2(speed, 0));
        }
    }
}

// Hướng comment test