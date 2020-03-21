using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour {

	public delegate void GameDelegate ();
	public static event GameDelegate OnGameStarted;
	public static event GameDelegate OnGameOverConfirmed;

	public static GameManager Instance;
	public GameObject startPage;
	public GameObject gameOverPage;
	public GameObject countdownPage;
    public GameObject settingPage;
	public Text scoreText;
    public GameObject planeObject;

    public GameObject scoretext;
   

    enum PageState
    {
		None,
		Start,
		GameOver,
		Countdown
	}

	int score = 0;
	bool gameOver = true;

	public bool GameOver { get { return gameOver; } }

	void Awake(){
	
		Instance = this;
	}

	void OnEnable(){
		CountdownText.OnCountdownFinished += OnCountdownFinished;
		TapController.OnPlayerDied += OnPlayerDied;
		TapController.OnPlayerScored += OnPlayerScored;
      

    }

    void OnDisable(){
		CountdownText.OnCountdownFinished -= OnCountdownFinished;
		TapController.OnPlayerDied -= OnPlayerDied;
		TapController.OnPlayerScored -= OnPlayerScored;


    }

    void OnCountdownFinished(){
		SetPageState (PageState.None);
		OnGameStarted();
		score = 0;
          scoretext.SetActive(true);
        gameOver = false;
	
	}

	void OnPlayerDied(){
		gameOver = true;
		int savedScore = PlayerPrefs.GetInt ("highscore");
		if (score > savedScore) {
			PlayerPrefs.SetInt ("highscore", score);
		
		}
		SetPageState (PageState.GameOver);
	}

    void OnPlayerScored()
    {

        score++;
        scoreText.text = score.ToString();
    }
   

    void SetPageState(PageState state){

		switch (state) {

		case PageState.None:
			startPage.SetActive (false);
			gameOverPage.SetActive (false);
			countdownPage.SetActive (false);
			break;
		case PageState.Start:
			startPage.SetActive (true);
			gameOverPage.SetActive (false);
			countdownPage.SetActive (false);
			break;
		case PageState.GameOver:
			startPage.SetActive (false);
			gameOverPage.SetActive (true);
			countdownPage.SetActive (false);
			break;
		case PageState.Countdown:
			startPage.SetActive (false);
			gameOverPage.SetActive (false);
			countdownPage.SetActive (true);
			break;

		}
	}

	public void ConfirmedGameOver(){
			OnGameOverConfirmed();
		scoreText.text="0";
        scoretext.SetActive(false);
		SetPageState (PageState.Start);
	}
	public void StartGame(){
		SetPageState(PageState.Countdown);
	}
    public void Setting()
    {
        startPage.SetActive(false);
        settingPage.SetActive(true);
        planeObject.SetActive(false);



    }
    public void toStartPage()
    {
        settingPage.SetActive(false);
        startPage.SetActive(true);
        planeObject.SetActive(true);
    }
    
}
