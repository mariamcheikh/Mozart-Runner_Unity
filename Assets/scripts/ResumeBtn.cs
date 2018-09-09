using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResumeBtn : MonoBehaviour {

    public Button resumeBtn;
    public GameObject resumePanel;

    void Start()
    {
        Button btn = resumeBtn.GetComponent<Button>();
        btn.onClick.AddListener(onResumeGame);
    }

    public void onResumeGame()
    {
        GameControll.instance.isPause = false;
        Time.timeScale = 1;
        resumePanel.gameObject.SetActive(false);
    }
}
