using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "new gun", menuName = "gun")]
public class gun : ScriptableObject
{
    //rounds per second
    public float rateofFire;
    public float damage;
    public int clipSize;
    //higher reload duration, the longer the reload takes
}
