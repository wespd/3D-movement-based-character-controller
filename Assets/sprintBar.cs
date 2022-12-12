using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sprintBar : MonoBehaviour
{
    public movement mScript;
    public RectTransform rTransform;
    public float currentScale;

    // Update is called once per frame
    void Update()
    {
        currentScale = mScript.currentSprint / mScript.maxSprint;
        rTransform.localScale = new Vector3(currentScale, rTransform.localScale.y, rTransform.localScale.z);
    }
}
