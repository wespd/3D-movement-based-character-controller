using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunManager : MonoBehaviour
{
    public pickupGun equiuppedGun;
    public firing firer;
    float currentCooldown;
    bool canShoot;
    public playerRaycastView playerView;
    // Update is called once per frame
     void Update()
    {
        if(!canShoot && equiuppedGun != null && currentCooldown < 1/equiuppedGun.objGun.rateofFire)
        {
            currentCooldown += Time.deltaTime;
        }
        else if(!canShoot)
        {
            currentCooldown = 0;
            canShoot = true;
        }
        
        if (Input.GetMouseButton(0) && equiuppedGun != null && canShoot)
        {
            firer.shoot(equiuppedGun.muzzleLocation, equiuppedGun.objGun.damage);
            canShoot = false;
            equiuppedGun.UseAmmo();  
        }
    }
    void LateUpdate()
    {
        if(equiuppedGun != null)
        {
            equiuppedGun.gameObject.transform.position = gameObject.transform.position;
            int layer = 1 << LayerMask.NameToLayer("Default");
            equiuppedGun.gameObject.transform.LookAt(playerView.hitLocation);
        }
    }
}
