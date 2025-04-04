using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Sprite[] animationSprites1;
    public Sprite[] animationSprites2;
    public float animationTime;
    private SpriteRenderer _spriteRenderer;
    private int _animationFrame;
    public KeyCode dir = KeyCode.D;
    public KeyCode esq = KeyCode.A;
    public float speed = 10.0f;
    public float jumpForce = 7f;
    private bool isGrounded = true;
    private Rigidbody2D rb2d;
    public static string currentSceneName;


    private void Awake(){
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    //para começar a animar
    private void Start(){
        rb2d = GetComponent<Rigidbody2D>();     // Inicializa a raquete
        InvokeRepeating(nameof(AnimateSprite), this.animationTime, this.animationTime);
    }

    void Update()
    {
        // Jumping
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
            isGrounded = false;
        }
    }

    //para animar
    private void AnimateSprite(){
        var vel = rb2d.velocity; 
        if(Input.GetKey(dir)){
            _animationFrame++;
        if(_animationFrame >= this.animationSprites2.Length){
            _animationFrame = 0;
        }
        _spriteRenderer.sprite = this.animationSprites2[_animationFrame];
        vel.x = speed;
        } else if(Input.GetKey(esq)){
            _animationFrame++;
        if(_animationFrame >= this.animationSprites1.Length){
            _animationFrame = 0;
        }
        _spriteRenderer.sprite = this.animationSprites1[_animationFrame];
        vel.x =-speed;
        } else{
            vel.x = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)  
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
            isGrounded = false;
        }
        rb2d.velocity = vel;

    }
    //armamento
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.GetComponent<Collider>().CompareTag("Bau")){
            GameManager.ProximaCena();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if player is touching the ground
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        if(collision.collider.CompareTag("Bau")){
            GameManager.ProximaCena();
        }if(collision.collider.CompareTag("Finish")){
            SceneManager.LoadScene("Derrota");
        }
    }
}
