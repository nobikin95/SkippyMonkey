using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameOverScene : MonoBehaviour {

    public Text score;
    public Text highScoreTxt;

    void Start() {
        score.text = "Your Score : " + PlayerPrefs.GetInt("ThisScore").ToString();
        highScoreTxt.text = PlayerPrefs.GetInt("HighScore").ToString();
       
    }
    

    public void OnStartButtonTapped()
    {   
        TKSceneManager.ChangeScene("PlayScene");
    }
}
