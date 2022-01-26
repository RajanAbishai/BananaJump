using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform target;
    private bool followPlayer;
    public float minimumYThreshold = -2.6f; // how far below can the player fall before the camera follows him



    void Awake()
    {
        target = GameObject.FindGameObjectWithTag(TagManager.PLAYER_TAG).transform;
    }

    
    void Update()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
        if (target.position.y < (transform.position.y) - minimumYThreshold)
        {
            followPlayer = false;
        }

        if (target.position.y > transform.position.y)
        {
            followPlayer = true;
        }

        if (followPlayer)
        {
            Vector3 temp = transform.position;
            temp.y = target.position.y;

            transform.position = temp;
        }
        
    }


}
