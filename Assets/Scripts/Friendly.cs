using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Friendly : MonoBehaviour
{
    private BoxCollider2D friendlyCollider;

    // Start is called before the first frame update
    void Start()
    {
        
        friendlyCollider = gameObject.AddComponent<BoxCollider2D>();
        friendlyCollider.size = new Vector2(1.0f, 1.0f);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
