 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D myBody;

    public float moveSpeed = 3f;
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
    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        if (player_Died) { return; } //return in a void function basically exits the function without executing the rest of the code

      /*print("Horizontal: " + Input.GetAxisRaw("Horizontal"));
        print("Vertical: " + Input.GetAxisRaw("Vertical"));*/

        if (Input.GetAxisRaw("Horizontal") > 0) //left arrow returns negative value
        {
            myBody.velocity = new Vector2(moveSpeed,myBody.velocity.y);

        }

        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            myBody.velocity = new Vector2(-moveSpeed, myBody.velocity.y);    
        }


    } //player movement

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (player_Died) { return; } //return in a void function basically exits the function without executing the rest of the code

        if (target.tag == TagManager.EXTRA_PUSH_TAG)
        {
            if (!initial_Push)
            {
                initial_Push = true;

                myBody.velocity = new Vector2(myBody.velocity.x, 18f);
                target.gameObject.SetActive(false);

                //sound manager
                return; //This return exits from OnTriggerEnter2D because of the initial push.  
            } //initial push

            //OUTSIDE THE INITIAL PUSH

        } //because of initial push
        if (target.tag == TagManager.NORMAL_PUSH_TAG)
        {
            myBody.velocity = new Vector2(myBody.velocity.x, normalPush);
            target.gameObject.SetActive(false); //deactivates the banana

            push_Count++;
            
            //Sound manager

        }

        if (target.tag == TagManager.EXTRA_PUSH_TAG)
        {
            myBody.velocity = new Vector2(myBody.velocity.x, extraPush);
            target.gameObject.SetActive(false); //deactivates the banana bunch

            push_Count++;

            //sound manager

        }

        if (push_Count == 2)
        {
            push_Count = 0;
            PlatformSpawner.instance.SpawnPlatforms();
        }

        
    } // OnTriggerEnter





} //class
