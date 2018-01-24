using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
 {
        public GameObject enemy;
        public GameObject bulletPrefab;
        public Transform bulletSpawn;
        public int health;
        
        public AudioSource walkAudio;
        public AudioSource audio1;
        public AudioSource audio2;
        public AudioSource deathAudio;

        public Transform target;
        
        private float attackRange = 15f;
        private float nextAttack = 0;
        private float speed = 3f;
        public float timer;
        
        public Animation anim;
        public ParticleSystem explosion;

        public bool isDead;
        public bool isMoving;
        public bool isAttacking;
        private bool hasPlayed = false;
 
        void Start ()
        {
            anim = enemy.GetComponent<Animation>();
            explosion = enemy.GetComponentInChildren<ParticleSystem>();
            timer = 5f;
            Rest ();
        }
 
        void Update()
        {

            if(isMoving)
            {
                anim.Play();
	            walkAudio.Play();
            }
            else 
            {
                anim.Stop();             
                walkAudio.Stop();
            }
        }
        
        public void FixedUpdate()
        {
            //Enemy Health
            health = enemy.GetComponent<PlayerHealth>().currentHealth;

            if(health <= 0)
            {
                Death();
            }

            //Enemy Range
            if (Vector3.Distance (transform.position, target.position) <= attackRange) 
            {
                if(!isAttacking)
                {
                    AttackTimer();
                }
            }

            //Attack Timer Reset
            if(timer <= -2 && isAttacking == true)
            {
                isAttacking = false;
                timer = 5f;
                audio2.Stop();
                audio1.Play();
            }
        }
        
        public void MoveToPlayer ()
        {
            //rotate to look at player
            transform.LookAt (target.position);
            transform.Rotate (new Vector3 (0, 0, 0), Space.Self);


            //move towards player
            if (Vector3.Distance (transform.position, target.position) > attackRange) 
            {
                    transform.Translate (new Vector3 (speed * Time.deltaTime, 0, 0));
                    isMoving = true;
            }
        }
 
        public void Rest ()
        {
            isMoving = false;
            isAttacking = false;
            anim.Stop();
        }

        
        public void AttackTimer()
        {
            timer -= Time.deltaTime;

            if (timer <= nextAttack) 
            {
                Attack();      
            }

        }

        public void Attack()
        {
            isAttacking = true;
            
            if(isAttacking && !isDead)
            {
                var enemyBullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
                        
                // Add velocity to the bullet
                enemyBullet.GetComponent<Rigidbody>().velocity = enemyBullet.transform.forward * 200;
                        
                if(audio2.isPlaying == false)
                {
                    audio2.Play();
                }                        
                // Destroy the bullet after 1 seconds
                Destroy(enemyBullet, 1.0f);             
            }
    
        }


        public void Death()
        {
        	isDead = true;

            isMoving = false;
            isAttacking = false;
            anim.Stop();
            walkAudio.Stop();
            audio1.Stop();
            audio2.Stop();
            
            if(deathAudio.isPlaying == false)
            {
                explosion.Play();
            }
            if(deathAudio.isPlaying == false)
            {                
                deathAudio.Play();
            }                        
            Destroy(gameObject, deathAudio.clip.length);                
        }

        

}