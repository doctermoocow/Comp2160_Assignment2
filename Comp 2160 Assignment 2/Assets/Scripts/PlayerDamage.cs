using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{

    private float maxHealth;
    private float currentHealth;
    private float damage;
    private float restore;

    private GameManager gameManager;
    private Rigidbody car;
    

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GetComponent<GameManager>();
        currentHealth = maxHealth;
        Debug.Log(currentHealth);
    }

    // Update is called once per frame
    void Update()
    {
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
