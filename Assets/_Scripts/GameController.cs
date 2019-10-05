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

    

    // Start is called before the first frame update
    void Start()
    {
        SceneConfiguration();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SceneConfiguration()
    {
        clouds = new List<GameObject>();

        for (int cloudNum = 0; cloudNum < numClouds; cloudNum++)
        {
            clouds.Add(Instantiate(cloud));
        }

        enemies = new List<GameObject>();

        for (int enemyNum = 0; enemyNum < numEnemy; enemyNum++)
        {
            enemies.Add(Instantiate(enemy));
        }

        

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
