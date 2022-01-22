using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
public class targetRadius : MonoBehaviour
{
    
    private int updates;
    private int colliderUpdates;

    //private GameObject searchObject;

    //[SerializeField] BoxCollider2D collider;
    //[SerializeField] private Sprite projectileSprite;
    
    [SerializeField] private GameObject radiusObject;

    [SerializeField] private GameObject unit;

    [SerializeField] public GameObject bullet; // = Assets.Load("blueBullet");
    //Start is called before the first frame update
    private int ammunition = 1;
    
    void Start()
    {
        
        redTargetList target = radiusObject.AddComponent<redTargetList>();
        
        //BoxCollider2D collider = gameObject.AddComponent<BoxCollider2D>();
        //GetComponent<Collider>().size = new Vector2(1.0f, 1.0f);
        //doesnt work
        //BoxCollider2D collider = gameObject.AddComponent<BoxCollider2D>();
        //Console.WriteLine(collider.transform.position);
        //BoxCollider2D collider = gameObject.AddComponent<BoxCollider2D>();
        
        radiusObject.transform.position = unit.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //OnTriggerEnter2D();
        
        if (ammunition == 0)
        {
            
            Debug.Log(unit + " Reloading...");

            ammunition = 10;
            Debug.Log(unit + " reloaded!");

        }

        updates++;
        if (updates == 1000)
        {
            
            //one is marked as expensive and the other is not marked as expensive
            Debug.Log("1000 updates (Debug.Log): '" + gameObject.name + "'");
            Console.WriteLine("1000 updates (Console.WriteLine): '" + gameObject.name + "'");
            updates = 0;

        }
        
        //if ()
        /*
        //moved giant fi block to upDate instead of OnTriggerEnter
        //Transform position = ;
        //what does this do?
        Vector2 colliderPosition = GetComponent<Collider>().transform.position;
        
        colliderPosition = radiusObject.transform.position;
        
        colliderUpdates++;
        while (colliderUpdates == 10)
        {
            
            //BoxCollider2D collider = gameObject.AddComponent<BoxCollider2D>();

                Console.WriteLine(GetComponent<Collider>().transform.position);
                colliderUpdates = 0;
                
        }
        
        //laggy
        
        radiusObject.transform.position = unit.transform.position;
        */

    }
    
    //I could make the radius object act like radar and go from .1 unit to 6 units in radius
    void OnTriggerEnter2D(Collider2D collision)
    {
        
        //updates++;
        //Debug.Log(updates + " updates Collision");

        
            //bullet = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            
            GameObject unitTarget = collision.gameObject;
            redTargetList target = radiusObject.AddComponent<redTargetList>();
            Console.WriteLine("hello");
            //code gets to here but it just creates a cunch of components in the inspector named redTargetList
            Interactions interactions = radiusObject.AddComponent<Interactions>();
            //hostile targeting
            //if true, then this is a hostile and you must shoot
            //Collider2D collidedObject = new Collider2D();
            bool targetBoolean = target.Target(collision.tag);

            if (ammunition > 0)
            {
                
                switch (targetBoolean)
                {

                    case true:

                        Vector2 opponentPosition = collision.transform.position;

                        Debug.Log("opponent found (Debug.Log) at position: " + opponentPosition + " !");
                        //collision.gameObject.SendMessage("opponent found (collision.gameObject.SendMessage)");

                        //shoot
                        interactions.SpawnProjectile(bullet, unitTarget, unit);
                        Debug.Log("Shot fired at " + unitTarget.gameObject.name + " !");

                        Destroy(target);
                        Destroy(interactions);

                        //Destroy(bullet);
                        ammunition--;

                        Debug.Log(unit + " Ammo left: " + ammunition);
                        break;

                    case false:

                        Vector2 allyPosition = collision.transform.position;

                        Debug.Log("ally found (Debug.Log) at position: " + allyPosition + " !");
                        //collision.gameObject.SendMessage("ally found (collision.gameObject.SendMessage)");

                        //either make one unit be the only one randomly searching for enemies and so the army follows him, or
                        //find a way to make sure the units arent all just following each other
                        //maybe make the movement towards an ally be motivated by a value called fear and have fear manipulate a random value (0 , 100)
                        //fear increases the farther away a unit is from the base
                        Debug.Log("Moving towards " + collision + " !");

                        Destroy(target);
                        Destroy(interactions);

                        break;

                }
            }
            else
            {
                
                Debug.Log("Reloading! Ammo count: " + ammunition);
                ammunition = 10;
                Debug.Log("Reloaded! Ammo count:" + ammunition);
                
            }
        
        Destroy(interactions);
        Destroy(target);
        //Destroy(bullet);
        //Destroy(target);
        //Destroy(interactions);

            /*if (targetBoolean)
            {
                //define
                Vector2 opponentPosition = collision.transform.position;
                //log
                
                if (true){
                    
                    Debug.Log("opponent found (Debug.Log)) at position: " + opponentPosition + " !");
                    collision.gameObject.SendMessage("opponent found (collision.gameObject.SendMessage)");
                }
                //shoot
                
                //find a way to delay shots in between/reload time
                //interactions.Shoot(projectile, 10, opponent);
                
            }
            
            //ally targeting
            if (targetBoolean == false)
            {
                
                //define
                GameObject ally = collision.gameObject;
                Vector2 allyPosition = collision.gameObject.transform.position;
                //log
                Debug.Log("ally found (Debug.Log) a position: " + allyPosition + " !");
                collision.gameObject.SendMessage("ally found (collision.gameObject.SendMessage)");
                //regroup towards
                //transform.position = new Vector2(transform.position.x + movespeed * Time.deltaTime, transform.position.y);
                //transform.position = new Vector2(transform.position.x - (allyPosition.x) + moveSpeed * Time.deltaTime, transform.position.y - (allyPosition.y));

            }*/

    }

    /*void OnTriggerStay2D(Collider2D other)
    {

        while(CompareTag("Red"))
        {
            
            updates++;
            
        }

        if (updates > 612.5)
        {

            ammunition = 1;

        }
        

    }
    */
}
