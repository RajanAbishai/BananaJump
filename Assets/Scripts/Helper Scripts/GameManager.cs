using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;


    public Text scoreToBeDisplayed;
    
    


    private void Start()
    {

    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

    }

    public void RestartGame()
    {
        Invoke("LoadGamePlay", 2f);
    }


    void LoadGamePlay()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(TagManager.GAMEPLAY_TAG);
    }




} //class
