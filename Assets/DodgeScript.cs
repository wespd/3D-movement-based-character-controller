using UnityEngine;

public class DodgeScript : MonoBehaviour
{
    public float dodgeSpeed = 5f;
    public float dodgeDuration = 0.5f;
    public float dodgeCooldown = 1f;

    private float dodgeTimer = 0f;
    private bool isDodging = false;
    public Rigidbody rB;
    public movement playerMovement;
    public KeyCode dodge;
    Vector3 dodgeVector;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(dodge) && dodgeTimer <= 0f && playerMovement.movementVector != Vector3.zero)
        {
            dodgeVector = playerMovement.movementVector;
            StartDodge();        
        }

        if (isDodging)
        {
            rB.velocity = dodgeVector * dodgeSpeed;

            dodgeTimer += Time.deltaTime;

            if (dodgeTimer >= dodgeDuration)
            {
                EndDodge();
            }
        }
        else if (dodgeTimer > 0f)
        {
            dodgeTimer -= Time.deltaTime;

            if (dodgeTimer < 0f)
            {
                dodgeTimer = 0f;
            }
        }
    }

    private void StartDodge()
    {
        isDodging = true;
        dodgeTimer = 0f;
    }

    private void EndDodge()
    {
        isDodging = false;
        dodgeTimer = dodgeCooldown;
    }
}