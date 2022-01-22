using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEditor;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class Interactions : MonoBehaviour
{
    
    public void SpawnProjectile(GameObject bullet, GameObject target, GameObject unit)
    {
        
        UnitStats unitStats = unit.AddComponent<UnitStats>();
        
        float missIncrement = Random.Range(-1.7f, 1.7f) * unitStats.accuracy;
        
        Debug.Log("Reached Shoot() bulletObject: " + bullet + " unit: " + unit + " target: " + target + " !");
        
        Projectile projectile = bullet.AddComponent<Projectile>();
            projectile.SetDamage(10);
            projectile.SetSpeed(2.0f);

        Vector2 targetPosition = target.transform.position;
            targetPosition = new Vector2(targetPosition.x - missIncrement,
                targetPosition.y - missIncrement);
        
        Vector2 projectilePosition = bullet.transform.position;
        Vector2 unitPosition = unit.transform.position;
        Vector2 spawnPosition = new Vector2(unitPosition.x + 1, unitPosition.y);
        Vector2 vectorBetween = targetPosition - projectilePosition;

        float distanceBetween = Vector2.Distance(unitPosition, targetPosition);
        float timeOfBullet = distanceBetween / projectile.GetSpeed() + 0.1f;
        
        Quaternion unitRotation = unit.transform.rotation;


        float step = Time.deltaTime * projectile.GetSpeed();
        
        projectilePosition = unit.transform.forward * projectile.GetSpeed() * Time.deltaTime;
        
        Destroy(Instantiate(bullet, spawnPosition, unitRotation), timeOfBullet);

        Debug.Log(projectilePosition);
        
        Destroy(bullet);
        
    }

    public void Aim(GameObject target)
    {
        
        
        GameObject unit = gameObject;

        UnitStats unitStats = unit.AddComponent<UnitStats>();
        
        float missIncrement = Random.Range(-1.7f, 1.7f) * unitStats.accuracy;
        
        Vector2 targetPosition = target.transform.position;
        
        targetPosition = new Vector2(targetPosition.x + missIncrement,
            targetPosition.y + missIncrement);
        
        gameObject.transform.LookAt(targetPosition);
        
    }
    
    
    public void Shoot(GameObject bulletObject, GameObject target, GameObject unit)
    {
      
        SpawnProjectile(bulletObject,target, unit);
        
        Debug.Log("Reached Shoot() bulletObject: "+ bulletObject +" unit: " + unit +" target: "+ target + " !");

    }


}
