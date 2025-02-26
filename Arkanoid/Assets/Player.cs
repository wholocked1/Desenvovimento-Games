using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public KeyCode moveDir = KeyCode.D;      // Move a raquete para direita
    public KeyCode moveEsq = KeyCode.A;    // Move a raquete para esquerda
    public float speed = 10.0f;             // Define a velocidade da raquete
public float boundY = 2.25f;            // Define os limites em Y
private Rigidbody2D rb2d;               // Define o corpo rigido 2D que representa a raquete


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
