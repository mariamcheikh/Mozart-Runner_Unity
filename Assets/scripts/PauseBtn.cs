using UnityEngine;
using UnityEngine.UI;

public class PauseBtn : MonoBehaviour {

    public Button pause;
    public GameObject resumePanel;

    void Start()
    {
        Button btn = pause.GetComponent<Button>();
        btn.onClick.AddListener(onPauseGame);
    }

    public void onPauseGame()
    {
        GameControll.instance.isPause = true;
        Time.timeScale = 0;
        resumePanel.gameObject.SetActive(true);
        GameControll.instance.noise.Stop();
        GameControll.instance.soft.Stop();
    }
}
