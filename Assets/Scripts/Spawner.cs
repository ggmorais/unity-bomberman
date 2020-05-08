using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject spawn;
    
    void Start()
    {
        if (spawn) {
            Instantiate(spawn, transform.position, Quaternion.identity);
        }
    }


    void Update()
    {
        
    }
}
