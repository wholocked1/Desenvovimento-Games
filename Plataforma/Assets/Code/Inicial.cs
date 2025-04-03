using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inicial : MonoBehaviour
{
    void OnGUI(){
        Scene scene = SceneManager.GetActiveScene();

        if (GUI.Button(new Rect(Screen.width /2 - 60, 350, 120, 53), "PLAY")){
            Player.currentSceneName = "Level 1";
            SceneManager.LoadScene("Level 1");
        }
        if(GUI.Button(new Rect(Screen.width /2 - 60, 450, 120, 53), "TUTORIAL")){
            SceneManager.LoadScene("Tutorial");
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
