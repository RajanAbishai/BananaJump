using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D myBody;

    public float moveSpeed = 2f;
    public float normalPush = 10f;
    public float extraPush = 14f;

    private bool initial_Push;
    private int push_Count;
    private bool player_Died;

    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == TagManager.EXTRA_PUSH_TAG)
        {
            if (!initial_Push)
            {
                initial_Push = true;

                myBody.velocity = new Vector2(myBody.velocity.x, 18f);
                target.gameObject.SetActive(false);

                //sound manager
                return; //This return exits from OnTriggerEnter2D because of the initial push.  
            }

        }
        
    } 

}
