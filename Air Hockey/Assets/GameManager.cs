using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static int PlayerScore1 = 0; // Pontuação do player 1
    public static int PlayerScore2 = 0; // Pontuação do player 2

    public GUISkin layout;              // Fonte do placar
    GameObject theBall;                 // Referência ao objeto bola
    void Start()
    {
        theBall = GameObject.FindGameObjectWithTag("Ball"); // Busca a referência da bola
    }

    // incrementa a potuação
    public static void Score (string wallID) {
    if (wallID == "AIGoal")
    {
        PlayerScore1++;
    } else if(wallID == "PlayerGoal")
    {
        PlayerScore2++;
    }
    }

    void OnGUI () {
    GUI.skin = layout;
    GUI.Label(new Rect(Screen.width / 2 - 150 - 12, 20, 100, 100), "" + PlayerScore1);
    GUI.Label(new Rect(Screen.width / 2 + 150 + 12, 20, 100, 100), "" + PlayerScore2);

    if (PlayerScore1 == 10)
    {
        GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "PLAYER ONE WINS");
        theBall.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
    } else if (PlayerScore2 == 10)
    {
        GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "PLAYER TWO WINS");
        theBall.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
    }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
