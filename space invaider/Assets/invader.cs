using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invader : MonoBehaviour
{
    public Sprite[] animationSrpites;
    public float animationTime;
    public System.Action killed;

    private SpriteRenderer _spriteRenderer;
    private int _animationFrame;
    public int score = 10;
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
        _spriteRenderer.sprite = this.animationSrpites[_animationFrame];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Laser")){
            this.killed.Invoke();
            this.gameObject.SetActive(false);
            GameManager.Score += this.score;
        }
    }

}
