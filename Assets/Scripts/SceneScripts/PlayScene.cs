using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayScene : MonoBehaviour {
    public static PlayScene Instance { get; private set; }
    public Text scoreDisplay;

    private int score = 0;
    int lowestHighScore = 0;

    public void Awake() {
        Instance = this;
    }
    public void Score() {
        score++;
        scoreDisplay.text = score.ToString();
    }

    public void GameOver()
    {
        int lengthOfListPlayer = PlayerPrefs.GetInt("length");
        PlayerPrefs.SetInt("ThisScore", score);
        PlayerPrefs.Save();

        if (score > lowestHighScore) {
            lowestHighScore = score;
            PlayerPrefs.SetInt("Score"+lengthOfListPlayer, score);
            PlayerPrefs.Save();

            lengthOfListPlayer++;
            PlayerPrefs.SetInt("length", lengthOfListPlayer);
            PlayerPrefs.Save();
        }

        FindObjectOfType<CameraController>().ScreenShake();
        StartCoroutine(AnimateGameOver());

    }


    private IEnumerator AnimateGameOver() {
       
        yield return new WaitForSeconds(2);
        TKSceneManager.ChangeScene("GameOverScene");
    }
}
