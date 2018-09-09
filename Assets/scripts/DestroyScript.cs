using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyScript : MonoBehaviour
{
    
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "obstacle" || col.gameObject.tag == "tone")
        {
            Destroy(col.gameObject);
        }


    }

}
