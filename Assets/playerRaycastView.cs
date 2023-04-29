using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerRaycastView : MonoBehaviour
{
    public GameObject ObjectInView;
    public float distance;
    public Vector3 direction;
    Camera cam;
    // Update is called once per frame
    void Start()
    {
        cam = Camera.main;
    }
    void Update()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            ObjectInView = hit.transform.gameObject;
            distance = hit.distance;
        }
        direction = ray.direction;
    }
}
