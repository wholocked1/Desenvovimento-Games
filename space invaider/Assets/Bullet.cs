using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 direction;
    public float speed;
    public System.Action destroyed;
    
    private void Update(){
        this.transform.position += this.direction * this.speed;
    }

    private void OnTriggerEnter2d(Collider2D other){
        this.destroyed.Invoke();
        Destroy(gameObject);
    }
}
