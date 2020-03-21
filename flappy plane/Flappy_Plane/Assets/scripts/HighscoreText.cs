using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class HighscoreText : MonoBehaviour {

	Text highscore;
    int high;
    public GameObject plane1;
    public GameObject plane2;
    public GameObject plane1notrelieved;
    public GameObject plane2notrelieved;


    void OnEnable()
    { highscore = GetComponent<Text> ();
        high = PlayerPrefs.GetInt("highscore");
        highscore.text = "High Score : " + PlayerPrefs.GetInt ("highscore").ToString();
        if (high > 30)
        {
            plane1.SetActive(true);
            plane1notrelieved.SetActive(false);
        }
        if (high > 50)
        {
            plane2.SetActive(true);
            plane2notrelieved.SetActive(false);
        }

    }	
}
