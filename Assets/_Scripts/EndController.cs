using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
 * Victoria Liu
 * end controller
 * used in end scene. if player clicks the restart button the scene will change to the main
 */
public class EndController : MonoBehaviour
{
    public GameObject endButton;

    //if end button is clicked go to main game
    public void OnEndButtonClick()
    {
        
        SceneManager.LoadScene("Main");

    }
}
