using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public Rigidbody2D Rb2D;

    public int CharacterSpeed = 7;
    

    private Vector2 Velocity;
    
    void Start()
    {
        if (Rb2D == null)
        {
            Rb2D = GetComponent<Rigidbody2D>();
        }

        Rb2D ??= GetComponent<Rigidbody2D>();
        
    }

    void Update()
    {
        Velocity.x = Input.GetAxis("Horizontal");
        Velocity.y = Input.GetAxis("Vertical");
        
        //Debug.Log(Rb2D.velocity.magnitude);
        
        if (Velocity.magnitude > 1)
            Velocity.Normalize();

        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("adsadasdas");
        }
    }

    private void FixedUpdate()
    {
        Rb2D.velocity = Velocity * CharacterSpeed;
    }
}
