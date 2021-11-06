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

    private string lastCollide;
    

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        maxHealth = gameManager.playerHealth;
        currentHealth = maxHealth;

        damage = gameManager.damageValue;
        restore = gameManager.healthRestore;

        car = gameObject.GetComponent<Rigidbody>();

        lastCollide = "N/A";
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("current health: " + currentHealth);

        if(currentHealth <= 0)
        {
            gameManager.Death(lastCollide);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer != 7 && other.gameObject.layer != 8)
        {
            Debug.Log(other.gameObject.layer);
            currentHealth -= (damage * car.velocity.magnitude);
            lastCollide = other.gameObject.name;
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

    public float getHealth()
    {
        return currentHealth;
    }
}
