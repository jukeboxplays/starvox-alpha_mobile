using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour {

    public static bool playStarted = false;
    public static int playCount = 0;

    GameObject objectScore;

    public static TextMeshProUGUI scr_1;
    public static TextMeshProUGUI scr_2;
    public static TextMeshProUGUI scr_3;
    public static TextMeshProUGUI scr_4;
    public static TextMeshProUGUI scr_5;

    List<int> scores = new List<int>();

    void Start ()
    {
        List<int> highscores = new List<int>();
        highscores.Add(PlayerPrefs.GetInt("Highscore_1", 0));
        highscores.Add(PlayerPrefs.GetInt("Highscore_2", 0));
        highscores.Add(PlayerPrefs.GetInt("Highscore_3", 0));
        highscores.Add(PlayerPrefs.GetInt("Highscore_4", 0));
        highscores.Add(PlayerPrefs.GetInt("Highscore_5", 0));

        highscores.Sort();

        PlayerPrefs.SetInt("Highscore_1", highscores[highscores.Count - 1]);
        PlayerPrefs.SetInt("Highscore_2", highscores[highscores.Count - 2]);
        PlayerPrefs.SetInt("Highscore_3", highscores[highscores.Count - 3]);
        PlayerPrefs.SetInt("Highscore_4", highscores[highscores.Count - 4]);
        PlayerPrefs.SetInt("Highscore_5", highscores[highscores.Count - 5]);


        objectScore = GameObject.FindWithTag("Score");
        scr_1 = objectScore.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        scr_2 = objectScore.transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        scr_3 = objectScore.transform.GetChild(3).GetComponent<TextMeshProUGUI>();
        scr_4 = objectScore.transform.GetChild(4).GetComponent<TextMeshProUGUI>();
        scr_5 = objectScore.transform.GetChild(5).GetComponent<TextMeshProUGUI>();

        scr_1.text = PlayerPrefs.GetInt("Highscore_1", 0).ToString();
        scr_2.text = PlayerPrefs.GetInt("Highscore_2", 0).ToString();
        scr_3.text = PlayerPrefs.GetInt("Highscore_3", 0).ToString();
        scr_4.text = PlayerPrefs.GetInt("Highscore_4", 0).ToString();
        scr_5.text = PlayerPrefs.GetInt("Highscore_5", 0).ToString();


    }



    public void StartGame() {

        playStarted = true;
        playCount += 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }

    public void StartCredits()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
