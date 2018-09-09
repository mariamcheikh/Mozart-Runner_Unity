using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControllStart : MonoBehaviour {

    public static GameControllStart instance;         //A reference to our game control script so we can access it statically.
    public GameObject loadingPanel;
    public Text Score;
    public Text Best;
    public bool check = true;
    public AsyncOperation async = null;
    public float progress = 0f;

    void Awake()
    {
        //If we don't currently have a game control...
        if (instance == null)
            //...set this one to be it...
            instance = this;
        //...otherwise...
        else if (instance != this)
            //...destroy this one because it is a duplicate.
            Destroy(gameObject);
    }

    // Use this for initialization
    void Start () {
        loadingPanel.gameObject.SetActive(false);
        Score.text = "Score : " + PlayerPrefs.GetInt("score");
        Best.text = "BestScore : " + PlayerPrefs.GetInt("best");
    }
	
	// Update is called once per frame
	void Update () {
        
    }
}
