using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;




public class buttonLoader : MonoBehaviour {

    public void LoadScene(string SceneName)
    {
        int y = SceneManager.GetActiveScene().buildIndex;

        SceneManager.UnloadSceneAsync(y);
        SceneManager.LoadScene(SceneName);
       
    }
    public void ExitGame(bool bool_Quit)
    {
        Application.Quit();
    }

}
