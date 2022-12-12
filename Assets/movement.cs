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
    public KeyCode sprint;
    float lastFrameSpeed;
    public float jumpStrength;
    public float jumpDetectionHeight;
    [Range(0,1)]
    public float frictionAmount;
    [Range(1,10)]
    public float notMovingFrictionMultiplier;
    public float sprintMultiplier;
    public float maxSprint;
    public float currentSprint;
    public float sprintRechargeTime;
    float currentRechargeTime;
    bool isRecharging = true;
    // Update is called once per frame
    void Update()
    {
        lastFrameSpeed = speed;
        Vector3 movement = Vector3.zero;
        if(currentRechargeTime >= sprintRechargeTime)
        {
            isRecharging = true;
        }
        if(isRecharging == false)
        {
            if(currentRechargeTime <= sprintRechargeTime)
            {
                currentRechargeTime += 2*Time.deltaTime;
            }
           
        }
        else
        {
            if(currentSprint < maxSprint)
            {
                currentSprint += Time.deltaTime;
            }
            else
            {
                currentSprint = maxSprint;
            }
            
        }
        if(Input.GetKey(sprint) && currentSprint > 0 && isGrounded())
        {
            isRecharging = false;
            speed *= sprintMultiplier;
            currentSprint -= Time.deltaTime;
            currentRechargeTime = 0;
        }

        float acceleration = speed/Mathf.Max(rB.velocity.magnitude, 1); 
        //rB.velocity = new Vector3(0, rB.velocity.y, 0);
        if(isGrounded())
        {

                if(Input.GetKeyDown(jump))
            {
                rB.AddForce(transform.up * jumpStrength, ForceMode.Impulse);
            }
        }
        
        if(Input.GetKey(forward))
        {
            movement += transform.forward;
        }
        if(Input.GetKey(backward))
        {
            movement -= transform.forward;
        }
        if(Input.GetKey(left))
        {
            movement -= transform.right;
        }
        if(Input.GetKey(right))
        {
            movement += transform.right;
        }
        if(movement == Vector3.zero)
        {
            frictionAmount *= notMovingFrictionMultiplier;
        }
        rB.AddForce(movement * acceleration, ForceMode.VelocityChange);
        rB.AddForce(new Vector3(-rB.velocity.x, 0, -rB.velocity.z) * frictionAmount);
        if(movement == Vector3.zero)
        {
            frictionAmount /= notMovingFrictionMultiplier;
        }
        /*if(rB.velocity.x <= 0.01)
        {
            rB.velocity = new Vector3(0,rB.velocity.y,rB.velocity.z);
        }
        if(rB.velocity.z <= 0.01 && )
        {
            rB.velocity = new Vector3(rB.velocity.x,rB.velocity.y,0);
        }*/
        speed = lastFrameSpeed;
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
