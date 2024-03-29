using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

//Lấy ngẫu nhiên trong danh sách mặt đất để tạo các ô bản đồ mới
//Mỗi lần tạo ra _numMap ô mới
//Mỗi ô cách nhau khoảng cách ngẫu nhiên trong khoảng _spaceMin.._spaceMax

public class randomMap : MonoBehaviour
{
    public GameObject _plantPrefeb;
    public GameObject _boarPrefab;

    //Mảng các block bản đồ. Gán các bản đồ nguyên bản vào mảng này từ cửa sổ project
    public List<GameObject> listGround; 
    //Gán nhân vật để lấy vị trí (kéo thả player ngoài cửa sổ  project)
    public Transform player; 
    //Khoảng cách để tạo sẵn map và hủy
    public float rangeToDestroyObject = 40f; 
    //Khoảng cách ngẫu nhiên giữa hai ô map
    public float _spaceMin;
    public float _spaceMax;
    //Số ô map mới được tạo ra mỗi lần
    public int _numMap = 5;
    //Cao độ khi sinh ô map mới
    public float _heightPos = -2f;
    //Bề rộng mỗi ô map mới sinh ra
    private int _groundLen;
    private int _groundHeight;
    //Tọa độ trục Z của layer cha sinh map
    private float _z;

    private Vector3 _endPos; //Vị trí cuối cùng
    private Vector3 _nextPos; //Vị trí tiếp theo sẽ tạo ô map mới

    void Start()
    {
        _spaceMin = 2f;
        _spaceMax = 5f;
        _numMap = 5;
        _z = transform.position.z;
        _endPos = new Vector3(18.0f, _heightPos, _z); 
        generateBlockMap();
    }

    void Update()
    {
        //Nếu khoảng cách từ người chơi đến _endPos gần hơn mức quy định thì tiếp tục sinh map mới
        if (Vector2.Distance(player.position, _endPos) < rangeToDestroyObject)
        {
            generateBlockMap();
        }
    }
    void generateBlockMap ()
    {
        for (int i = 0; i < _numMap; i++)
        {
            //Khoảng cách ngẫu nhiên giữa các block
            float _spaceToNext = Random.Range(_spaceMin, _spaceMax);
            //Vị trí tạo ô map mới
            _nextPos = new Vector3(_endPos.x + _spaceToNext, _heightPos, _z); 
            //Tạo số nguyên ngẫu nhiên trong khoảng từ a-b, không bao gồm b
            //Lấy ô ground ngẫu nhiên trong danh sách
            int _groundID = Random.Range(0, listGround.Count);
            //Tạo ra block bản đồ ngẫu nhiên, gán vào mảng 
            Instantiate(listGround[_groundID], _nextPos, Quaternion.identity, transform);

            switch (_groundID) //Tính độ rộng theo ô nền đất ngẫu nhiên đã chọn
            {
                case 0: _groundLen = 2; _groundHeight = 2; break;
                case 1: _groundLen = 3; _groundHeight = 2; break;
                case 2: _groundLen = 4; _groundHeight = 2; break;
                case 3: _groundLen = 6; _groundHeight = 2; break;
                case 4: _groundLen = 8; _groundHeight = 3; break;
                case 5: _groundLen = 3; _groundHeight = 3; break;
                case 6: _groundLen = 13; _groundHeight = 4; break;
            }

            float _xacSuat = Random.Range(0, 1f);
            if (_xacSuat < 0.3f)
            {
                Instantiate(_plantPrefeb, new Vector3(_nextPos.x + 1, _nextPos.y + _groundHeight, _z), Quaternion.identity, transform); ;
            } else if (_xacSuat > 0.7f)
            {
                Instantiate(_boarPrefab, new Vector3(_nextPos.x + 1, _nextPos.y + _groundHeight, _z), Quaternion.identity, transform); ;
            }    

            //Tính lại vị trí cuối mới
            _endPos = new Vector3(_nextPos.x + _groundLen, _heightPos, _z);
        }
    }
}
