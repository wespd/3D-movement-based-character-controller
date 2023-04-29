using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupGun : MonoBehaviour
{
    public KeyCode pickUpKey;
    public gun objGun;
    public pickupManager pickUpManager;
    public playerRaycastView playerView;
    public float pickupDistance;
    public Transform muzzleLocation;
    public int ammo;
   
   void Start()
   {
        ammo = objGun.clipSize;
   }
   void Update()
   {
        if(pickUpManager != null && playerView.ObjectInView == gameObject && Input.GetKeyDown(pickUpKey) && playerView.distance <= pickupDistance)
        {
            pickUpManager.pickUpGun(this);
        }
   }
   public void UseAmmo()
   {
        ammo -= 1;
        if(ammo <= 0)
        {
            Destroy(gameObject);
        }
   }

   
}
