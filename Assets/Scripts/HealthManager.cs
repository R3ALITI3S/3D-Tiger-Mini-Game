using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public GameObject Hero;

    public HealthBar healthBar; //refs the script to HealthBar
    

    // Start is called before the first frame update
    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth); // refs SetMaxHealth void from the script HealthBar, so it is full at the start of the game.
    }

    private void OnCollisionEnter (Collision collision)
    {
        //Makes the player hurt when hitting an enemy body
        if(collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(10); // defines the int damage up here... from the TakeDamage void..
        }
        

        //Makes the player gain Health when hitting an Collectible
         if(collision.gameObject.CompareTag("Collectible"))
        {
            // increases the health
            GainHealth(20); // defines the int amount up here... from the GainHealth void..

            healthBar.SetCurrentHealth(currentHealth); // remember to update the UI hehe

            // destroys the gameobject
            Destroy(collision.gameObject);
        }

        void GainHealth(int amount)
        {
            currentHealth += amount;
            
            // Ensure the character's life doesn't exceed the maximum.
            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }
        }
    }

    // Update is called once per frame
    public void TakeDamage(int damage) 
    {
        currentHealth -= damage;

        if(currentHealth<=0)
        {
            Die();
        }
        healthBar.SetCurrentHealth(currentHealth); // remember to update the UI hehe
    }

    void Die()
    {
        GetComponent<SpriteRenderer>().enabled = false; // hides the player
        GetComponent<Rigidbody>().isKinematic = true; // controls whether physics affects the rigidbody.
        GetComponent<CharacterMovement>().enabled = false;
        Invoke(nameof(ReloadLevel),1.3f); // nameof operator is used to get name of a variable, class or method.
        Debug.Log("You Died");
    }

    void ReloadLevel() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void Update()
    {
        if (transform.position.y < -1f)
        {
            Die();
        }
    }
}
