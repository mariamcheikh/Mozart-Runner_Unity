using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hero : MonoBehaviour {


    public GameObject MainCamera;
    public float UpForce = 1500f;
    public static bool IsDead = false;
    public Rigidbody2D Hero;
    public int click = 0;
    private Animator myAnimator;
    public bool Flying=false;
    

    // Use this for initialization
    void Start()
    {
        IsDead = false;
        Hero = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameControll.instance.isPause)
        {
            if (IsDead == false)
            {
                Vector2 offset = new Vector2(GameControll.instance.scrollSpeed, Hero.transform.position.y);
                Hero.transform.position = offset;
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                {
                    click++;
                    if (click > 2)
                    {
                        if (GameControll.instance.progressBarValue > GameControll.instance.progressMin)
                        {
                            Hero.velocity = Vector2.zero;
                            Hero.AddForce(new Vector2(0, UpForce));
                            GameControll.instance.healthMinus = true;
                            Flying = true;
                            myAnimator.SetBool("Flying", Flying);
                        }
                    }
                    else
                    {
                        Flying = false;

                        if (click == 2)
                        {
                            GameControll.instance.healthMinus = true;
                            Hero.velocity = Vector2.zero;
                            Hero.AddForce(new Vector2(0, UpForce));
                        }
                        else
                        {
                            Flying = false;

                            if (click == 1)
                            {
                                Hero.velocity = Vector2.zero;
                                Hero.AddForce(new Vector2(0, UpForce));
                            }
                            Flying = false;
                        }
                        Flying = false;
                    }
                    Flying = false;
                }
                Flying = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //reset mouse click count
        if (collision.gameObject.tag == "ground")
        {
            click = 0;
            myAnimator.SetBool("Flying", false);
        }
        //set game to over
        if (collision.gameObject.tag == "obstacle")
        {
            Hero.velocity = Vector2.zero;
            IsDead = true;
            GameControll.instance.HeroDied();
        }
        if (collision.gameObject.tag == "tone")
        {
            Destroy(collision.gameObject);
            print("tone collision");
        }
    }

}
