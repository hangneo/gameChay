using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class randomMap : MonoBehaviour
{
    //Mảng các block bản đồ. Gán các bản đồ nguyên bản vào mảng này từ cửa sổ project
    public List<GameObject> listGround; 
    //Gán nhân vật để lấy vị trí (kéo thả player ngoài cửa sổ  project)
    public Transform player; 
    //Khoảng cách để tạo sẵn map và hủy
    public float rangeToDestroyObject = 40f; 
    //Khoảng cách ngẫu nhiên giữa hai ô map
    public float spaceMin = 2f;
    public float spaceMax = 5f;
    //Số ô map mới được tạo ra mỗi lần
    public int numMap = 5;
    //Cao độ khi sinh ô map mới
    public float heightPos = -2f;
    //Mảng chứa các block map được tạo ra
    public List<GameObject> listGroundOld; 

    Vector3 endPos; //Vị trí cuối cùng
    Vector3 nextPos; //Vị trí tiếp theo sẽ tạo ô map mới
    int groundLen; //Bề rộng mỗi ô map mới sinh ra 

    void Start()
    {
        endPos = new Vector3(18.0f, heightPos, 0.0f); 
        generateBlockMap();
    }

    void Update()
    {
        //Nếu khoảng cách từ người chơi đến endPos gần hơn mức quy định thì tiếp tục sinh map mới
        if (Vector2.Distance(player.position, endPos) < rangeToDestroyObject)
        {
            generateBlockMap();
        }

        //Lấy đối tượng Map đầu tiên trong danh sách, so sánh vị trí nếu đã đi qua xa thì hủy 
        GameObject getOneGround = listGroundOld.FirstOrDefault();
        if (getOneGround != null && Vector2.Distance(player.position, getOneGround.transform.position) > rangeToDestroyObject)
        {
            listGroundOld.Remove(getOneGround);
            Destroy(getOneGround);
        }
    }

    void generateBlockMap ()
    {
        for (int i = 0; i < numMap; i++)
        {
            float spaceToNext = Random.Range(spaceMin, spaceMax); //Khoảng cách ngẫu nhiên giữa các block
            nextPos = new Vector3(endPos.x + spaceToNext, heightPos, 0f); //Vị trí tạo ô map mới

            //Tạo số nguyên ngẫu nhiên trong khoảng từ a-b, không bao gồm b
            int groundID = Random.Range(0, listGround.Count);

            //Tạo ra block bản đồ ngẫu nhiên, gán vào mảng 
            GameObject newGround = Instantiate(listGround[groundID], nextPos, Quaternion.identity, transform);
            listGroundOld.Add(newGround); //Thêm miếng đất vừa tạo vào mảng

            switch (groundID) //Tính độ rộng Map ngẫu nhiên
            {
                case 0: groundLen = 2; break;
                case 1: groundLen = 3; break;
                case 2: groundLen = 4; break;
                case 3: groundLen = 6; break;
                case 4: groundLen = 8; break;
                case 5: groundLen = 3; break;
                case 6: groundLen = 13; break;
            }

            endPos = new Vector3(nextPos.x + groundLen, heightPos, 0f);
        }
    }
}
