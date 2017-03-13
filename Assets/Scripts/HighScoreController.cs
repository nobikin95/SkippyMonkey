using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HighScoreController : MonoBehaviour {

    public InputField PlayerNameTxt;
    public Text myScoreTxt;
    public Text highScoreTxt;
    private int highScore = 0;

    List<PlayerData> scoreBoard = new List<PlayerData>();
    class PlayerData 
    {
        public string name;
        public int score;
        public PlayerData(string _name, int _score)
        {
            this.name = _name;
            this.score = _score;
        }
        public string getName()
        {
            return this.name;
        }
        public int getScore()
        {
            return this.score;
        }
    }

    public void ViewScoreBoard() {
        scoreBoard.Clear();
        int lengthOfListPlayer =  PlayerPrefs.GetInt("length");
        
        for (int i = 0; i < lengthOfListPlayer; i++)
        {
            string playername = PlayerPrefs.GetString("PlayerName" + i.ToString() )  ;
            int score = PlayerPrefs.GetInt("Score" + i.ToString() );
            PlayerData newPlayer = new PlayerData(playername, score);
            scoreBoard.Add(newPlayer);
            
        }
        
        while (lengthOfListPlayer >10)
        {
            scoreBoard.RemoveAt(lengthOfListPlayer - 1);
            lengthOfListPlayer--;
        }
        Debug.Log(lengthOfListPlayer);
        PlayerPrefs.SetInt("length", lengthOfListPlayer);
        PlayerPrefs.Save();

        for (int i = 0; i < scoreBoard.Count; i++)
        {
            highScoreTxt.text += scoreBoard[i].getName() + " :  ---- " + scoreBoard[i].getScore()+"\n";
        }
        
    }

    public void PlayerInput() {
        string playerName = PlayerNameTxt.text;
        int lengthOfListPlayer = PlayerPrefs.GetInt("length");

        PlayerPrefs.SetString("PlayerName"+(lengthOfListPlayer-1),playerName);
        PlayerPrefs.Save();

        ViewScoreBoard();

        highScoreTxt.gameObject.SetActive(true);
    }
    
    
}
