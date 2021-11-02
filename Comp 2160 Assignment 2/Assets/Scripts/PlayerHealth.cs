using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
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
        gameManager = FindObjectOfType<GameManager>();
        maxHealth = gameManager.playerHealth;
        currentHealth = maxHealth;
        damage = gameManager.damageValue;
        restore = gameManager.healthRestore;
        car = gameManager.player;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer != 7)
        {
            currentHealth -= (damage * car.velocity.magnitude);
        }
    }
}
