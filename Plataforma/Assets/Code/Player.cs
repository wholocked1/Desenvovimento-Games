using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Sprite[] animationSprites;
    public float animationTime;
    private SpriteRenderer _spriteRenderer;
    private int _animationFrame;
    private void Awake(){
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    //para começar a animar
    private void Start(){
        InvokeRepeating(nameof(AnimateSprite), this.animationTime, this.animationTime);
    }
    //para animar
    private void AnimateSprite(){
        _animationFrame++;
        if(_animationFrame >= this.animationSprites.Length){
            _animationFrame = 0;
        }
        _spriteRenderer.sprite = this.animationSprites[_animationFrame];
    }
    //armamento
    private void OnTriggerEnter2D(Collider2D collision){
        
    }
}
