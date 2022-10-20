using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float speed;
    public Rigidbody rB;
    public KeyCode forward;
    public KeyCode backward;
    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;
    public float jumpStrength;

    // Update is called once per frame
    void Update()
    {
        Vector3 currentVelocity = new Vector3(0, rB.velocity.y, 0);
        
        if(Input.GetKeyDown(jump))
        {
            rB.AddForce(transform.up * jumpStrength);
        }
        if(Input.GetKey(forward))
        {
            currentVelocity += (transform.forward * speed);
        }
        if(Input.GetKey(backward))
        {
            currentVelocity += (-transform.forward * speed);
        }
        if(Input.GetKey(left))
        {
            currentVelocity += (-transform.right * speed);
        }
        if(Input.GetKey(right))
        {
            currentVelocity += (transform.right * speed);
        }

        rB.velocity = currentVelocity;
        
    }
}
