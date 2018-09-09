using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartBeatControll : MonoBehaviour {

    private Animator anim;

	// Use this for initialization
	void Start ()
    {
        anim = GetComponent<Animator>();	
	}
	
	// Update is called once per frame
	void Update ()
    {
        //if(GameControll.instance.noisy == false)
        if (GameControll.instance.progressBarValue >= 0.3f)
        {
            anim.SetTrigger("changeGood");
            anim.SetTrigger("changedGood");
            GameControll.instance.noisy = false;
        }
        else
        {
            anim.SetTrigger("changeBad");
            anim.SetTrigger("changedBad");
            GameControll.instance.noisy = true;
        }
    }
}
