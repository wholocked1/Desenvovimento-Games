using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Derrota : MonoBehaviour
{
    void OnGUI(){
        Scene scene = SceneManager.GetActiveScene();
        if(GUI.Button(new Rect(Screen.width / 2 - 60, 350, 120, 53), "INICIO")){
            SceneManager.LoadScene("Inicio");
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
