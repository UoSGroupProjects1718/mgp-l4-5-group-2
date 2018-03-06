using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelController : MonoBehaviour {

    public GameObject GameCamera;
    public float CameraMovementSpeed;

    private int CurrentLevel;
    public int MaxLevel; //Max Level for this Scene

    public float LevelCameraIncrement;

    public float LevelHeight;

    public bool MoveToNextLevel;

    private BeeController beeController;


    // Use this for initializatio
    
	void Start () {

        beeController = GetComponent<BeeController>();
	}
	
   public void ChangeLevel()
    {      

        if (GameCamera.transform.position.y <= LevelCameraIncrement)
        {
            GameCamera.transform.Translate(0, (CameraMovementSpeed * Time.deltaTime), 0, Space.World);
            LevelCameraIncrement = LevelCameraIncrement * 2; //For the next level
        }


       // GameCamera.transform.Translate(0, (CameraMovementSpeed * Time.deltaTime), 0, Space.World);

    }





	// Update is called once per frame
	void Update () {

        //if (beeController.EndLevel == true)
        //    ChangeLevel();

        //    //if (MoveToNextLevel)
        //    //ChangeLevel();

        


        //if (Input.GetKeyDown(KeyCode.Mouse0))
        //{
           
        //}
		
	}
}
