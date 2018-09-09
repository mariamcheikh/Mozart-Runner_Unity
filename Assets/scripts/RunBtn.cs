using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RunBtn : MonoBehaviour {

    
    public Button Run;
    private LoadingGame loading;
    private bool runIt = false;
    

    void Start()
    {
        Button btn = Run.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    private IEnumerator LoadALevel()
    {
        GameControllStart.instance.async = SceneManager.LoadSceneAsync(1);
        yield return GameControllStart.instance.async;
    }

    private IEnumerator increment()
    {
        GameControllStart.instance.check = true;
        GameControllStart.instance.progress = GameControllStart.instance.progress + 0.001f;
        yield return new WaitForSeconds(0);
        GameControllStart.instance.check = false;
    }

    public void TaskOnClick()
    {
        runIt = true;
        StartCoroutine(LoadALevel());
        GameControllStart.instance.loadingPanel.gameObject.SetActive(true);
        GameControllStart.instance.check = false;
    }

    private void Update()
    {
        if (runIt)
        {
            GameControllStart.instance.progress = GameControllStart.instance.progress + 0.005f;
        }
    }

    IEnumerator LoadAsyncScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(1);
        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            Debug.Log("Loaded Loaded Loaded Loaded Loaded Loaded Loaded Loaded Loaded ");
            yield return null;
        }
    }
}
