using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private bool isAI;
    [SerializeField] private GameObject ball;

    private Rigidbody2D rb;
    private Vector2 playerMove;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if(isAI)
        {
            AIControl();
        }
        else
        {
            PlayerControl();
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = playerMove * movementSpeed;
    }
    private void PlayerControl()
    {
        playerMove = new Vector2(0,Input.GetAxis("Vertical"));
    }
    private void AIControl()
    {
        if(ball.transform.position.y > transform.position.y + 0.5f)
        {
            playerMove = new Vector2(0,1);
        }
        else if(ball.transform.position.y < transform.position.y - 0.5f)
        {
            playerMove = new Vector2 (0, -1);
        }
        else
        {
            playerMove = new Vector2 (0,0);
        }
    }
}//Class
