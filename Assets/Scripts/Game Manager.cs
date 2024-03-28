using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Cinemachine.DocumentationSortingAttribute;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    //public static GameManager Instance;// { get => instance; private set; }
    public int _stage { get; private set; }
    public int _lives { get; private set; }
    public int _coins { get; private set; }

    private void Awake()
    {
        if (instance!= null)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        _coins = 0;
    }

    private void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
        }
    }
    void Start()
    {
        NewGame();
    }

    void Update()
    {
        
    }

    private void NewGame()
    {
        //Thiết lập số mạng, số coin ban đầu
        _lives = 3;
        _coins = 0;
        _stage = 1;
        LoadLevel(_stage);
    }

    private void LoadLevel(int _stage)
    {
        this._stage = _stage;
        //SceneManager.LoadScene(_stage);
    }

    //Tăng 1 coin
    public void AddCoin()
    {
        _coins++;
    }
    
}


// Hướng comment test
// Hướng comment 2