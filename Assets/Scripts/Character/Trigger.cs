using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
   private void OnCollisionEnter2D(Collision2D other)
   {
      if (other.gameObject.GetComponent<CharacterController>())
      {
         Debug.Log(other.gameObject.name);
      }
   }

   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.gameObject.GetComponent<CharacterController>())
      {
         Debug.Log("Enter");
      }
      
   }

   private void OnTriggerExit2D(Collider2D other)
   {
      if (other.gameObject.GetComponent<CharacterController>())
         Debug.Log("Exit");
   }

   private void OnTriggerStay2D(Collider2D other)
   {
      if (other.gameObject.GetComponent<CharacterController>()) 
         Debug.Log("Stay");
   }
}
