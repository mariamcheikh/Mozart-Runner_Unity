using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startScene : MonoBehaviour {

    public GameObject MainCamera;
    private float MaxWidth = 105f;
    private float MinWidth = -28f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if(MainCamera.transform.position.x < MaxWidth)
        {
            MainCamera.transform.position = new Vector3(MainCamera.transform.position.x + 0.05f, MainCamera.transform.position.y, MainCamera.transform.position.z);
        }
        else
        {
            MainCamera.transform.position = new Vector3(MinWidth, MainCamera.transform.position.y, MainCamera.transform.position.z);
        }
        
    }
}
