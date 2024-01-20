using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    
    Vector3 lookDirection;
    bool facingRight = true;
    private Vector2 moveInput;
    private Rigidbody2D playerRigidbody2D;
    [SerializeField] private float moveSpeed = 5f;

    SpriteRenderer sprite;
    void Start()
    {
        playerRigidbody2D = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Run();
        fplayer();
    }
    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        Debug.Log(moveInput);
    }

    void OnFire()
    {

    }
    void Run()
    {
        playerRigidbody2D.velocity = moveInput * moveSpeed;
    }
   

    void flip()
    {
        facingRight = !facingRight;
        sprite.flipX = true;
    }
    void flip2(){
        facingRight = true;
        sprite.flipX = false;
    }

    private void fplayer()
    {
        lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (lookDirection.x > transform.position.x && !facingRight)
        {
            flip2();
        }
        else if (lookDirection.x < transform.position.x && facingRight)
        {
            flip();
        }
    }
}
