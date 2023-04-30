using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
{
    public float maxHP;
    float currentHP;
    public bool isPlayer;
    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
    }
    public void takeDamage(float other)
    {
        currentHP -= other;
        if(currentHP <= 0 && !isPlayer)
        {
            gameObject.SetActive(false);
        }
        else if(currentHP <= 0)
        {
            Debug.Log("The Player has died");
        }
    }
}
