using System.Collections;
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

    private int i_PlayeroneScore;
    private int i_PlayerTwoScore;
    private int i_PlayerThreeScore;
    private int i_PlayerFourScore;




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

            PlayerOneScoreText.text = scoreBaseText + i_PlayeroneScore;
            PlayerTwoScoreText.text = scoreBaseText + i_PlayerTwoScore;

            Timer = TimerStartingPoint;

            HasRun = false;

        }
        else
        {
            StartingPlayerTextAnimation();
            PlayerOneScoreText.text = scoreBaseText + i_PlayeroneScore;
            PlayerTwoScoreText.text = scoreBaseText + i_PlayerTwoScore; 
        }

    }


	
	// Update is called once per frame
	void Update () {
        
        PlayerOneScoreText.text = scoreBaseText + i_PlayeroneScore;
        PlayerTwoScoreText.text = scoreBaseText + i_PlayerTwoScore; 

    }  
    public void UpdateScores(int p1, int p2, int p3, int p4)
    {
         i_PlayeroneScore = p1;
         i_PlayerTwoScore = p2;
        
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
