using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletTracerDeath : MonoBehaviour
{
    public float deathTime;
    public float alpha = 1;
    new LineRenderer renderer;
    void Start()
    {
        Destroy(gameObject, deathTime);
        renderer = gameObject.GetComponent<LineRenderer>();
        renderer.material.SetColor("_Color", new Color(1f, 1f, 0f, alpha));
    }
    void Update()
    {
        renderer.material.SetColor("_Color", new Color(1f, 1f, 0f, alpha));
        alpha -= Time.deltaTime/deathTime;
    }
}
