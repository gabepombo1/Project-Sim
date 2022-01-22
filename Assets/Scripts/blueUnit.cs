using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BlueUnit : MonoBehaviour
{
    
    [SerializeField] GameObject unit;
    
    
    void Start()
    {
        
        UnitStats stats = gameObject.AddComponent<UnitStats>();
        stats.SetHealth(100);
        stats.SetMana(100);
        stats.SetAttack(10);
        stats.SetExperience(100);

        while (true)
        {

            if (stats.exp == stats.exp * 1.5)
            {

                stats.level++;

            }

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collidingObject)
    {
        
        string projectileTag = collidingObject.gameObject.tag; 
        
        if (collidingObject.gameObject.tag == "redProjectile")
        {
            
            UnitStats thisUnit = unit.GetComponent<UnitStats>();
            
            Projectile projectileObject = GameObject.Find(collidingObject.gameObject.name).GetComponent<Projectile>();
            
            float newHealth = thisUnit.GetHealth() - projectileObject.damage;
            thisUnit.SetHealth(newHealth);
            
        }

    }
    
}