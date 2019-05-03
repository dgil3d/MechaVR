 using UnityEngine; 
 using System.Collections;
 
 public class Projectile : MonoBehaviour 
 {
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public AudioSource audio1;
    public AudioSource audio2;

     
    public void Fire()
    {
        // Create the Bullet from the Bullet Prefab
        var bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

        // Add velocity to the bullet
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 200;
        
        if(audio1.isPlaying == false)
        {
        	audio1.Play();
        }
        // Destroy the bullet after 2 seconds
        Destroy(bullet, 1.0f);        
    }   


 }