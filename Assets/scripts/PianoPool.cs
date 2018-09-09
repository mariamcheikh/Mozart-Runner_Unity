using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoPool : MonoBehaviour {

    //public GameObject Hero;
    public GameObject ground1;
    public GameObject ground2;
    public GameObject PianoPrefab;                                 //The column game object.
    private float spawnRate = 5f;                                    //How quickly columns spawn.
    public Sprite pianoSprite;
    public Sprite hardoSprite;
    public Sprite ExtraHardoSprite;

    private float timeSinceLastSpawned;
    private int SpriteOrder;
    private bool moveObstacle;
    

    void Start()
    {
        timeSinceLastSpawned = 0f;

        //to manage obstacle sprites
        SpriteOrder = 1;
        moveObstacle = true;
    }

    //This spawns columns as long as the game is not over.
    void Update()
    {
        timeSinceLastSpawned += Time.deltaTime;
        moveObstacle = true;
        if (GameControll.instance.gameOver == false && timeSinceLastSpawned > spawnRate && ground1.transform.position.x < ground2.transform.position.x && moveObstacle)
        {
            timeSinceLastSpawned = 0f;
            //set up y & x obstacle postion
            float spawnYPosition = (ground2.transform.position.y + (ground2.GetComponent<SpriteRenderer>().bounds.size.y - 15.5f));
            float spawnXPosition = (Random.Range(ground2.transform.position.x - 5f, ground2.transform.position.x + (ground2.GetComponent<SpriteRenderer>().bounds.size.x / 2) - 2f));

            //change simultaneously the sprite obstacle
            if (SpriteOrder % 2 == 0)
                PianoPrefab.GetComponent<SpriteRenderer>().sprite = hardoSprite;
            else
                if (SpriteOrder % 5 == 0)
                PianoPrefab.GetComponent<SpriteRenderer>().sprite = ExtraHardoSprite;
            else
                PianoPrefab.GetComponent<SpriteRenderer>().sprite = pianoSprite;

            SpriteOrder++;
            //...then set the current obstacle to that position.
            PianoPrefab.transform.position = new Vector2(spawnXPosition, spawnYPosition);
            moveObstacle = false;
        }
    }
}
