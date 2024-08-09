using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegaMen : MonoBehaviour
{
    public Rigidbody2D rigi;
    public float moveSpeed;
    public float jumpForce;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigi.velocity = new Vector2(rigi.velocity.x, jumpForce);
        }
    }
}
