using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	void OnCollisionEnter(Collision collision)
    {
        var hit = collision.gameObject;
        var health = hit.GetComponent<PlayerHealth>();
        
        if(collision.gameObject.CompareTag("Enemy"))
        {
            if (health  != null)
            {
            health.TakeDamage(1);
            }    
        }

        else if (collision.gameObject.CompareTag("Player"))
        {
            if (health  != null)
            {
            health.TakeDamage(1);
            }    
        }
        Destroy(gameObject);
    }
}