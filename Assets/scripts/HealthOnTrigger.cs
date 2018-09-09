using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthOnTrigger : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //set health point hidden
            GetComponent<Renderer>().enabled = false;
            GameControll.instance.healthActive = false;
        }
    }
}
