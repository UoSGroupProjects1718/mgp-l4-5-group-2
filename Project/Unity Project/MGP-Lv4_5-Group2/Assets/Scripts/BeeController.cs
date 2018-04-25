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

    public Rigidbody2D Rigidbody;

    void Awake()
    {
        

    }

    // Use this for initialization
    void Start () {

        // prefabText = prefabText.GetComponent<Text>();
        UIControl = GameObject.Find("UiGameObjectController").GetComponent<uiController>();
        PlayerController = GameObject.Find("Character").GetComponent<playerController>();
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "LevelEnd")
        {
            Debug.Log("END OF LEVEL");
            Destroy(gameObject);
            EndLevel = true;
            PlayerController.PlayerPassed = true;            
            PlayerController.AddPoints(100, PlayerController.currentPlayer.ToString());
            PlayerController.PlayersTurnSwitch();
        }

        if (col.gameObject.tag == "Ground")
        {
            Debug.Log("Bee has hit the ground - Delete - Turn over"); 
            UIControl.PlayerAnimatedText.text = PlayerController.currentPlayer.ToString() + " Failed";
            Debug.Log(UIControl.PlayerAnimatedText.text);
            //StartCoroutine(PlayerController.TurnSwitchTimer(3.0f));
            Destroy(gameObject);            
            PlayerController.PlayersTurnSwitch();
        }



        if (col.gameObject.tag == "Cherry")
        {
            Debug.Log("explosions");
            Vector3 playercurrentPos;
            Vector3 AddExplosion;
            Vector3 HazardOriginalLocation = col.collider.transform.position;
            Vector3 aimedDirection;
            float thrust = 1000.0f;
            aimedDirection = (PlayerController.transform.position - transform.position).normalized;


            //Add animation
            

            Rigidbody.velocity = Vector3.zero;
            Rigidbody.AddForce(aimedDirection * thrust, ForceMode2D.Impulse);             
            Destroy(col.collider.gameObject);

            PlayerController.PlayersTurnSwitch();

        }

        //if (col.gameObject.tag == "Mushroom")
        //{
        //	Debug.Log("MUSHROOMED");


        //	//Whatever the mushroom does

        //	PlayerController.playerOneBEE.gravityScale++;

        //}

        //if (col.gameObject.tag == "Thorn")
        //{
        //	Debug.Log("THORNS");


        //	//Bee is violently impaled by thorns

        //	Destroy(gameObject);
        //}

        //if (col.gameObject.tag == "Web")
        //{
        //	//Drag++;

        //	Debug.Log("SLOWED");
        //	//Bee is slowed down
        //	Debug.Log(PlayerController.playerOneBEE.angularDrag);

        //	PlayerController.playerOneBEE.angularDrag++;
        //	PlayerController.playerOneBEE.drag++;



        //	//PlayerController.playerOneBEE.drag = Drag;

        //	Debug.Log(PlayerController.playerOneBEE.angularDrag);

        //} 



    }

    public void DestroyGameObject()
    {
        //Destroy(gameObject);
    }


    // Update is called once per frame
    void Update () {

        if (EndLevel == true)
        {
            

        }


    }
}
