using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tpBox : MonoBehaviour
{
    public GameObject box;
    public GameObject player;
    public KeyCode setBox;
    public KeyCode goToBox;
    public movement playerMovement;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(setBox) && playerMovement.isGrounded())
        {
            box.SetActive(true);
            box.transform.position = player.transform.position;
        }
        if(Input.GetKeyDown(goToBox))
        {
            player.transform.position = box.transform.position;
            box.SetActive(false);
        }
    }
}
