using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb2d;               // Define o corpo rigido 2D que representa a raquete
    public float boundYJ = 0.00f;            // Define os limites em Y do Jogador
    public float boundY = -4.5f;            // Define os limites em Y
    public float boundX = 3.5f;            // Define os limites em X
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();     // Inicializa a raquete
    }

    // Update is called once per frame
    void Update()
    {
        //no update
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var pos = transform.position;
        pos.x = mousePos.x;
        pos.y = mousePos.y;
        transform.position = pos;

        

    if (pos.x > boundX) {                  
        pos.x = boundX;                     // Corrige a posicao da raquete caso ele ultrapasse o limite superior
    }
    else if (pos.x < -boundX) {
        pos.x = -boundX;                    // Corrige a posicao da raquete caso ele ultrapasse o limite superior
    }
    
    if(pos.y < boundY){
        pos.y = boundY;
    }else if(pos.y > boundYJ){
        pos.y = boundYJ;
    }
    transform.position = pos;               // Atualiza a posição da raquete

    }
}
