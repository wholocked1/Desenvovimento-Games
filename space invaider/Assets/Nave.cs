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
    private float coolDownTime = 0.5f;
    private Bullet bullet;
    private float shootTimer;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();     // Inicializa a nave
    }

    // Update is called once per frame
    void Update()
    {
    if (Input.GetKey(KeyCode.D)) 
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }
    else if (Input.GetKey(KeyCode.A)) 
    {
        transform.Translate(-speed * Time.deltaTime, 0, 0);
    }
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

        Instantiate(bullet, muzzle.position, Quaternion.identity);
        //GameManager.Instance.PlaySfx(shooting);
    }

     }
    
}
