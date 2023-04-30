using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    Transform playerTransform;
    public float rotationSpeed;
    private Quaternion lookRotation;
    private Vector3 direction;
    private float turnPercent;
    public bool isDetecting;
    public Transform muzzleLocation;
    public firing firer;
    public float damage;

    // Update is called once per frame
    void FixedUpdate()
    {
        if(isDetecting)
        {
            //get vector to player
            direction = (playerTransform.position - transform.position).normalized;
            //desired rotation
            lookRotation =  Quaternion.LookRotation(direction);
            //we use this to know if we are able to fully turn this frame or not
            if(Quaternion.Angle(transform.rotation, lookRotation) > rotationSpeed)
            {
                //if not then we get the amount we are allowed to turn this frame
                turnPercent = rotationSpeed / Quaternion.Angle(transform.rotation, lookRotation);
            }
            else 
            {
                turnPercent = 1;
            }
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, turnPercent);
            Debug.DrawRay(muzzleLocation.position, transform.forward * 100f, Color.blue);
            if(Physics.Raycast(muzzleLocation.position, transform.forward, out RaycastHit hit) && hit.collider.GetComponent<movement>() != null)
            {
                firer.shoot(muzzleLocation, damage);
            }
        }
        

    }
    void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<movement>() != null)
        {
            isDetecting = true;
            playerTransform = other.transform;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.GetComponent<movement>() != null)
        {
            isDetecting = false;
            playerTransform = null;
        }
    }
}
