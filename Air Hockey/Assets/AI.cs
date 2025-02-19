using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    private Rigidbody2D rb2d;               // Define o corpo rigido 2D que representa a raquete
    public float boundYJ = 0.00f;            // Define os limites em Y do Jogador
    public float boundY = 4.5f;            // Define os limites em Y
    public float boundX = 3.5f;            // Define os limites em X
    public float speed = 10.0f;             // Define a velocidade da bola
    GameObject theBall;                 // Referência ao objeto bola

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();     // Inicializa a raquete
        theBall = GameObject.FindGameObjectWithTag("Ball"); // Busca a referência da bola
    }

    // Update is called once per frame
    void Update()
    {
        //no update
        var pos = transform.position;
        var posBall = theBall.transform.position;
        pos.x = posBall.x;
    if (pos.x > boundX) {                  
        pos.x = boundX;                     // Corrige a posicao da raquete caso ele ultrapasse o limite superior
    }
    else if (pos.x < -boundX) {
        pos.x = -boundX;                    // Corrige a posicao da raquete caso ele ultrapasse o limite superior
    }
    
    if(pos.y > boundY){
        pos.y = boundY;
    }else if(pos.y < boundYJ){
        pos.y = boundYJ;
    }
    transform.position = pos;               // Atualiza a posição da raquete

    }
}
