using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Mỗi lần tạo ra N coin, lưu ý đặt là số lẻ
// Sau mỗi khoảng thời gian 5s , vẽ ra N coin
// Coin xuất hiện phía bên phải, ngoài màn hình hình, ví dụ khoảng cách vẽ 20f
// Các đồng coin cách nhau 1f

public class SpawmCoins : MonoBehaviour
{
    public Transform _player; // Ánh xạ lấy vị trí người chơi
    public GameObject _coinPrefab; // Ánh xạ tới prefab coin sẽ vẽ ra
    public int _coinNumber; // Số coin sẽ vẽ ra
    public float _timeToSpawm; //Thời gian mỗi lần sinh thêm coin
    private float _distantBetweenPlayer; //Khoảng cách vẽ với người chơi
    private float _heightOffset; //Chiều cao tối thiểu khi sinh coin
    private float _time; //Tính thời gian vẽ
    void Start()
    {
        _coinNumber = 11;
        _timeToSpawm = 5f;
        _distantBetweenPlayer = 20f;
        _heightOffset = 2f;
        _time = 0;
        GenerateCoin();
    }

    void Update()
    {
        _time += Time.deltaTime;
        if (_time > _timeToSpawm)
        {
            GenerateCoin();
            _time = 0;
        }
    }

    private void GenerateCoin()
    {
        int _coinNumber2 = (int)(_coinNumber / 2);
        float _a; //Độ cong của parabol , ngẫu nhiên
        _a = Random.Range(0.08f, 0.12f);
        float _b; //Độ chênh lệch chiều cao, ngẫu nhiên
        _b = Random.Range(-0.5f, 1f);
        Vector3 _nextPos; //Vị trí vẽ coin tiếp theo
        _nextPos = _player.position + new Vector3(_distantBetweenPlayer, _heightOffset, 0);

        for (int i= -1*_coinNumber2; i <= _coinNumber2; i++)
        {
            Vector3 _drawPos = _nextPos + new Vector3(i + _coinNumber2, -1 * _a * i * i + _a * _coinNumber + _b, 0);
            Instantiate(_coinPrefab, _drawPos, Quaternion.identity, transform);
        }


    }
}
