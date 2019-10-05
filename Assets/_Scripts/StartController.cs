using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartController : MonoBehaviour
{

    public GameObject startButton;
    
    //if start button is clicked go to main game
    public void OnStartButtonClick()
    {
     
        SceneManager.LoadScene("Main");
        
    }
}
