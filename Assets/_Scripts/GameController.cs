using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
 * Victoria Liu
 * This is the game controller
 * it deals with UI such as score and health
 * instantiates enemies
 * some parts taken from tom's code from mail pilot
 * 
 * art and music notes:
 * Thats it for today by Some of the songs and/or sound efects in this project were created by ViRiX Dreamcore
 * (David Mckee). www.virixcore.net for more information
 * unused music(melody++) by Mega Pixel Music Lab 
 * gunfire by KuraiWolf
 * explosion by TinyWorlds
 * explosion art by Gumichan01
 * potato, tomato, grass, bullet, button, start screen and end screen by me (Victoria Liu)
 */


public class GameController : MonoBehaviour
{
    //game objects
    [Header("Game Objects")]
    public GameObject enemy;
    public int numEnemy;
    public List<GameObject> enemies;

    //for text
    [Header("UI settings")]
    public Text scoreText;
    public Text healthText;


    //variables, serialized so they can be used in enemy controller
    [SerializeField]
    public int score;
    public int health;


    // Start is called before the first frame update
    void Start()
    {
        
        //calls for scene config
        SceneConfiguration();
    }

    // Update is called once per frame
    void Update()
    {
        ScoreUpdate();
        LivesUpdate();
    }

    private void SceneConfiguration()
    {
        
        //enemy object list
        enemies = new List<GameObject>();
        //the number of enemies to spawn based on the number inputed
        for (int enemyNum = 0; enemyNum < numEnemy; enemyNum++)
        {
            enemies.Add(Instantiate(enemy));
        }

    }
    
    //updates the score and puts it to the text
    public void ScoreUpdate()
    {
        scoreText.text = "SCORE: " + score;
    }
    //updates the lives and puts it to the text
    public void LivesUpdate()
    {
        healthText.text = "HEALTH: " + health;
        //load the end/restart scene
        if (health == 0)
        {
            SceneManager.LoadScene("End");
        }
    }

}

