using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "LevelEnd")
        {
            Debug.Log("END OF LEVEL");           
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
