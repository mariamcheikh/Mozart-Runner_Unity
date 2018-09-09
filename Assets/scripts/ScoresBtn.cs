using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoresBtn : MonoBehaviour {

    public Button scores;

    void Start()
    {
        Button btn = scores.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    public void TaskOnClick()
    {
        Debug.Log("You have clicked SCIRES!");
    }
}
