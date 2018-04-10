using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeeController : MonoBehaviour {

    public bool EndLevel;

    //public GameObject AnimatedText;
    // public Text prefabText;



    private uiController UIControl;
    private levelController LevelScript;
    private playerController PlayerController;

    void Awake()
    {
        

    }

    // Use this for initialization
    void Start () {

        // prefabText = prefabText.GetComponent<Text>();
        UIControl = GameObject.Find("UiGameObjectController").GetComponent<uiController>();
        PlayerController = GameObject.Find("Character").GetComponent<playerController>();

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "LevelEnd")
        {
            Debug.Log("END OF LEVEL");


           // prefabText.text = "You Got Through The Level!!";

            Destroy(gameObject);

            EndLevel = true;

        }
    }
    // Update is called once per frame
    void Update () {

        if (EndLevel == true)
        {
            PlayerController.PlayersTurnSwitch();
        }


    }
}
