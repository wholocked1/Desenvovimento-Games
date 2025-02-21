using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rb2d;               // Define o corpo rigido 2D que representa a bola
    // inicializa a bola randomicamente para esquerda ou direita
    void GoBall(){                      
        float rand = Random.Range(0, 2);
        if(rand < 1){
            rb2d.AddForce(new Vector2(20, -15));
        } else {
            rb2d.AddForce(new Vector2(-20, -15));
        }
    }
     public AudioSource source;
    




    void Start () {
        rb2d = GetComponent<Rigidbody2D>(); // Inicializa o objeto bola
        Invoke("GoBall", 2);    // Chama a função GoBall após 2 segundos`
        source = GetComponent<AudioSource>();
    }

    // Determina o comportamento da bola nas colisões com os Players (raquetes) alterar para funcionar com o air hockey
    void OnCollisionEnter2D (Collision2D coll) {
        if(coll.collider.CompareTag("Player")){
            Vector2 vel;
            vel.y = rb2d.velocity.y;
            vel.x = (rb2d.velocity.x / 2) - (coll.collider.attachedRigidbody.velocity.x / 3);
            rb2d.velocity = vel;
        }if(coll.collider.CompareTag("AI")){
            Vector2 vel;
            vel.y = rb2d.velocity.y;
            vel.x = (rb2d.velocity.x / 2) + (coll.collider.attachedRigidbody.velocity.x / 3);
            rb2d.velocity = vel;
        }if(coll.collider.CompareTag("Goal")){
            RestartGame();
        }
        source.Play();
    }

    // Reinicializa a posição e velocidade da bola
    void ResetBall(){
        rb2d.velocity = Vector2.zero;
        transform.position = Vector2.zero;
    }

    // Reinicializa o jogo
    void RestartGame(){
        ResetBall();
        Invoke("GoBall", 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
