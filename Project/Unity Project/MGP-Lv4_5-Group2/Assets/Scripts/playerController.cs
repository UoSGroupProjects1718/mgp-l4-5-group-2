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


    public Rigidbody playerOneBee;
    public Rigidbody playerTwoBee;
    public Transform PlayerOneBEE;

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

    private float moveSpeed;

    bool MovingLeft = true;
    bool MovingRight = false;

    private Vector3 CharacterPosition;

    private float RotationAngle = 180;

    private bool StartRotationDone = false;

    private Rigidbody rb;
    

    Quaternion rotation;

    private float RotationCount;


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
            MoveCharacterLoop();
        }
        else if(b_Stage2)
        {

            //Start Rotation
            //Rotate 90 degrees

            float rotationSpeed = 1;

            float step = speed * Time.deltaTime;

            // If we're rotating left
            if (dir == RotateDir.left)
            {
                Debug.Log("Rotating Left");
                // Rotate to the left
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, step);
                //transform.rotation = Quaternion.Slerp(transform.rotation, rotation, step);
               

                // If we reach min angle, rotate right
                if (transform.localRotation.z == -90)
                {
                    dir = RotateDir.right;
                }
            }
            // Else if we're rotating to the right
            else if (dir == RotateDir.right)
            {
                Debug.Log("Rotating Right");
                // Rotate to the right
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, step);
                //transform.rotation = Quaternion.Slerp(transform.rotation, rotation, step);

                // If we reach max angle, rotate left
                if (transform.localRotation.z == 90)
                {
                    dir = RotateDir.left;
                }
            }
            




            //transform.Rotate(Vector3.left * (rotationSpeed * Time.deltaTime));


            //if(!StartRotationDone)
            //{
            //    rotation = Quaternion.Euler(0, 0, RotationAngle); // this adds a 90 degrees Y rotation
            //    transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime);
            //    RotationCount++;
            //    Debug.Log(RotationCount);

            //    if(RotationCount == RotationAngle)
            //    {
            //        StartRotationDone = true;
            //        RotationAngle = 180;
            //    }


            //}

            

            while (StartRotationDone)
            {

                rotation = Quaternion.Euler(0, 0, RotationAngle);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime);



                if (Input.GetKeyDown(KeyCode.Space))                 
                {
                    b_Stage2 = false;
                    return;
                }
            }

            //rotation = Quaternion.Euler(0, 0, -180); // this adds a 90 degrees Y rotation


            //Stop
            //Rotate 180 back
            //stop
            //Rotate 180 back



            //var adjustRotation = transform.rotation.y + rotationAdjust; //<- this is wrong!
            
        }
        else if(b_Stage3)
        {
            
            rb = GetComponent<Rigidbody>();
            var speed = 10000000;

            for (int i = 0; i < 1; i++)
            {                
            // the starting conditions (the position and angle of the 'gun' object)
            Vector3 startPos = transform.position;
            Quaternion shotAngle = transform.rotation;
            // create the projectile object
            Transform bullet = (Transform)Instantiate(PlayerOneBEE, startPos, shotAngle);
            // apply the firing force

            rb.AddForce(transform.forward * speed, ForceMode.Impulse);
            }

            //Start Animation

            //Get Rotation angle

            //Get Velocity Amount. 

            //Create new Game object

            //Add Velocity and angle to new object. 

            //HAZAR

        }

    }
}
