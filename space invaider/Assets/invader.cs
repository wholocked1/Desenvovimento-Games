using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invader : MonoBehaviour
{
    public Sprite[] animationSrpites;
    public float animationTime;
    private SpriteRenderer _spriteRenderer;
    private int _animationFrame;

    private void Awake(){
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), this.animationTime, this.animationTime);
    }

    private void AnimateSprite(){
        _animationFrame++;
        if (_animationFrame >= this.animationSrpites.Length){
            _animationFrame = 0;
        }
        _spriteRenderer = this.animationSrpites[_animationFrame];
    }
    // private Rigidbody2D rb2d;
    // private float timer = 0.0f;
    // private float waitTime = 1.0f;
    // private float speed = 2.0f;

    // void ChangeState(){
    //     var vel = rb2d.velocity;
    //     vel.x *= -1;
    //     rb2d.velocity = vel;
    // }


    // // Start is called before the first frame update
    // void Start()
    // {
    //     rb2d = GetComponent<Rigidbody2D>();  

    //     var vel = rb2d.velocity;
    //     vel.x = speed;
    //     rb2d.velocity = vel;
    // }

    // // Update is called once per frame
    // void Update()
    // {       
    //     timer += Time.deltaTime;
    //     if (timer >= waitTime){
    //         ChangeState();
    //         timer = 0.0f;
    //     }
    // }
}
