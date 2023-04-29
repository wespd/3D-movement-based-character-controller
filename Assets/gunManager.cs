using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunManager : MonoBehaviour
{
    public pickupGun equiuppedGun;

    // Update is called once per frame
    void LateUpdate()
    {
        if(equiuppedGun != null)
        {
            equiuppedGun.gameObject.transform.position = gameObject.transform.position;
            equiuppedGun.gameObject.transform.rotation = gameObject.transform.rotation;
        }
    }
}
