using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Gerência da pontuação e fluxo do jogo
    void OnGUI () {
    //GUI.skin = layout;
    // GUI.Label(new Rect(Screen.width / 2 - 150 - 12, 20, 100, 100), "" + PlayerScore1);
    // GUI.Label(new Rect(Screen.width / 2 + 150 + 12, 20, 100, 100), "" + PlayerScore2);

    if (GUI.Button(new Rect(Screen.width / 2 - 60, 350, 120, 53), "PLAY"))
    {
        // PlayerScore1 = 0;
        // PlayerScore2 = 0;
        // theBall.SendMessage("RestartGame", null, SendMessageOptions.RequireReceiver);
    }
    // if (PlayerScore1 == 10)
    // {
    //     GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "PLAYER ONE WINS");
    //     theBall.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
    // } else if (PlayerScore2 == 10)
    // {
    //     GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "PLAYER TWO WINS");
    //     theBall.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
    // }
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
