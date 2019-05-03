using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

    public const int maxHealth = 100;
    public int currentHealth = maxHealth;
    public RectTransform healthBar;
    public bool takingDamage;
    public GameObject DamageUI;
    public ParticleSystem explosion;
    public AudioSource deathAudio;

    void Start()
    {
        explosion = GetComponentInChildren<ParticleSystem>();
    }

    void Update()
    {
        if(!takingDamage)
        {
            DamageUI.SetActive(false);
        }
    }

    void FixedUpdate()
    {
    	takingDamage =false;
    }


    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        takingDamage = true;
        DamageUI.SetActive(true);
        healthBar.sizeDelta = new Vector2(currentHealth, healthBar.sizeDelta.y);
    }

    public void PlayerDead()
    {
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            DamageUI.SetActive(false);

            if(deathAudio.isPlaying == false)
            {
                explosion.Play();
            }
            if(deathAudio.isPlaying == false)
            {                
                deathAudio.Play();
            }

        }

    }

        
}