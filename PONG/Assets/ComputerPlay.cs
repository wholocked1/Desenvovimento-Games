using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerPlay : MonoBehaviour
{
    public int direction = 1; //Define a direção para qual a bola está indo
    public float speed = 10.0f;             // Define a velocidade da bola
    public float boundY = 2.25f;            // Define os limites em Y
    private Rigidbody2D rb2d; 
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();     // Inicializa a raquete
    }

    // Update is called once per frame
    void Update()
    {
        var vel = rb2d.velocity;                // Acessa a velocidade da raquete
    if (direction == 1) {             // Velocidade da Raquete para ir para cima
        vel.y = 2;
    }
    else if (direction == 0) {      // Velocidade da Raquete para ir para cima
        vel.y = 2;                    
    }
    else {
        vel.y = 0;                          // Velociade para manter a raquete parada
    }
    rb2d.velocity = vel;                    // Atualizada a velocidade da raquete

    var pos = transform.position;           // Acessa a Posição da raquete
    if (pos.y > boundY) {                  
        pos.y = boundY; 
        direction = 1;                    // Corrige a posicao da raquete caso ele ultrapasse o limite superior
    }
    else if (pos.y < -boundY) {
        pos.y = -boundY; 
        direction = 0;                   // Corrige a posicao da raquete caso ele ultrapasse o limite superior
    }
    transform.position = pos;               // Atualiza a posição da raquete
    }
}
