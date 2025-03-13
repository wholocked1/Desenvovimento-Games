using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nave : MonoBehaviour
{
    public Bullet laserPrefab;
    private Bullet laser;
    public float speed = 0.1f;
    private bool _laserActive;
    private void Update()
    {
        Vector3 position = transform.position;

        if(Input.GetKey(KeyCode.A)){
            this.transform.position += Vector3.left * this.speed;
        } else if (Input.GetKey(KeyCode.D)){
            this.transform.position += Vector3.right * this.speed;
        }

        if(Input.GetKeyDown(KeyCode.Space)){
            Shoot();
        }
    }
    private void Shoot(){
        if(!_laserActive){
        Bullet projectile = Instantiate(this.laserPrefab, this.transform.position, Quaternion.identity);
        projectile.destroyed += LaserDestroyed;
        _laserActive = true;
              
        } 
    }
    private void LaserDestroyed(){
        _laserActive = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Missile") ||
            other.gameObject.layer == LayerMask.NameToLayer("Invader")) {
            //GameManager.Instance.OnPlayerKilled(this);
        }
    }

}
