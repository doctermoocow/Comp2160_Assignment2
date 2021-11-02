using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{

    private float maxHealth;
    private float currentHealth;
    private float damage;
    private float restore;

    private Rigidbody car;
    private GameManager gameManager;
    

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = gameManager.playerHealth;
    }

    // Update is called once per frame
    void Update()
    {
        //maxHealth = gameManager.getHealth();
        //currentHealth = maxHealth;
        //Debug.Log(currentHealth);
        /*
        if(car.velocity.magnitude > 6)
        {
            Debug.Log("woohoo!");
        }
        */
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer != 7)
        {

        }
    }
}
