using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class Player : MonoBehaviour
{
    public GameObject Object;
    
    public Rigidbody2D RB2D;
    [SerializeField] private Collider2D _collider2D;

    public int PlayerSpeed = 3;
    
    public Vector2 Velocity;

    private bool _isGround;
    public LayerMask PlayerMask;
    public ContactFilter2D PlayerCF2D;

    public float _radius = 1f;
    
    void Start()
    {
        RB2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Debug.Log(Random.Range(0,1));

        Velocity.x = Input.GetAxis("Horizontal");
        //Velocity.y = Input.GetAxis("Vertical");
        
        if (Velocity.magnitude > 1)
            Velocity.Normalize();

        List<Collider2D> result = new List<Collider2D>();
        Physics2D.OverlapCollider(_collider2D, PlayerCF2D, result);
     
        if (Input.GetButtonDown("Jump") && result.Count != 0)
        {
            Instantiate(Object, transform.position, quaternion.identity);
            Debug.Log("1111");
            RB2D.velocity = new Vector2(RB2D.velocity.x, PlayerSpeed);
            Debug.Log(transform.right);
        }
    }
    
    public void FixedUpdate()
    {
        //RB2D.velocity = new Vector2(Velocity.x * PlayerSpeed, RB2D.velocity.y) ;
        transform.position += new Vector3(Velocity.x * PlayerSpeed * Time.deltaTime,0,0 );
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, (Vector2)transform.position + Vector2.down *0.6f);
        /*Gizmos.DrawWireSphere(new Vector2(transform.position.x, 
                transform.position.y - 0.4f) 
            , 0.2f );*/
    }
}
