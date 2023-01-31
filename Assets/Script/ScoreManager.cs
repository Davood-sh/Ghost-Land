using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ScoreManager : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI highScoreText;   
       
    public static int score;
    
    Text text;
    // Start is called before the first frame update
    void Start()
    {
        UpdateHighScoreText();
        score = 0;        
        text = GetComponent<Text>();     
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if(score < 1)
        score = 0;        
        text.text = ""+score; 
                     
    }
    public static void AddPoints(int pointToAdd)
    {
        score += pointToAdd;
        checkHighScore();
        
    }
    public static void reset(){
        score = 0;
    }
    public static void checkHighScore()
    {
        if(score > PlayerPrefs.GetInt("HighScore",0))
        {
            PlayerPrefs.SetInt("HighScore",score);
        }
    }
    void UpdateHighScoreText()
    {
        highScoreText.text = $"HighScore:{PlayerPrefs.GetInt("HighScore",0)}";
    }
   

    
}
