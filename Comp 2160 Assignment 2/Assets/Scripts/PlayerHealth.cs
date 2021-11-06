using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    private float maxHealth;
    private float currentHealth;
    private float damage;
    private float restore;
    private float smokeThreshold;

    private Rigidbody car;
    private Collider carBody;
    private GameManager gameManager;

    private string lastCollide;

    public GameObject CarExplosion;
    public GameObject CarSmoke;

    public GameObject healthBar;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        maxHealth = gameManager.playerHealth;
        currentHealth = maxHealth;
        smokeThreshold = gameManager.playerSmoke;

        damage = gameManager.damageValue;
        restore = gameManager.healthRestore;

        CarExplosion.SetActive(false);

        car = GetComponent<Rigidbody>();

        healthBar = FindObjectOfType<UIManager>().healthBar;

        lastCollide = "N/A";
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("current health: " + currentHealth);

        if(currentHealth < smokeThreshold)
        {
            CarSmoke.SetActive(true);
        }
        else
        {
            CarSmoke.SetActive(false);
        }

        if(currentHealth <= 0)
        {
            healthBar.transform.localScale = new Vector3(0, 0, 0);
            CarExplosion.SetActive(true);
            gameManager.Death(lastCollide);
        }
        else
        {
            healthBar.transform.localScale = new Vector3(currentHealth/maxHealth, 
                healthBar.transform.localScale.y, healthBar.transform.localScale.z);
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
