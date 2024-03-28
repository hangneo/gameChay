using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallax2 : MonoBehaviour
{
    Material _mat;
    private float _distance;

    [Range(0f, 0.5f)]
    public float _speed = 0.1f;

    void Start()
    {
        _speed = 0.1f;
        _mat = GetComponent<Renderer>().material;    
    }

    void LateUpdate()
    {
        _distance += Time.deltaTime * _speed;
        //_mat.SetTextureOffset("_MainTex", Vector2.left * _distance);
    }
}

// Hướng comment test
