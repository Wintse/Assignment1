using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndController : MonoBehaviour
{
    public GameObject endButton;

    //if end button is clicked go to main game
    public void OnEndButtonClick()
    {
        
        SceneManager.LoadScene("Main");

    }
}
