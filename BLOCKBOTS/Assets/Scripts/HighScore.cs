using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{ 
    public Text HsText;
    void Start()
    {
        HsText.text = "SCORE: " + PlayerPrefs.GetInt("score");
    }
  
}
