using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hostile : MonoBehaviour
{
    [SerializeField] private GameObject unitObject;
    [SerializeField] private GameObject projectile;
    [SerializeField] private float moveSpeed;

    /*Stats unitStats = new Stats();
    unitStats.SetLevel(1);
    unitStats.SetHealth(100);
    unitStats.SetMana(100);
    unitStats.SetExperience(0);
    int unitLevel = unitStats.level;
    int hitPoints = unitStats.SetHealth(100);
    int manaPoints = unitStats.SetMana(100);
    int expPoints = unitStats.SetExperience(0);
    attackPoints = ;
    defensePoints = ;
    
    //morale will be like if -1, run towards nearest friendly hostile, if +1, charge at the ally/gain determination/damage buff, 0 means run towards ally
    moralePoints = 0;
*/
    GameObject targetRadius;

    void Start()
    {

        //transform.position = hostileSpawner.transform.position;


    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
        
        //transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
        
        //Interactions interactions = new Interactions();
        redTargetList target = gameObject.AddComponent<redTargetList>();
        
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
            else if (CompareTag("Friendly"))
            {
                
                //define
                GameObject ally = collision.gameObject;
                Vector2 allyPosition = collision.gameObject.transform.position;
                //log
                Debug.Log("ally found (Debug.Log) a position: " + allyPosition + " !");
                collision.gameObject.SendMessage("ally found (collision.gameObject.SendMessage)");
                //regroup towards
                //transform.position = new Vector2(transform.position.x + movespeed * Time.deltaTime, transform.position.y);
                transform.position = new Vector2(transform.position.x - (allyPosition.x) + moveSpeed * Time.deltaTime, transform.position.y - (allyPosition.y));

            }
            Debug.Log("poo");
        }
    }
}
