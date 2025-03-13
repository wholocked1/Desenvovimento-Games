using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invaders : MonoBehaviour
{
    public invader[] prefabs;
    public int Rows = 5;
    public int Columns = 11;
    public int amountKilled { get; private set; }
    public int totalInvaders => this.Rows * this.Columns;
    public int amountAlive => this.totalInvaders - this.amountKilled;
    public float percentKilled => (float)this.amountKilled / (float)this.totalInvaders;
    public AnimationCurve speed;
    public Bullet missilePrefab;
    public float missileAttackRate = 1.0f;
    private Vector3 _direction = Vector3.right;
    private Vector3 initialPosition;

    
    private void Awake(){
        initialPosition = transform.position;
        for(int row = 0; row < this.Rows; row++){
            float width = 2.0f *(this.Columns - 1);
            float height = 2.0f * (this.Rows - 1);
            Vector2 centering = new Vector2(-width / 2, -height / 2);
            Vector3 rowPosition = new Vector3(centering.x, centering.y + (row * 2.0f), 0.0f);

            for(int col = 0; col < this.Columns; col++){
               invader invad = Instantiate(this.prefabs[row], this.transform);
               invad.killed += InvaderKilled;
               Vector3 position = rowPosition;
               position.x += col * 2.0f;
               invad.transform.position = position;
            }
        }
    }
    private void Start()
    {
        InvokeRepeating(nameof(MissileAttack), this.missileAttackRate, this.missileAttackRate);   
    }
    private void Update(){
        this.transform.position += _direction * this.speed.Evaluate(this.percentKilled);
        Vector3 leftLedge = Camera.main.ViewportToWorldPoint(Vector3.zero);
        Vector3 rightLedge = Camera.main.ViewportToWorldPoint(Vector3.right);
        foreach(Transform invader in this.transform){
            if(!invader.gameObject.activeInHierarchy){
                continue;
            }
            if(_direction == Vector3.right && invader.position.x >= rightLedge.x - 1.0f){
                AdvenceRow();
            }else if(_direction == Vector3.left && invader.position.x <= leftLedge.x + 1.0f){
                AdvenceRow();
            }
        }
    }
    private void AdvenceRow(){
        _direction.x *= -1.0f;
        Vector3 position = this.transform.position;
        position.y -= 0.2f;
        this.transform.position = position;
    }

    private void MissileAttack(){
        foreach(Transform invader in this.transform){
            if(!invader.gameObject.activeInHierarchy){
                continue;
            }
            if(Random.value < (1.0f/(float)this.amountAlive)){
                Instantiate(this.missilePrefab, invader.position, Quaternion.identity);
                break;
            }
        }
    }

    private void InvaderKilled(){
        this.amountKilled++;
    }

    public int GetAliveCount(){
        return amountAlive;
    }

     public void ResetInvaders()
    {
        _direction = Vector3.right;
        transform.position = initialPosition;

        foreach (Transform invader in transform) {
            invader.gameObject.SetActive(true);
        }
    }
}
