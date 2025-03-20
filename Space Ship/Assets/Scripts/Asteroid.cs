using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Asteroid : MonoBehaviour
{
    public Vector3 direction;
    public float speed;
    public int score = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += this.direction * this.speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Laser"))
        {
            Destroy(gameObject);
            GameManager.Score += score;
        }
        if (collision.gameObject.CompareTag("Parede"))
        {
            Destroy(gameObject);
        }
    }
}
