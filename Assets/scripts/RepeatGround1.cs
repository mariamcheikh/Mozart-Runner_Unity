using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatGround1 : MonoBehaviour {

    private float groundHorizontalLength;       //A float to store the x-axis length of the collider2D attached to the Ground GameObject.
    public GameObject droupyGround;
    public GameObject[] obstacles;


    //Awake is called before Start.
    private void Awake()
    {
        //Get and store a reference to the collider2D attached to Ground.
        //groundCollider = GetComponent<BoxCollider2D>();
        //Store the size of the collider along the x axis (its length in units).
        groundHorizontalLength = 72f;
    }

    private void Start()
    {
        droupyGround.GetComponent<Renderer>().enabled = false;
        droupyGround.GetComponent<Collider2D>().enabled = false;
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

        Vector3 offset;
        if (GameControll.instance.score > 30)
        {
            offset = new Vector3(Random.Range(7f, 9.5f) - 1f, transform.localScale.y, transform.localScale.z);
            transform.localScale = offset;
            droupyGround.GetComponent<Renderer>().enabled = true;
            droupyGround.GetComponent<Collider2D>().enabled = true;
        }
        else
        {
            offset = new Vector3(Random.Range(7f, 9.5f), transform.localScale.y, transform.localScale.z);
            transform.localScale = offset;
        }

        //generate animated grounds
        if (GameControll.instance.score > 60)
        {
            BoxCollider2D collider = GetComponent<BoxCollider2D>();
            Vector2 size = collider.size;
            Vector3 worldPos = transform.TransformPoint(collider.offset);
            float top = worldPos.y + (size.y / 2);
            float left = worldPos.x - 18f;
            float right = worldPos.x + 18f;
            for (int i = 0; i < Random.Range(0, 3); i++)
            {
            GameObject guitarTmp = Instantiate(obstacles[Random.Range(0, obstacles.Length)], new Vector3(Random.Range(left, right), top + 15f, transform.position.z)
                , Quaternion.identity) as GameObject;
            }
        }
    }
}
