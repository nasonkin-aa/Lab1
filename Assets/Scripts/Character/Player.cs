using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D RB2D;
    [SerializeField] private Collider2D _collider2D;

    public int PlayerSpeed = 3;
    
    
    public Vector2 Velocity;
    
    void Start()
    {
        PlayerSpeed = 5;
        RB2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Velocity.x = Input.GetAxis("Horizontal");
         Velocity.y = Input.GetAxis("Vertical");
        if (Velocity.magnitude > 1)
            Velocity.Normalize();

        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("1111");
            RB2D.velocity = new Vector2(RB2D.velocity.x, PlayerSpeed);
        }
    }
    public void FixedUpdate()
    {
        RB2D.velocity = new Vector2(Velocity.x * PlayerSpeed, RB2D.velocity.y) ;
    }
    
}
