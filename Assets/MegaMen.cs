using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegaMen : MonoBehaviour
{
    public Rigidbody2D rigi;
    public float moveSpeed;
    public float jumpForce;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigi.velocity = new Vector2(rigi.velocity.x, jumpForce);
        }
    }
}
