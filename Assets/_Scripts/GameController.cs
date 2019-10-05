using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [Header("Game Objects")]
    public GameObject cloud;
    public int numClouds;
    public List<GameObject> clouds;
    public GameObject enemy;
    public int numEnemy;
    public List<GameObject> enemies;

    [Header("UI settings")]
    public Text scoreText;
    public Text healthText;


    //variables 
    [SerializeField]
    public int score;
    public int health;


    // Start is called before the first frame update
    void Start()
    {
        health = 3;
        score = 0;
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
        //cloud object list
        clouds = new List<GameObject>();
        //the number of clouds to spawn based on the number inputed
        for (int cloudNum = 0; cloudNum < numClouds; cloudNum++)
        {
            clouds.Add(Instantiate(cloud));
        }
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
    }

}

/*
 * Thats it for today by Some of the songs and/or sound efects in this project were created by ViRiX Dreamcore
 * (David Mckee). www.virixcore.net for more information
 * music by Mega Pixel Music Lab (melody++)
 * gunfire by KuraiWolf
 * explosion by TinyWorlds
 * explosion art by Gumichan01
 * potato, tomato, grass, bullet, cloud, by me
 */
