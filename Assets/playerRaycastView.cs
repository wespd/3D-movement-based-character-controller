using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerRaycastView : MonoBehaviour
{
    public GameObject ObjectInView;
    public float distance;
    public Vector3 direction;
    Camera cam;
    public Vector3 hitLocation;
    public bool lookingAtSomething;
    // Update is called once per frame
    void Start()
    {
        cam = Camera.main;
    }
    void Update()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        int layer = 1 << LayerMask.NameToLayer("Default");
        if (Physics.Raycast(ray, out RaycastHit hit, 1000f, layer, QueryTriggerInteraction.Ignore))
        {
            ObjectInView = hit.transform.gameObject;
            distance = hit.distance;
            hitLocation = hit.point;
            lookingAtSomething = true;
        }
        else
        {
            lookingAtSomething = false;
            hitLocation = direction * 1000f;
        }
        direction = ray.direction;
    }
}
