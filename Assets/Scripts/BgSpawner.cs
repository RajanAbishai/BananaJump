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
        //.bounds.size.y will give the size of the background
        height = bgs[0].GetComponent<BoxCollider2D>().bounds.size.y; //using the element at index 0 to determine height. 

        highest_Y_Pos = bgs[0].transform.position.y;

        //since there is no guarantee in which order the game objects are retrieved, we must do the following
        for (int i = 1; i < bgs.Length; i++)
        {
            if (bgs[i].transform.position.y > highest_Y_Pos)
            {
                highest_Y_Pos = bgs[i].transform.position.y;
            }
        }

    }


    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == TagManager.BACKGROUND_TAG)
        {
            //We collided with the highest Y BG
            if (target.transform.position.y >= highest_Y_Pos)
            {
                Vector3 temp = target.transform.position;

                for(int i = 0; i < bgs.Length; i++)
                {
                    if (!bgs[i].activeInHierarchy)
                    {
                        temp.y += height; //adds the height of the background (30 units) to the y position so that it goes up
                        bgs[i].transform.position = temp;
                        bgs[i].gameObject.SetActive(true);

                        highest_Y_Pos = temp.y;
                    }

                    //print("Height is " + height);
                }

            }
        }
    }


  
}
