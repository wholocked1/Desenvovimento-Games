using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Asteroid : MonoBehaviour
{
    public static Asteroid Instance { get; private set; }
    public Vector3 direction;
    public static float speed = 5f;
    public int score = 10;

    public static float moveSpeed = 1f;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.isOnSlowMotion){
            this.transform.position += this.direction * (speed/2) * Time.deltaTime;
        } else{
            this.transform.position += this.direction * speed * Time.deltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "ParedeE"){
            Destroy(gameObject);
        }
        if(collision.tag == "Laser"){
            Destroy(gameObject);
            GameManager.Score += score;
        }
    }
}
