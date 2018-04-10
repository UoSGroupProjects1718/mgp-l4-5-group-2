﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class uiController : MonoBehaviour {

    public Text PlayerOneScoreText;
    public Text PlayerTwoScoreText;
    public Text text_CountdownTimer;
    public Text text_AnimatedText;

    public Text PlayerAnimatedText;


    public float TimerStartingPoint;

    private float f_PlayeroneScore;
    private float f_PlayerTwoScore;


    private string scoreBaseText = "Score:   ";
    private float carryoverScore;
    
    private float Timer;

    private string AnimatedTextFiller;


    private bool HasRun;


	// Use this for initialization
	void Start () {

        PlayeranimatedTextFilling();

        if (HasRun == true)
        {         

            PlayerOneScoreText.text = scoreBaseText + f_PlayeroneScore;
            PlayerTwoScoreText.text = scoreBaseText + f_PlayerTwoScore;
            Timer = TimerStartingPoint;

            HasRun = false;

        }
        else
        {
            StartingPlayerTextAnimation();
            PlayerOneScoreText.text = scoreBaseText + f_PlayeroneScore;
            PlayerTwoScoreText.text = scoreBaseText + f_PlayerTwoScore;
        }

    }


	
	// Update is called once per frame
	void Update () {
		
        if (Input.GetKeyDown(KeyCode.Space))
        {
            f_PlayeroneScore = f_PlayeroneScore + 5;
        }

        
        PlayerOneScoreText.text = scoreBaseText + f_PlayeroneScore;
        PlayerTwoScoreText.text = scoreBaseText + f_PlayerTwoScore;

        TimerCountdown(TimerStartingPoint, Timer);
    }

    public void TimerCountdown(float timerStart, float Timer)
    {

        //Timer -= 1 * Time.deltaTime;

        //text_CountdownTimer.text = Timer.ToString();


    }

    public void PlayeranimatedTextFilling()
    {
        AnimatedTextFiller = "'s Turn!";
    }

    public void StartingPlayerTextAnimation()
    {
        PlayerAnimatedText.text = "Player One" + AnimatedTextFiller;
    }

    public void NewPlayerAnimation(string CurrentPlayer)
    {
        PlayerAnimatedText.text = CurrentPlayer + AnimatedTextFiller;
    }

}
