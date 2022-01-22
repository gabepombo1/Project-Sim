using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    
    //[SerializeField] public Sprite projectile;
    [SerializeField] public float damage;
    [SerializeField] public float speed;
    //private List<GameObject> bullets = new List<GameObject>();
    //private GameObject bulletHolder;

    /*
    Projectile()
    {
        Vector2 projectilePosition = projectile.transform.position;
        //Vector2 unitPosition = transform.position;
        Vector2 spawnPosition = new Vector2(unitPosition.x + 4, unitPosition.y);
        Vector2 vectorBetween = targetPosition - projectilePosition;

        //float mag = vectorBetween.normalized.magnitude;
        Quaternion unitRotation = unit.transform.rotation;

        Instantiate(projectile, spawnPosition, unitRotation);

        Vector2 normalizedVector = vectorBetween.normalized * projectile.speed * Time.deltaTime;


        projectilePosition = normalizedVector * projectile.speed * Time.deltaTime;
        
    }*/

    /*
    public void SetSprite(Sprite sprite)
    {
        
        projectile = sprite;

    }

    public Sprite GetSprite()
    {

        return projectile;

    }*/

    public void SetDamage(float setDamage)
    {

        damage = setDamage;

    }

    public float GetDamage()
    {

        return damage;

    }
    
    public void SetSpeed(float setSpeed)
    {

        speed = setSpeed;

    }

    public float GetSpeed()
    {

        return speed;

    }

}
