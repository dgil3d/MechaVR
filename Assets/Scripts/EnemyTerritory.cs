using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTerritory : MonoBehaviour
{
        public BoxCollider territory;
        GameObject player;
        bool playerInTerritory;
 
        public GameObject enemy;
        public GameObject enemy2;
        BasicEnemy basicenemy;
        BasicEnemy basicenemy2;
 
        void Start ()
        {
            player = GameObject.FindGameObjectWithTag ("Player");
            basicenemy = enemy.GetComponent<BasicEnemy>();
            basicenemy2 = enemy2.GetComponent<BasicEnemy>();
            playerInTerritory = false;
        }
     
        void Update ()
        {
            if (playerInTerritory == true)
            {
                basicenemy.MoveToPlayer();
                basicenemy.AttackTimer();

                if(enemy2 != null)
                {
                    basicenemy2.MoveToPlayer();
                    basicenemy2.AttackTimer();
                }
            }
 
            if (playerInTerritory == false)
            {
                basicenemy.Rest ();

                if(enemy2 != null)
                {
                    basicenemy2.Rest();
                }
            }
        }
 
        void OnTriggerEnter (Collider other)
        {
            if(other.gameObject == player)
            {
                playerInTerritory = true;
            }
        }
     
        void OnTriggerExit (Collider other)
        {
            if(other.gameObject == player) 
            {
                playerInTerritory = false;
            }
        }
}