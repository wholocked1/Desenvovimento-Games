using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nave : MonoBehaviour
{
    public KeyCode moveDir = KeyCode.D;      // Move a nave para direita
    public KeyCode moveEsq = KeyCode.A;    // Move a nave para esquerda
    public float speed = 20.0f;             // Define a velocidade da nave
    public float boundX = 10f;            // Define os limites em Y
    private Rigidbody2D rb2d;               // Define o corpo rigido 2D que representa a nave

    private Transform muzzle;

    private AudioClip shooting;
 
    private float coolDownTime = 0.5f;

    private Bullet bulletPrefab;

    private float shootTimer;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();     // Inicializa a nave
    }

    // Update is called once per frame
    void Update()
    {
    var vel = rb2d.velocity;                // Acessa a velocidade da raquete
    if (Input.GetKey(moveDir)) {             // Velocidade da Raquete para ir para cima
        vel.x = speed;
    }
    else if (Input.GetKey(moveEsq)) {      // Velocidade da Raquete para ir para cima
        vel.x = -speed;                    
    }
    else {
        vel.x = 0;                          // Velociade para manter a raquete parada
    }
    rb2d.velocity = vel;                    // Atualizada a velocidade da raquete

    var pos = transform.position;           // Acessa a Posição da raquete
    if (pos.x > boundX) {                  
        pos.x = boundX;                     // Corrige a posicao da raquete caso ele ultrapasse o limite superior
    }
    else if (pos.x < -boundX) {
        pos.x = -boundX;                    // Corrige a posicao da raquete caso ele ultrapasse o limite inferior
    }
    transform.position = pos;               // Atualiza a posição da raquete
    shootTimer += Time.deltaTime;
    if (shootTimer > coolDownTime && Input.GetKey(KeyCode.Space))
    {
        shootTimer = 0f;

        Instantiate(bulletPrefab, muzzle.position, Quaternion.identity);
        GameManager.Instance.PlaySfx(shooting);
    }

    }
    
}
