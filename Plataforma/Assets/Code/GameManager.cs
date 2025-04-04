using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set;}
    public static int Score = 0;
    public static int cena = 0;

    public GUISkin layout;
    private GameObject gameOverUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void ProximaCena(){
        if(cena == 0){
            SceneManager.LoadScene("Level 2");
            cena++;
        }else{
            SceneManager.LoadScene("Vitoria");
            cena = 0;
        }
    }

    void OnGUI(){
        GUI.skin = layout;
        GUI.Label(new Rect(Screen.width / 2 - 150 - 12, 20, 100, 100), "Score: " + Score);
    }

}
