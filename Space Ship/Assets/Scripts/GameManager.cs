using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public static int Score = 0;
    public GUISkin layout;
    private GameObject gameOverUI;

    private float fSlowMotionTimer = 0f;
    public static bool isOnSlowMotion;
    public float fSlowMotionInterval = 3f;

    private void newGame(){
        Score = 0;
        fSlowMotionTimer = 0f;
        isOnSlowMotion = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Score == 50){
            isOnSlowMotion = true;
        }
        if(Score >= 100){
            SceneManager.LoadScene("Vitoria");
        }

        if(isOnSlowMotion){
            fSlowMotionTimer += Time.deltaTime;
            if (fSlowMotionTimer >= fSlowMotionInterval)
            {
                isOnSlowMotion = false;
                fSlowMotionTimer = 0f;
            }
        }
    }

    void OnGUI(){
        GUI.skin = layout;
        GUI.Label(new Rect(Screen.width / 2 - 150 - 12, 20, 100, 100), "Score: " + Score);
    }
}
