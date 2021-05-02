using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionPlayerController : MonoBehaviour
{
    public static CollisionPlayerController _shared;

    public string tagCollision { get; set; }


    private void Awake()
    {
        _shared = this;
    }

    private void OnCollisionEnter(Collision collision)
    {
        tagCollision = collision.gameObject.tag;

    }

    private void OnCollisionExit(Collision collision)
    {
        
    }

    private void OnCollisionStay(Collision collision)
    {
        
    }
}
