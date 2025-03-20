using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public static Parallax Instance { get; private set; }
    private float lenght;
    public float parallaxEffect;

    // Start is called before the first frame update
    void Start()
    {
        lenght = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {     
        if(GameManager.isOnSlowMotion){
            transform.position += Vector3.left * Time.deltaTime * parallaxEffect/2;
        } else{
            transform.position += Vector3.left * Time.deltaTime * parallaxEffect;
        }

        if(transform.position.x < -lenght ) {
            transform.position = new Vector3(lenght, transform.position.y, transform.position.z);
        }
    }
 }
