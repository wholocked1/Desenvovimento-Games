using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invaders : MonoBehaviour
{
    public invader[] prefabs;
    public int Rows = 5;
    public int Columns = 11;

    public float speed = 1.0f;
    private Vector3 _direction = Vector2.right;

    private void Awake(){
        for(int row = 0; row < this.Rows; row++){
            float width = 2.0f *(this.Columns - 1);
            float height = 2.0f * (this.Rows - 1);
            Vector2 centering = new Vector2(-width / 2, -height / 2);
            Vector3 rowPosition = new Vector3(centering.x, centering.y + (row * 2.0f), 0.0f);

            for(int col = 0; col < this.Columns; col++){
               invader invad = Instantiate(this.prefabs[row], this.transform);
               Vector3 position = rowPosition;
               position.x += col * 2.0f;
               invad.transform.position = position;
            }
        }
    }
    private void Update(){
        this.transform.position += _direction * this.speed;
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
        position.y -= 0.1f;
        this.transform.position = position;
    }
}
