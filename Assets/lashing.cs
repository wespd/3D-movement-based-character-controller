using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lashing : MonoBehaviour
{
    public playerRaycastView playerView;
    public Vector3 lashings;
    public float speed;
    public float maxEnergy;
    float currentEnergy;
    public KeyCode lashingKey;
    public KeyCode removeLashings;
    public int currentLashings;
    public Rigidbody rB;
    public movement playerMovement;
    

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(lashingKey) && currentEnergy > 0 && currentLashings < 1)
        {
            lashings += playerView.direction;
            rB.AddForce(lashings * speed);
            lashings = Vector3.zero;
        }
        else if(Input.GetKeyDown(lashingKey) && currentLashings == 1)
        {
            
            lashings += playerView.direction;
        }
        if(playerMovement.isGrounded())
        {
            currentEnergy = maxEnergy;
        }
        if(currentLashings != 0)
        {
            currentEnergy -= currentLashings * Time.deltaTime;
            
            if(currentEnergy <= 0)
            {
                lashings = Vector3.zero;
                currentLashings = 0;
                playerMovement.canMove = true;
            }
        }
        else
        {

        }

        if(Input.GetKeyDown(removeLashings))
        {
            lashings = Vector3.zero;
            currentLashings = 0;
            playerMovement.canMove = true;
        }


    }
    void OnCollisionEnter(Collision collision)
    {
        lashings = Vector3.zero;
        currentLashings = 0;
        playerMovement.canMove = true;
    }
}
