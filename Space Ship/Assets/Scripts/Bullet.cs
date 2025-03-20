using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 direction;
    public float speed;
    public System.Action destroyed;
    private Rigidbody2D rb;
    private void Update(){
        this.transform.position += this.direction * this.speed * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid") || collision.gameObject.CompareTag("ParedeD"))
        {
            Destroy(gameObject);
        }
    }
}
