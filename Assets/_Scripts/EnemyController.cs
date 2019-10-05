using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    public Speed horizSpeedRange;
    [SerializeField]
    public Speed vertiSpeedRange;

    public float vertiSpeed;
    public float horziSpeed;

    [SerializeField]
    public Boundary boundary;

    [Header("explosion settings")]
    public GameObject explosion;

    public GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        Reset();
        //finding the Game Controller by the tag GameController
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            //get the gamecontroller so it can be used
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        //if gamecontroller can't be found
        if (gameController == null)
        {
            //tell me its not there
            Debug.Log("Cannot find 'GameController' script");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Checkbound();
    }

    void Move()
    {
        //move the enemy
        Vector2 newPosition = new Vector2(horziSpeed, vertiSpeed);
        Vector2 currentPosition = transform.position;

        currentPosition -= newPosition;
        transform.position = currentPosition;
    }

    void Reset()
    {
        //randomly get a speed based on range
        horziSpeed = Random.Range(horizSpeedRange.min, horizSpeedRange.max);
        vertiSpeed = Random.Range(vertiSpeedRange.min, vertiSpeedRange.max);
        //reset the position of enemy randomly with random speed
        float randomXPos = Random.Range(boundary.Left, boundary.Right);
        transform.position = new Vector2(randomXPos, Random.Range(boundary.Top, boundary.Top + 2.0f));
    }

    void Checkbound()
    {
        //if enemy makes it to the bottom of the screen reset it so it come back down to attack player
        if (transform.position.y <= boundary.Bottom)
        {
            Reset();
        }
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //using explosion prefab
        if (other.tag == "Player")
        {
            //explosion for player and enemy
            Instantiate(explosion, other.transform.position, other.transform.rotation);
            Instantiate(explosion, this.transform.position, this.transform.rotation);
            //subtrack from player's lives if they have more then 1 
            if(gameController.health > 1)
            {
                gameController.health--;
            }
            else
            {
                //if health is = 0, destory the player
                gameController.health = 0;
                Destroy(other.gameObject);
            }
        }
        if (other.tag == "Bullet")
        {
            //explosion for the enemy being destroyed
            Instantiate(explosion, other.transform.position, other.transform.rotation);
            //add to total score
            gameController.score += 100;
            Destroy(other.gameObject);

        }
        
        //reset the enemy, its not destroyed
        Reset();

    }
}
