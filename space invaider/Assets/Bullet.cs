using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private float lifeTime = 5f;
    private float speed = 200f;
    void DestroySelf()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);
    }

    void Awake()
    {
        Invoke("DestroySelf", lifeTime);
    }

    void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector2.up);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        DestroySelf();
    }
}
