using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBar : MonoBehaviour {

    public float progress = 0f;
    public Vector2 size = new Vector2(200f, 20f);
    public Texture2D emptyProgress;
    public Texture2D fullProgess;
    public float run = 0.01f;
    public float speed = 0f;
    public GameObject heartbeatLine;
    public float paddingX = 74;
    public float paddingY = 544;
    
    private void OnGUI()
    {
        GUI.DrawTexture(new Rect(heartbeatLine.transform.position.x + paddingX, heartbeatLine.transform.position.y - paddingY, size.x, size.y), emptyProgress);
        GUI.DrawTexture(new Rect(heartbeatLine.transform.position.x + paddingX + 3f, heartbeatLine.transform.position.y -paddingY + 2f, size.x * Mathf.Clamp(progress, 0f, 0.97f), size.y - 4f), fullProgess);
    }

    private void Start()
    {
        progress = 0.6f;
    }

    IEnumerator increment()
    {
        if(progress < 0.97f)
        {
            progress = progress + run;
            yield return new WaitForSeconds(speed);
            progress = progress + run;
            yield return new WaitForSeconds(speed);
            progress = progress + run;
            yield return new WaitForSeconds(speed);
            progress = progress + run;
            yield return new WaitForSeconds(speed);
            progress = progress + run;
            yield return new WaitForSeconds(speed);
            progress = progress + run;
            yield return new WaitForSeconds(speed);
            progress = progress + run;
            yield return new WaitForSeconds(speed);
            progress = progress + run;
            yield return new WaitForSeconds(speed);
        }
        else
        {
            yield return new WaitForSeconds(speed);
        }
    }

    IEnumerator decrement()
    {
        if (progress > run)
        {
            progress = progress - run;
            yield return new WaitForSeconds(speed);
            progress = progress - run;
            yield return new WaitForSeconds(speed);
            progress = progress - run;
            yield return new WaitForSeconds(speed);
            progress = progress - run;
            yield return new WaitForSeconds(speed);
        }
        else
        {
            GameControll.instance.HeroDied();
        }
    }

    // Update is called once per frame
    void Update ()
    {
	    if(GameControll.instance.healthActive == false)
        {
            StartCoroutine(increment());
            Debug.Log("progress UP = " + progress);
        }
        if (GameControll.instance.healthMinus == true /*&& progress >= (run * 4)*/)
        {
            StartCoroutine(decrement());
            GameControll.instance.healthMinus = false;
            Debug.Log("progress DOWN = " + progress);
        }
        GameControll.instance.progressBarValue = progress;
    }
}
