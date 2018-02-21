using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelController : MonoBehaviour {

    public GameObject GameCamera;
    public float CameraMovementSpeed;

    private int CurrentLevel;
    public int MaxLevel; //Max Level for this Scene

    public float LevelHeight;



    // Use this for initializatio
    
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameCamera.transform.Translate(0, CameraMovementSpeed, 0, Space.World);
        }
		
	}
}
