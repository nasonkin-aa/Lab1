using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenManager : MonoBehaviour
{
    public enum ObjectType
    {
        Spike,
        Teleport
    }

    public ObjectType type;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        var index = SceneManager.GetActiveScene().buildIndex;
        switch (type)
        {
            case ObjectType.Spike:
                SceneManager.LoadScene(index);
                break;
            case ObjectType.Teleport:
                SceneManager.LoadScene(index + 1);
                break;
            
        }
        
    }
}
