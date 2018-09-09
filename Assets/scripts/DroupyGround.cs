using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroupyGround : MonoBehaviour {

    private bool droupping = false;
    private float minDownDroupping = 3;
    private float drouppingY = 0;

    public GameObject ground1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            droupping = true;
        }

    }

    private void Update()
    {
        
        if (droupping)
        {
            drouppingY += Time.deltaTime;
            transform.position = new Vector3(transform.position.x, transform.position.y - (Time.deltaTime * 30), 0);
            if(drouppingY >= minDownDroupping)
            {
                droupping = false;
                transform.position = new Vector3(transform.position.x, ground1.transform.position.y, 0);
                drouppingY = 0;
                
            }
        }
        
    }
}
