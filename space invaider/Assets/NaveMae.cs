using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveMae : MonoBehaviour
{
    public float speed = 0.03f;
    public float cycleTime = 30f;
    public int score = 300;

    private Vector2 leftDestination;
    private Vector2 rightDestination;
    private int direction = -1;
    private bool spawned;
    // Start is called before the first frame update
    void Start()
    {
        // Transform the viewport to world coordinates so we can set the mystery
        // ship's destination points
        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);

        // Offset each destination by 1 unit so the ship is fully out of sight
        leftDestination = new Vector2(leftEdge.x - 1f, transform.position.y);
        rightDestination = new Vector2(rightEdge.x + 1f, transform.position.y);

        Despawn();
    }

    // Update is called once per frame
    void Update()
    {
        if (!spawned) return;

        if (direction == 1) {
            MoveRight();
        } else {
            MoveLeft();
        }
    }

    private void MoveRight()
    {
        transform.position += speed * Vector3.right;

        if (transform.position.x >= rightDestination.x) {
            Despawn();
        }
    }

    private void MoveLeft()
    {
        transform.position += speed * Vector3.left;

        if (transform.position.x <= leftDestination.x) {
            Despawn();
        }
    }

    private void Spawn()
    {
        direction *= -1;

        if (direction == 1) {
            transform.position = leftDestination;
        } else {
            transform.position = rightDestination;
        }

        spawned = true;
    }

    private void Despawn()
    {
        spawned = false;

        if (direction == 1) {
            transform.position = rightDestination;
        } else {
            transform.position = leftDestination;
        }

        Invoke(nameof(Spawn), cycleTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Laser"))
        {
            Despawn();
            GameManager.Score += this.score;
        }
    }

}
