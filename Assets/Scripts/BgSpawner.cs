using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgSpawner : MonoBehaviour
{
    private GameObject[] bgs;
    private float height;
    private float highest_Y_Pos;

    private void Awake()
    {
        bgs = GameObject.FindGameObjectsWithTag(TagManager.BACKGROUND_TAG); //gets all the objects tagged with this and puts them in the array
    }

    void Start()
    {
        height = bgs[0].GetComponent<BoxCollider2D>().size.y; //using the element at index 0 to determine height

        highest_Y_Pos = bgs[0].transform.position.y;
    }


    void Update()
    {
        
    }
}
