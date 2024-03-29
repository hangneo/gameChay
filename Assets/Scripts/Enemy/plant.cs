using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plant : MonoBehaviour
{
    public GameObject _bulletPrefab; //Prefab viên đạn
    public Transform _bulletPos; //Vị trí viên đạn bắn ra
    private float _timer; //Tính thời gian được bắn
    private Animator _animator; //bộ máy hoạt họa
    void Start()
    {
        _animator = GetComponent<Animator>();
        _timer = 0;
    }

    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > 3f) //đủ điều kiện bắn
        {
            _animator.SetTrigger("atk");
            _timer = 0;
        }
    }

    private void PlantShoot()
    {
        Instantiate(_bulletPrefab, _bulletPos.position, Quaternion.identity, transform);
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
