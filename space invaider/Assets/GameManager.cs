using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public static int Score = 0;
    public GUISkin layout;
    GameObject bullet;
    private Text scoreText;
    private Text livesText;
    private GameObject gameOverUI;
    private Nave player;
    private Invaders invaders;
    private NaveMae mysteryShip;

    public int score { get; set; } = 0;
    public static int lives { get; set; } = 3;

    private void NewGame()
    {
        Score = 0 ;
        lives = 3;
        NewRound();
    }

    private void NewRound()
    {
        invaders.ResetInvaders();
        invaders.gameObject.SetActive(true);

        Respawn();
    }
     public void OnPlayerKilled(Nave player)
    {
        lives--;
    }

    public void OnInvaderKilled(invader invader)
    {
        invader.gameObject.SetActive(false);

        this.score = this.score + invader.score;

        if (invaders.GetAliveCount() == 0) {
            NewRound();
        }
    }

    private void GameOver()
    {
        gameOverUI.SetActive(true);
        invaders.gameObject.SetActive(false);
    }

    private void Respawn()
    {
        Vector3 position = player.transform.position;
        position.x = 0f;
        player.transform.position = position;
        player.gameObject.SetActive(true);
    }

    public void OnMysteryShipKilled(NaveMae mysteryShip)
    {
        this.score = this.score + mysteryShip.score;
    }

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Nave>();
        invaders = FindObjectOfType<Invaders>();
        mysteryShip = FindObjectOfType<NaveMae>();

        NewGame();
    }

    // Update is called once per frame
    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        if(lives == 0){
            SceneManager.LoadScene("Derrota");
        }
        if(invaders.GetAliveCount() == 0){
            SceneManager.LoadScene("Vitoria");
        }
    }
    void OnGUI(){
        GUI.skin = layout;
        GUI.Label(new Rect(Screen.width / 2 - 150 - 12, 20, 100, 100), "Score: " + Score);
        GUI.Label(new Rect(Screen.width / 2 - 150 - 12, 50, 100, 100), "Lives: " + lives);
    }
}
