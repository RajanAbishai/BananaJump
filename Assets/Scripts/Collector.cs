using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D target)
    {

        
        if (target.tag == TagManager.BACKGROUND_TAG || target.tag==TagManager.PLATFORM_TAG||target.tag==TagManager.NORMAL_PUSH_TAG
            ||target.tag==TagManager.EXTRA_PUSH_TAG || target.tag==TagManager.BIRD_TAG)
        {
            target.gameObject.SetActive(false);
        }
        
    } // on trigger


} //class
