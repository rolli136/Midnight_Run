using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField] private GameObject _textGameOver;
    [SerializeField] private GameObject _textGameCompleted;
    //private bool gameOver = false;

    void Start()
    {
        //Disable all displays
        _textGameOver.SetActive(false);
        _textGameCompleted.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        _textGameOver.SetActive(true);

    }

    public void LevelCompleted()
    {
        _textGameCompleted.SetActive(true);
    }
}
