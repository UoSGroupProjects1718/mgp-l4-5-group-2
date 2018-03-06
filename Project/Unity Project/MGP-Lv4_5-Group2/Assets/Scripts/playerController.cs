using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {
    /// <Public Variables>
    /// - functions that anyone can access, PRogram, Editor, third party sources etc.
    /// </Public Variables>
    

    public float pf_HorizontalMoveSpeed = 10;              //Movement Speed for the horizontal directional axis.
    public float pf_RotationSpeed = 10;                    //Movement speed for the rotation of the character.
    public float pf_FlyingSpeed = 10;                       //Characters movment when flying

    public float pf_HorizonatalEndPosition; 

    public float pf_YAxisStartingPosition = -2;                  //How high we wwant the character starting
    public float pf_XAxistStartingPosition = 0;
    public GameObject MainCharacter;

    
    public Transform PlayerOneBEE;

    public Rigidbody2D playerOneBEE;
    
    public float BeeFlyingSpeed = 9;


    public float RotationSpeed;



    /// <Private Variables>
    ///  - Functions only the inside of the program/code can access
    /// </Private Variables>
    

        

    private float f_xAxisPosition;
    private float f_yAxisPositon;
    
   

    private int i_Player1Points;
    private int i_Player2Points;

    private bool b_Stage1 = true;                                  //Horizontal Sliding Stage - Stage 1
    private bool b_Stage2;                                  //Rotational Stage - Stage 2
    private bool b_Stage3;                                  //Power Stage - stage 3

    private bool b_Player1Turn;
    private bool b_Player2Turn;

    private float moveSpeed;

    bool MovingLeft = true;
    bool MovingRight = false;

    private Vector3 CharacterPosition;

    private float RotationAngle = 90;
    private float RotationMovementChunk = 1;
    


    private bool StartRotationDone = false;

    private bool IsPlayerBouncing;

    private Rigidbody2D rb;
    


    enum RotateDir
    {
        left, 
        right
    }

    enum CurrentPlayer
    {
        playerOne, 
        playerTwo
    }

    public float speed;
    RotateDir dir;
    CurrentPlayer currentPlayer;

    // Use this for initialization
    void Start () {

        moveSpeed = pf_HorizontalMoveSpeed * Time.deltaTime;

        CharacterPosition.x = pf_XAxistStartingPosition;
        CharacterPosition.y = pf_YAxisStartingPosition;
        CharacterPosition.z = 0;

        dir = RotateDir.right;

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "WallBoundry")
        {
            Debug.Log("We Have Collided");
            if (moveSpeed > 0) //check the number is above 0 - Moving left
            {
                Debug.Log("Move Speed is Moving Left");
                moveSpeed = -moveSpeed;

            }
            else if (moveSpeed < 0)
            {
                Debug.Log("Move Speed is Now Moving right");
                moveSpeed = -moveSpeed;
            }
        }
    }

    void TruthTable()
    {
        if (b_Stage1 == true)
        {
            b_Stage1 = false;
            b_Stage2 = true;
        }
        else if (b_Stage2 == true)
        {
            b_Stage2 = false;
            b_Stage3 = true;
        }
        else if (b_Stage3 == true)
        {

        }
    }

    void MoveCharacterLoop()
    {
        MainCharacter.transform.Translate(moveSpeed, 0, 0, Space.World);
    }

    void RotateCharacterLoop()
    {
        float TargetRotation = 90.0f;
        
        if (!StartRotationDone)
        {

            float angle = transform.rotation.eulerAngles.z;

            transform.rotation = Quaternion.Euler(0, 0, RotationMovementChunk * ((RotationSpeed * 5) * Time.time));

            
           if (angle >= TargetRotation)
            {
                print("We hit our target rotation");
                StartRotationDone = true;
            }           
        }
        else
        {
            transform.rotation = Quaternion.Euler(0f, 0f, RotationAngle * Mathf.Sin((RotationSpeed / 10) * Time.time));
        }
    }

    void PlayersTurnSwitch()
    {
        if(b_Player1Turn == true)
        {
            b_Player2Turn = true;
            b_Player1Turn = false;
        }
        else
        {
            b_Player1Turn = true;
            b_Player2Turn = false;
        }
    }

    // Update is called once per frame
    void Update () {

        
        float MainCharacterCurrentPos = MainCharacter.transform.position.x;
        

        
        if(Input.GetKeyDown(KeyCode.Space))
        {
            TruthTable();
        }
        

        //Main Stage Loop

        if (b_Stage1)
        {
            //////////
            // - Horizontal Movment Stage
            /////////
            
            MoveCharacterLoop();
        }
        else if(b_Stage2)
        {
            /////////
            // - Rotation Stage of the Game
            ////////


            RotateCharacterLoop();

            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if(StartRotationDone)
                {
                    b_Stage2 = false;
                    return;
                }                
            }                                
        }


        if(Input.GetKeyDown(KeyCode.Space) && b_Stage3)
        {
            /////////
            // Player Firing Stage
            ////////

            if (!IsPlayerBouncing)
                
            {
                rb = GetComponent<Rigidbody2D>();

                
                Vector3 startPos = transform.position;
                Quaternion shotAngle = transform.rotation;

                MainCharacter.transform.Translate(5, 0, 0);                

                float shotAngleFloat = shotAngle.z;              
                Vector3 dir = Quaternion.AngleAxis(shotAngleFloat, Vector3.up) * startPos;   
                var angle = (shotAngleFloat * 100);
                var player = Instantiate(playerOneBEE, startPos, Quaternion.identity);
                var shootDir = Quaternion.Euler(0, 0, angle) * Vector3.up;
                player.GetComponent<Rigidbody2D>().velocity = shootDir * BeeFlyingSpeed;

                IsPlayerBouncing = true;
            }

        }


    }
}
