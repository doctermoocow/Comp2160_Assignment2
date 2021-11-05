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
    private Collider carBody;
    private GameManager gameManager;
    

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        maxHealth = gameManager.playerHealth;
        currentHealth = maxHealth;

        damage = gameManager.damageValue;
        restore = gameManager.healthRestore;

        car = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("current health: " + currentHealth);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer != 7 && other.gameObject.layer != 8)
        {
            Debug.Log(other.gameObject.layer);
            currentHealth -= (damage * car.velocity.magnitude);
        }
        else if(other.gameObject.layer == 7)
        {
            healthRestore();
        }
    }

    public void healthRestore()
    {
        if((currentHealth + restore) < maxHealth)
        {
            currentHealth += restore;
        }
        else
        {
            currentHealth = maxHealth;
        }
    }
}
