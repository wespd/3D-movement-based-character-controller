using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vault : MonoBehaviour
{
    public float detectionDistance;
    public Rigidbody rB;
    public float vaultStrength;
    public bool isVaulting;
    //use 2 raycasts to determine if you are high enough to vault an object
    //apply upwards and maybe forwards momentum if conditions met
    

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if(!Physics.Raycast(transform.position, transform.forward,detectionDistance) && Physics.Raycast(transform.position + Vector3.down * transform.localScale.y * 0.4f , transform.forward, out hit, detectionDistance))
        {
            
            cantJumpOn isGround = hit.collider.GetComponent<cantJumpOn>();
            if(isGround != null)
            {
                isVaulting = true;
            }
        }
        if(isVaulting)
        {
            Vault();
        }
    }
    void Vault()
    {
        rB.velocity = Vector3.zero;
        Debug.Log("trying to vault");
        if(Physics.Raycast(transform.position + Vector3.down * transform.localScale.y * 0.5f , transform.forward))
        {
            transform.Translate(Vector3.up * vaultStrength * Time.deltaTime);
        }
        if(!Physics.Raycast(transform.position, -transform.up, detectionDistance))
        {
            transform.Translate(Vector3.forward * vaultStrength * Time.deltaTime);
        }
        else
        {
            isVaulting = false;
        }
    }
}
