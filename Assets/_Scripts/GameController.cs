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


    }

    



}
