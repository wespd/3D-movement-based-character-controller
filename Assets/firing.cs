using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firing : MonoBehaviour
{
    public Transform shooterObject;
    public float MaxDistance;
    public RaycastHit hit;
    public GameObject line;
    bool isHit;
    

    
    public void shoot(Transform muzzle, float damage)
    {
        int layer = 1 << LayerMask.NameToLayer("Default");
        isHit = Physics.Raycast(muzzle.position, muzzle.forward,out hit, MaxDistance, layer, QueryTriggerInteraction.Ignore);
        GameObject newLine = Instantiate(line);
        LineRenderer lineRender = newLine.GetComponent<LineRenderer>();
        lineRender.SetPosition(0, muzzle.position);
        if(isHit)
        {
            lineRender.SetPosition(1, hit.point);
            health objHealth = hit.collider.GetComponent<health>();
            if(objHealth != null)
            {
                objHealth.takeDamage(damage);
            }
        }
        else
        {
            lineRender.SetPosition(1,muzzle.position + shooterObject.forward * MaxDistance);
        } 
    }
}
