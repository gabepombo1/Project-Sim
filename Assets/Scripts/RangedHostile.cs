using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//using a collider as a way for targeting may be less costly than calculating the distance between the shooter and the target every tick and checking if the shooter
//can shoo the target or not. This would be very true for large battles. You would also need some sort of hierarchy on how to decide what to shoot when inside the collider
//you can queue the targets as they enter, and dequeue once they leave the collider(calculate distance or use collider), you can do some analysis and make an algorithm
//that determines the target based on distance, health, and the target they are shooting (if they are shooting a weak target, then attack them) or maybe have a state
//machine that changes the unit's behavior based on what you set it to. the analysis makes more sense since this is going to be a simulation

public class RangedHostile : Hostile
{
    
    [SerializeField] private GameObject unitObject;
    [SerializeField] private GameObject projectile;
    [SerializeField] private float moveSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Interactions interactions = new Interactions();
        redTargetList target = new redTargetList();
        
        void OnCollisionEnter2D(Collision2D collision)
        {
            
            //hostile targeting
            //if true, then this is a hostile and you must shoot
            if (target.Target(collision.gameObject.tag))
            {
                //define
                GameObject opponent = collision.gameObject;
                Vector2 opponentPosition = collision.gameObject.transform.position;
                //log
                Debug.Log("opponent found (Debug.Log)) at position: " + opponentPosition + " !");
                collision.gameObject.SendMessage("opponent found (collision.gameObject.SendMessage)");
                //shoot
                
                //find a way to delay shots in between/reload time
                //interactions.Shoot(projectile, 10, opponent);
                
            }
            
            //ally targeting
            else if (target.Target(collision.gameObject.tag) == false)
            {
                //define
                GameObject ally = collision.gameObject;
                Vector2 allyPosition = ally.gameObject.transform.position;
                //log
                Debug.Log("ally found (Debug.Log) a position: " + allyPosition + " !");
                collision.gameObject.SendMessage("ally found (collision.gameObject.SendMessage)");
                //regroup towards
                //transform.position = new Vector2(transform.position.x + movespeed * Time.deltaTime, transform.position.y);
                transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);

            }
        }
    }
}
