using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{

    private float maxHealth;
    private float currentHealth;
    private float damage;
    private float restore;
    

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = GetComponent<GameManager>().getHealth();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer != 7)
        {

        }
    }
}
