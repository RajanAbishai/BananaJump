using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    [SerializeField]
    private GameObject oneBanana, bananas;

    [SerializeField]
    private Transform spawn_Point; // for the banana

    
    void Start()
    {
        GameObject newBanana = null;

        //60% chance
        if (Random.Range(0, 10) > 3)
        {
            newBanana = Instantiate(oneBanana, spawn_Point.position, Quaternion.identity);
        }

        else
        {
            newBanana = Instantiate(bananas, spawn_Point.position, Quaternion.identity);
        }

        newBanana.transform.parent = transform; //to avoid cluttering the hierarchy
        
    }

    
}
