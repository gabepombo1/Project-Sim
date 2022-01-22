using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEditor;
using UnityEngine;
using UnityEngine.Animations;
using Quaternion = UnityEngine.Quaternion;
using Random = UnityEngine.Random;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;


public class RedUnit : MonoBehaviour
{
    private int update;
    [SerializeField] GameObject unit;

    public int FindEnemyUnit(float randomNumber)
    {
        
        //make it so the number given by randomNumber is mutliplied by a value of 0.1
        //(this makes the number much smaller, increasing the chance of returning '0' which returns true in the calling
        //function and finds an enemy) to 2 (numbers above 1 make it harder for the value to be in between 0 and 10 since
        //it increases the number that randomNumber ends up being) (perception attribute)
        if ( randomNumber >= 0 && randomNumber <= 10 )
        {

            return 0;

        }

        if (randomNumber > 10)
        {

            return 1;

        }
        
        return -1;
    }
    public bool WinOrBust(int inputInteger)
    {

        switch(inputInteger)
        {
            case -1:
                Console.WriteLine("FindEnemy has no input");
                return false;
            case 0:
                return true;
            case 1:
                return false;
            default:
                Console.WriteLine("Default reached in WinOrBust");
                return false;
        }
        
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
        UnitStats stats = gameObject.AddComponent<UnitStats>();
        stats.SetHealth(100);
        stats.SetMana(100);
        stats.SetAttack(10);
        stats.SetExperience(100);

            //put this in a detectexperience gain class or method and call it in update or start 
            /*if (stats.exp == stats.exp * 1.5)
            {

                stats.level++;

            }*/
        

    }

    // Update is called once per frame
    void Update()
    {

        update++;
        
        if (update == 2450)
        {
            
            int randomNumber = Random.Range(0 , 100);
            
            bool foundOrNot = WinOrBust(FindEnemyUnit(randomNumber));
            
            Debug.Log( foundOrNot + " is the result of FindEnemyUnit() for GameObject '" + unit + "', randomNumber is: " 
                       + randomNumber);
            
            //around 612.5 updates per second
            switch (foundOrNot)
            {
                
                case true:
                   
                    
                    GameObject enemy = GameObject.FindWithTag("Blue");
                    
                    Debug.Log( unit + " has found an enemy called " + enemy.name + 
                               " at position : " + enemy.transform.position);
                    
                    update = 0;
                    break;
                
                case false:
                    update = 0;
                    //move +5 to a random position away from the base
                    break;

            }

        }
        
    }

    void OnCollisionEnter2D(Collision2D collidingObject)
    {
        
        //this receives damage from a a bullet that enters the collider
        string projectileTag = collidingObject.gameObject.tag; 
        
        if (CompareTag("blueProjectile")) //collidingObject.gameObject.tag == "blueProjectile"))
        {
            
            UnitStats thisUnit = unit.GetComponent<UnitStats>();

            GameObject projectileObject = collidingObject.gameObject;//.GetComponent<Projectile>();//GameObject.Find(collidingObject.gameObject.name).GetComponent<Projectile>();
            Projectile projectileInstance = projectileObject.GetComponent<Projectile>();
            
            float newHealth = thisUnit.GetHealth() - projectileInstance.damage;
            thisUnit.SetHealth(newHealth);
            
            Destroy(collidingObject.gameObject);
            
        }

    }
    
}
