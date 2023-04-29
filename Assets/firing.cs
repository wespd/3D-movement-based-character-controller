using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firing : MonoBehaviour
{
    public gunManager manager;
    public Transform shooterObject;
    public float MaxDistance;
    public RaycastHit hit;
    public GameObject line;
    float currentCooldown;
    bool canShoot;

    // Update is called once per frame
    void Update()
    {
        if(!canShoot  && manager.equiuppedGun != null && currentCooldown < 1/manager.equiuppedGun.objGun.rateofFire)
        {
            currentCooldown += Time.deltaTime;
        }
        else if(!canShoot)
        {
            currentCooldown = 0;
            canShoot = true;
        }
        
        if (Input.GetMouseButton(0) && manager.equiuppedGun != null && canShoot)
        {
            shoot();
            canShoot = false;  
        }
    }
    public void shoot()
    {
        Transform muzzle = manager.equiuppedGun.muzzleLocation;
        bool isHit = Physics.Raycast(muzzle.position, shooterObject.forward,out hit, MaxDistance);
        GameObject newLine = Instantiate(line);
        LineRenderer lineRender = newLine.GetComponent<LineRenderer>();
        lineRender.SetPosition(0, muzzle.position);
        if(isHit)
        {
            lineRender.SetPosition(1, hit.point);
            health objHealth = hit.collider.GetComponent<health>();
            if(objHealth != null)
            {
                objHealth.takeDamage(manager.equiuppedGun.objGun.damage);
            }
        }
        else
        {
            lineRender.SetPosition(1,muzzle.position + shooterObject.forward * MaxDistance);
        }
        manager.equiuppedGun.UseAmmo();
        
    }
}
