using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupManager : MonoBehaviour
{
    public gunManager theShooter;
    Rigidbody rB;
    //drop current gun, set gravity to false on new gun.
    public void pickUpGun(pickupGun other)
    {
        if(theShooter.equiuppedGun != null)
        {
            rB = theShooter.equiuppedGun.GetComponent<Rigidbody>();
            rB.useGravity = true;
             //theShooter.equiuppedGun.canBePickedUp = true;
        }
        
        theShooter.equiuppedGun = other;
        rB = theShooter.equiuppedGun.GetComponent<Rigidbody>();
        rB.useGravity = false;
    }
}
