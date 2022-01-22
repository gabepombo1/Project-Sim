using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HostileSpawner : MonoBehaviour
{
    
    int updates = 0;
    //dont need to serialize this because the
    [SerializeField] private GameObject spawner; 
    [SerializeField] private GameObject spawnedUnit;
    
    //can make this randomly select from an array of hostile gameobjects
    private void SpawnHostile()
    {
        
        hostiles.Add(Instantiate(spawnedUnit, transform.position, transform.rotation));
        
    }
    
    //store enemies and their information
    private List<GameObject> hostiles = new List<GameObject>();
    //private UnitList spawnedUnits = spawner.AddComponent<UnitList>();
    
    // Start is called before the first frame update
    void Start()
    {
        
        UnitList spawnedUnits = spawner.AddComponent<UnitList>();
        
    }

    // Update is called once per frame
    void Update()
    {

        updates++;
        
        if (updates == 50 && spawner.GetComponent("UnitList").Equals(10)){

            SpawnHostile();
            updates = 0;

        }

    }
}
