using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIAnimatorControl : MonoBehaviour
{



    private playerController PlayerController;

    public Sprite PlayerOneImage;
    public Sprite PlayerTwoImage;

    public Animator PlayerChange;

    public bool AnimationActive;

    Image m_Image;

    // Use this for initialization
    void Start()
    {
        m_Image = GetComponent<Image>();
        PlayerController = GameObject.Find("Character").GetComponent<playerController>();
        AnimationActive = true;
    }



    public void StopAnimation()
    {
        AnimationActive = false;
    }
        
    // Update is called once per frame
    void Update()
    {
        switch (PlayerController.currentPlayer)
        {
            case playerController.CurrentPlayer.playerOne:
                m_Image.sprite = PlayerOneImage;
                break;
            case playerController.CurrentPlayer.playerTwo:
                m_Image.sprite = PlayerTwoImage;
                break;                
        }
    }
}

