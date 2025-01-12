using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PolarityController : MonoBehaviour
{
    public LayerMask GunMask;
    public float DistanceRay;
    public GameObject Player;

    private Polarity.PolarityType playerPolarityType = Polarity.PolarityType.north;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            playerPolarityType = (playerPolarityType == Polarity.PolarityType.north) 
                ? playerPolarityType = Polarity.PolarityType.south:
                playerPolarityType = Polarity.PolarityType.north;
            Debug.Log(playerPolarityType);
        }
        
        if (Input.GetKey(KeyCode.Mouse0))
        {
            List<Collider2D> result = new List<Collider2D>();
            RaycastHit2D hit2D = Physics2D.Raycast(transform.position,
                 transform.TransformDirection(Vector2.right), 
                DistanceRay, 
                GunMask);
            Debug.DrawRay(transform.position,
                transform.TransformDirection(Vector2.right) * 
                DistanceRay);

            if (hit2D.collider == null) return;
            
            Debug.Log(hit2D.collider.GetComponent<Polarity>().polarityType);
            if (hit2D.collider.GetComponent<Polarity>().polarityType == playerPolarityType)
            {
                Player.GetComponent<Rigidbody2D>().AddForce(GetDirection(hit2D) * 5);
                
            }else
            {
                Player.GetComponent<Rigidbody2D>().AddForce(-GetDirection(hit2D) * 5);
            }
            
        }

    }

    public Vector2 GetDirection(RaycastHit2D hit)
    {
        return hit.point - (Vector2)Player.transform.position;
    }
}
