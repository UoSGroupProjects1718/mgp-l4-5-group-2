using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

    //Public Variables - functions that anyone can access, PRogram, Editor, third party sources etc.

    public float pf_HorizontalMoveSpeed = 10;              //Movement Speed for the horizontal directional axis.
    public float pf_RotationSpeed = 10;                    //Movement speed for the rotation of the character.
    public float pf_FlyingSpeed = 10;                       //Characters movment when flying

    public float pf_HorizonatalEndPosition; 

    public float pf_YAxisStartingPosition = -2;                  //How high we wwant the character starting
    public float pf_XAxistStartingPosition = 0;
    public GameObject MainCharacter;

    //Private Variables - Functions only the inside of the program/code can access

    
    private float f_StartingRotation = 90;

    private float f_xAxisPosition;
    private float f_yAxisPositon;

    private float f_currentRotation;
   

    private int i_Player1Points;
    private int i_Player2Points;

    private bool b_Stage1 = true;                                  //Horizontal Sliding Stage - Stage 1
    private bool b_Stage2;                                  //Rotational Stage - Stage 2
    private bool b_Stage3;                                  //Power Stage - stage 3

    private bool b_Player1Turn;
    private bool b_Player2Turn;

    bool MovingLeft = true;
    bool MovingRight = false;

    private Vector3 CharacterPosition;

    

    Quaternion rotation;


    // Use this for initialization
    void Start () {

        CharacterPosition.x = pf_XAxistStartingPosition;
        CharacterPosition.y = pf_YAxisStartingPosition;
        CharacterPosition.z = 0;
    }
	
	// Update is called once per frame
	void Update () {

        
        float MainCharacterCurrentPos = MainCharacter.transform.position.x;
        float moveSpeed = pf_HorizontalMoveSpeed * Time.deltaTime;

        

        if (MainCharacter.transform.position.x >= 7 || MovingLeft == true)
        {
            moveSpeed = -moveSpeed;

            if (MovingLeft == true)
            {
                MovingLeft = false;
                MovingRight = true;
            }
        }
        

        //else if (MainCharacter.transform.position.x <= -7 && MovingRight == true)
        //{
        //    moveSpeed = +moveSpeed;

        //    if (MovingRight == true)
        //    {
        //        MovingLeft = true;
        //        MovingRight = false;
        //    }
        //}




        if (b_Stage1)
        {            
                MainCharacter.transform.Translate(moveSpeed, 0, 0, Space.World);  
        }
        else if(b_Stage2)
        {
            rotation = Quaternion.Euler(0, 90, 0); // this adds a 90 degrees Y rotation
                                                   //var adjustRotation = transform.rotation.y + rotationAdjust; //<- this is wrong!
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime);
        }
        else if(b_Stage3)
        {

        }

    }
}
