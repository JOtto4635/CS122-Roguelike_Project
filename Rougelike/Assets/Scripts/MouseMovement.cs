using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
public class MouseMovement : MonoBehaviour
{
    public float maxMoveSpeed = 10;
    public float smoothTime = 0.3f;
    Vector2 currentVelocity;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = Vector2.SmoothDamp(transform.position, mousePosition, ref currentVelocity, smoothTime, maxMoveSpeed);
    }

    private void SetAnimatorMovement(Vector2 mousePosition) // For controlling animations when moving
    {
        animator.SetFloat("xDir", mousePosition.x);
        animator.SetFloat("yDir", mousePosition.y);
        print(animator.GetFloat("xDir"));
        print(animator.GetFloat("yDir"));
    }
}
*/

public class MouseMovement : MonoBehaviour
{
    public float maxMoveSpeed = 10;
    public float smoothTime = 0.3f;
    Vector2 currentVelocity;
    Vector2 mousePosition;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        TakeInput();
        Move();
    }

    private void Move()
    {
        transform.position = Vector2.SmoothDamp(transform.position, mousePosition, ref currentVelocity, smoothTime, maxMoveSpeed);
       // SetAnimatorMovement(mousePosition);
    }

    private void TakeInput()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void SetAnimatorMovement(Vector2 mousePosition) // For controlling animations when moving
    {
       // animator.SetFloat("xDir", mousePosition.x);
       // animator.SetFloat("yDir", mousePosition.y);
        //print(animator.GetFloat("xDir"));
    }
}