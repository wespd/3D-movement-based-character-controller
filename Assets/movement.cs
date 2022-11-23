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
    public float jumpDetectionHeight;
    public float maxDistance;

    // Update is called once per frame
    void Update()
    {
        float acceleration = speed/Mathf.Max(rB.velocity.magnitude, 1); 
        //rB.velocity = new Vector3(0, rB.velocity.y, 0);
        if(isGrounded())
        {
                if(Input.GetKey(forward))
            {
                rB.AddForce(transform.forward * acceleration);
            }
            if(Input.GetKey(backward))
            {
                rB.AddForce(-transform.forward * acceleration);
            }
            if(Input.GetKey(left))
            {
                rB.AddForce(-transform.right * acceleration);
            }
            if(Input.GetKey(right))
            {
                rB.AddForce(transform.right * acceleration);
            }
                if(Input.GetKeyDown(jump))
            {
                rB.AddForce(transform.up * jumpStrength, ForceMode.Impulse);
            }
        }
    }
    public bool isGrounded()
    {
        RaycastHit hit;
        bool hitObject = Physics.SphereCast(transform.position, transform.localScale.x/2, -transform.up, out hit, transform.localScale.y + jumpDetectionHeight);
        if(hit.collider != null && hit.collider.GetComponent<cantJumpOn>() != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
