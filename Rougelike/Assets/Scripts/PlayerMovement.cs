using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Tutorial Video #3 Setting up character movement 

public class PlayerMovement : MonoBehaviour
{
    public float speed; // Controlls speed of movement
    private Vector2 direction;
    private Animator animator; // For controlling animations when moving

    void Start()
    {
        animator = GetComponent<Animator>(); // For controlling animations when moving
    }

    void Update()
    {
        TakeInput();
        Move();
    }

    private void Move()
    {
        transform.Translate(direction * speed * Time.deltaTime);
        SetAnimatorMovement(direction); // For controlling animations when moving
    }

    private void TakeInput() // For actual player movement
    {
        direction = Vector2.zero;

        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector2.up;
        }

        if(Input.GetKey(KeyCode.A))
        {
            direction += Vector2.left;
        }

        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector2.down;
        }

        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector2.right;
        }
    }

    private void SetAnimatorMovement(Vector2 direction) // For controlling animations when moving
    {
        animator.SetFloat("xDir", direction.x);
        animator.SetFloat("yDir", direction.y);
        print(animator.GetFloat("xDir"));
    }
}
