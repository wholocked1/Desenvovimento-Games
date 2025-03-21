using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    void OnGUI(){
        Scene scene = SceneManager.GetActiveScene();

        if(GUI.Button(new Rect(Screen.width- 700, 100, 100, 53), "VOLTAR")){
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
