using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public int score { get; private set; } = 0;
    public int lives { get; private set; } = 3;

    private void SetScore(int score)
    {
        this.score = score;
        scoreText.text = score.ToString().PadLeft(4, '0');
    }

    private void SetLives(int lives)
    {
        this.lives = Mathf.Max(lives, 0);
        livesText.text = this.lives.ToString();
    }

    private void NewGame()
    {
        SetScore(0);
        SetLives(3);
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
        SetLives(lives - 1);

        player.gameObject.SetActive(false);

        if (lives > 0) {
            Invoke(nameof(NewRound), 1f);
        } else {
            GameOver();
        }
    }

    public void OnInvaderKilled(invader invader)
    {
        invader.gameObject.SetActive(false);

        SetScore(score + invader.score);

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
        SetScore(score + mysteryShip.score);
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
        OnGUI();
    }
    void OnGUI(){
        GUI.skin = layout;
        GUI.Label(new Rect(Screen.width / 2 - 150 - 12, 20, 100, 100), "Score: " + score);
        GUI.Label(new Rect(Screen.width / 2 - 150 - 12, 20, 100, 100), "Lives: " + lives);
    }
}
