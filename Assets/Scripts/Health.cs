using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxhealth = 0;
    public int currentHealth = 0;
    public bool hasPickup = false;
    public GameObject abilityPickup;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeHealth(int damageValue)
    {
        currentHealth = currentHealth + damageValue;
        print("Health = " + currentHealth);
        if(currentHealth <= 0)
        {
            Die();
        }
    }


    public void Die()
    {
        if(hasPickup)
        {
            Instantiate(abilityPickup,transform.position,Quaternion.identity);
        }
        Destroy(gameObject);
    }



}
