using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

/*
 * Victoria Liu
 * Enemy Controller
 * some code from tom's code from Mail Pilot
 * moves the enemy, destroys bullets on contact and resets the tomato and adds points to score. 
 * explosion goes off and enemy will reset if player is hit and subtracks from health
 * if player has no more health the player is destoryed 
 */
public class EnemyController : MonoBehaviour
{
    //range for speed
    [SerializeField]
    public Speed horizSpeedRange;
    [SerializeField]
    public Speed vertiSpeedRange;
    

    //boundary from Boundary
    [SerializeField]
    public Boundary boundary;

    //explosion game object
    [Header("explosion settings")]
    public GameObject explosion;
    //the game controller so it can get to the the score and health
    public GameController gameController;

    //the horizontal and vertical speed
    float vertiSpeed;
    float horziSpeed;

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
        //the newposition is the position it will to next. current position is where the enemy is at that point in time
        Vector2 newPosition = new Vector2(horziSpeed, vertiSpeed);
        Vector2 currentPosition = transform.position;
        //take the current position and subtrack the new position since the the enemy is moving down
        //make this the new position
        transform.position = currentPosition - newPosition;
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
        //if enemy makes it to the bottom, left or right of the screen reset it so it come back down to attack player
        if (transform.position.y <= boundary.Bottom || transform.position.x <= boundary.Left - 1.0f || transform.position.x >= boundary.Right + 1.0f)
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
                //if health is = 0, destroy the player
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
