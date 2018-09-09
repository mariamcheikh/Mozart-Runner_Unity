using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class GameControll : MonoBehaviour {

    public static GameControll instance;         //A reference to our game control script so we can access it statically.
    public Text scoreText;                      //A reference to the UI text component that displays the player's score.
    public GameObject gameOvertext;             //A reference to the object that displays the text which appears when the player dies.
    public GameObject Hero;
    public bool gameOver = false;               //Is the game over?
    public AudioSource noise;
    public AudioSource soft;
    public int score = 0;                      //The player's score.
    public bool noisy = true;
    public float scrollSpeed = -30f;
    public GameObject health;
    public bool healthActive = true;
    public bool healthMinus = false;
    public float progressBarValue = 0;
    public float progressMin = 0.3f;
    public GameObject resumePanel;
    public float Vol = 1f;
    public GameObject HeartBeatPanel;

    public bool isPause = false;

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

    void Start()
    {
        //increment score
        StartCoroutine(IncrementScore());
        resumePanel.gameObject.SetActive(false);
        //HeartBeatPanel.gameObject.SetActive(true);
        noise.Play();
        soft.Stop();
    }

    

    void Update()
    {
        if (!isPause)
        {
            //If the game is over and the player has pressed some input...
            if (gameOver)
            {
                //...reload the start scene.
                SceneManager.LoadScene(0);
            }
            else
            {
                if (noisy && !noise.isPlaying)
                {
                    if (soft.isPlaying)
                    {
                        /*while (Vol > 0)
                        {
                            Vol -= Time.deltaTime;
                            soft.volume = Vol;
                        }*/
                        soft.Stop();
                        Vol = 1;
                    }
                    noise.Play();

                }
                else
                {
                    if (!noisy && !soft.isPlaying)
                    {
                        if (noise.isPlaying)
                        {
                            /*while (Vol > 0)
                            {
                                Vol -= Time.deltaTime;
                                noise.volume = Vol;
                            }*/
                            noise.Stop();
                            Vol = 1;
                        }
                        soft.Play();
                    }
                }
                if (!healthActive)
                {
                    score += 10;
                    StartCoroutine(ReactivateHealth());
                    healthActive = true;
                }
            }
        }
    }

    IEnumerator ReactivateHealth()
    {
        yield return new WaitForSeconds(3);
        health.GetComponent<Renderer>().enabled = true;
    }

    /*public void HeroScore()
    {
        //The bird can't score if the game is over.
        if (gameOver)
        {
            return;
        }
        //If the game is not over, increase the score...
        //StartCoroutine(changeScoreByTime());
        score += ((int)Time.timeScale);
        //...and adjust the score text.
        scoreText.text = "Score: " + score.ToString();
    }*/

    IEnumerator IncrementScore()
    {
        while (!gameOver)
        {
            yield return new WaitForSeconds(1);
            score++;
            scoreText.text = "Score: " + score.ToString();
        }
    }

    public void HeroDied()
    {
        //Set up the game to be over.
        gameOver = true;
        PlayerPrefs.SetInt("score", score);
        PlayerPrefs.Save();
        int best = PlayerPrefs.GetInt("best");
        if (score > best)
        {
            PlayerPrefs.SetInt("best", score);
            PlayerPrefs.Save();
        }
        noise.Stop();
        soft.Stop();
        SceneManager.LoadScene(0);
    }
}
