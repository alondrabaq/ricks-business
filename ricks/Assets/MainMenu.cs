using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame(){
        //added 1 because thats the index of the kitchen scene
        SceneManager.LoadSceneAsync("Main Kitchen");
    }
}
