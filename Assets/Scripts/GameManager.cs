using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField] private GameObject _textGameOver;
    [SerializeField] private GameObject _textGameCompleted;
    [SerializeField] private GameObject _coinCounter;
    private float currentCoins = 0; 
    //private bool gameOver = false;

    void Start()
    {
        //Disable all displays
        _textGameOver.SetActive(false);
        _textGameCompleted.SetActive(false);
        _coinCounter.GetComponent<Text>().text = currentCoins.ToString();
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

    public void updateCoinCount()
    {
        currentCoins += 10; 
        _coinCounter.GetComponent<Text>().text = currentCoins.ToString();
    }
}
