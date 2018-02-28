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



    // Use this for initializatio
    
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


        if (GameCamera.transform.position.y <= LevelCameraIncrement)
        {
            //GameCamera.transform.Translate(0, (CameraMovementSpeed * Time.deltaTime), 0, Space.World);
           // LevelCameraIncrement = LevelCameraIncrement * 2; //For the next level

        }


        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
           
        }
		
	}
}
