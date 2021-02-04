using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FlyControl : MonoBehaviour {

    public float shipSpeed = 5.0f;
    private Vector3 shipPos;
    private Vector3 endPos;
    float shipH;
    float shipV;
    public float life = 100f;
    //public float speed = 20f;
    GenerateInfinite life_text;
    public static int weapon_qty = 1;
    public int weapon_lvl = 1;
    public GameObject weapon;
  
    // Update a cada frame
    void Update () {

        if (life <= 0.0f){

            life = 0.0f;

            GameOver();
           

        }
        //Show weapons
        weapon.transform.GetChild(0).gameObject.SetActive(weapon_qty != 2);
        weapon.transform.GetChild(1).gameObject.SetActive(weapon_qty != 1);
        weapon.transform.GetChild(2).gameObject.SetActive(weapon_qty != 1);
        
        shipH = SimpleInput.GetAxis("Horizontal");
        shipV = SimpleInput.GetAxis("Vertical");

        if (shipH > 0 && transform.position.x > 10){
            shipH = 0;
        } else if (shipH < 0 && transform.position.x < -10){
            shipH = 0;
        }
        
        if (shipV > 0 && transform.position.y > 15){
            shipV = 0;
        } else if (shipV < 0 && transform.position.y < 7){
            shipV = 0;
        }


        shipPos = new Vector3(shipH, shipV);
        
        if (transform.rotation.z < 0.2 && shipH < 0 ||
            transform.rotation.z > -0.2 && shipH > 0){
                transform.Rotate(0, 0, shipH * -5);
                //Debug.Log(transform.rotation.z);
        }

        if (transform.rotation.z > 0.01 && shipH == 0f){
            transform.Rotate(0,0,-1);
        } else if (transform.rotation.z < -0.01 && shipH == 0f){
            transform.Rotate(0,0,1);
        }
        
        transform.position += (shipPos * shipSpeed * Time.deltaTime);
        //transform.position += transform.forward * speed * (Time.deltaTime);

        //transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(endPos), Mathf.Deg2Rad * (100.0f));
        
	}

    void GameOver()
    {

        int score = GenerateInfinite.score_counter;


        List<int> highscores = new List<int>();
        highscores.Add(PlayerPrefs.GetInt("Highscore_1", 0));
        highscores.Add(PlayerPrefs.GetInt("Highscore_2", 0));
        highscores.Add(PlayerPrefs.GetInt("Highscore_3", 0));
        highscores.Add(PlayerPrefs.GetInt("Highscore_4", 0));
        highscores.Add(PlayerPrefs.GetInt("Highscore_5", 0));
        highscores.Add(score);

        highscores.Sort();


        PlayerPrefs.SetInt("Highscore_1", highscores[highscores.Count - 1]);
        PlayerPrefs.SetInt("Highscore_2", highscores[highscores.Count - 2]);
        PlayerPrefs.SetInt("Highscore_3", highscores[highscores.Count - 3]);
        PlayerPrefs.SetInt("Highscore_4", highscores[highscores.Count - 4]);
        PlayerPrefs.SetInt("Highscore_5", highscores[highscores.Count - 5]);



        for (int i = 0; i < 5; i++)
        {
            Debug.Log("SCORE " + highscores[i] + ": " + highscores);
        }



        /*

        int[] highscores = new int[6] {
            PlayerPrefs.GetInt("Highscore_1", 0),
            PlayerPrefs.GetInt("Highscore_2", 0),
            PlayerPrefs.GetInt("Highscore_3", 0),
            PlayerPrefs.GetInt("Highscore_4", 0),
            PlayerPrefs.GetInt("Highscore_5", 0),
            0
        };

        int score = GenerateInfinite.score_counter;

        int i;
        int teste = 0;

        for (i = 0; i < 5; i++)
        {
            if (highscores[i] < score && highscores[i+1] > score)
            {
                highscores[6] = score;
            }
        }

        //Array.Sort(highscores);
        */

        this.gameObject.SetActive(false);
        //Debug.Log("I: " + i);
        //Debug.Log("Teste: " + teste);

        SceneManager.LoadScene(0); //CENAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA
    }

    
        
        
}
    

