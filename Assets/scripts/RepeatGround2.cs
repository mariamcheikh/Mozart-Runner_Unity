using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatGround2 : MonoBehaviour {

    private float groundHorizontalLength;       //A float to store the x-axis length of the collider2D attached to the Ground GameObject.


    //Awake is called before Start.
    private void Awake()
    {
        //Get and store a reference to the collider2D attached to Ground.
        //groundCollider = GetComponent<BoxCollider2D>();
        //Store the size of the collider along the x axis (its length in units).
        groundHorizontalLength = 72f;
    }

    //Update runs once per frame
    private void Update()
    {
        //Check if the difference along the x axis between the main Camera and the position of the object this is attached to is greater than groundHorizontalLength.
        if (transform.position.x < -groundHorizontalLength)
        {
            //If true, this means this object is no longer visible and we can safely move it forward to be re-used.
            RepositionBackground();
        }
    }

    //Moves the object this script is attached to right in order to create our looping background effect.
    private void RepositionBackground()
    {
        // initialise postion ground
        transform.position = new Vector2(transform.position.x, 0f);
        // set up height position of the ground (position->y)
        Vector2 groundOffSet = new Vector2(groundHorizontalLength * 2f, Random.Range(-8f, -1f));
        transform.position = (Vector2)transform.position + groundOffSet;
        //set up the groung width (scale->x)
        transform.localScale = new Vector3(Random.Range(7f, 9.5f), transform.localScale.y, transform.localScale.z);
    }
}
