using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public Sprite[] animationSprites;
    public float animationTime;
    private int _animationFrame;
    private SpriteRenderer _spriteRenderer;
    // Start is called before the first frame update
    private void Awake(){
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), this.animationTime, this.animationTime);
    }


    private void AnimateSprite(){
        _animationFrame++;
        if(_animationFrame >= this.animationSprites.Length){
            _animationFrame = 0;
        }
        _spriteRenderer.sprite = this.animationSprites[_animationFrame];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.collider.CompareTag("Player")){
            Destroy(gameObject);
            GameManager.Score += 15;
        }
    }
}
