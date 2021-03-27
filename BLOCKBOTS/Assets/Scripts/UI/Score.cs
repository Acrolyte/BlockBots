using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text txt;
    public int point = 0;

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex > 1)
        {
            point = PlayerPrefs.GetInt("score");
        }
        else
        {
            point = 0;
        }
    }

    private void Update()
    {
        txt.text = "Score " + point;
        PlayerPrefs.SetInt("score",point);
        
    }

    public void IncreaseScore(int points)
    {
        point += 10;
    }
    
}
