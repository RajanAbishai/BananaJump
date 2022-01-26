using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public static PlatformSpawner instance;

    [SerializeField] private GameObject leftPlatform, rightPlatform;

    //This will be used in the random range to spawn the left platform
    private float left_X_Min = -4.4f;
    private float left_X_Max = -2.8f;

    //This will be used in the random range to spawn the right platform
    private float right_X_Min = 4.4f; 
    private float right_X_Max =2.8f;


    private float Y_Threshold=2.6f; // this is going to be the difference in height between two platforms
    private float last_Y;

    public int spawn_Count = 8; //number of platforms that will be spawned everytime the spawn platform function is called
    private int platformSpawned; // this is to determine whether we should spawn a left platform or a right platform

    [SerializeField]
    private Transform platform_Parent; // This is to avoid clustering all the platforms inside the hierarchy.

    //variables to spawn bird enemy

    private void Start()
    {
        last_Y = transform.position.y; //current y position of the platform spawner
        SpawnPlatforms();
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        
    }

    
    void Update()
    {
        
    }


  public void SpawnPlatforms()
    {
        //Vector2 temp = transform.position;
        Vector2 temp = Vector2.zero;
        GameObject newplatform=null;

        for(int i = 0; i < spawn_Count; i++)
        {
            temp.y = last_Y; // last y position of the platform spawner being transferred to temp based on the number of platforms spawned

            if ((platformSpawned % 2) == 0) //even number? spawn a right platform
            {
                temp.x = Random.Range(left_X_Min, left_X_Max); // left has been used because it appears differently.. as in the maximum left or right it can go
                newplatform = Instantiate(rightPlatform, temp, Quaternion.identity);
            }

            else //if we have an odd number, spawn a left platform
            {
                temp.x = Random.Range(right_X_Min, right_X_Max); // right has been used because it appears differently
                newplatform = Instantiate(leftPlatform, temp, Quaternion.identity);

            }

            newplatform.transform.parent = platform_Parent;
            last_Y += Y_Threshold;
            platformSpawned++;

        }
    }


}
