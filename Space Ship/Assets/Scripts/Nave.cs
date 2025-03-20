using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Nave : MonoBehaviour
{
    public Bullet laserPrefab;
    public float speed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       Vector3 position = transform.position;

        if(Input.GetKey(KeyCode.W)){
            this.transform.position += Vector3.up * this.speed * Time.deltaTime;
        } else if (Input.GetKey(KeyCode.S)){
            this.transform.position += Vector3.down * this.speed * Time.deltaTime;
        }
        

        if(Input.GetKeyDown(KeyCode.Space)){
            Shoot();
        }
    }

    private void Shoot(){
        Bullet projectile = Instantiate(this.laserPrefab, this.transform.position, Quaternion.identity);
    }
}
