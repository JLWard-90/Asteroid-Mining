﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavManager : MonoBehaviour
{
    public int selectedAsteroidIndex;
    public static NavManager instance;
    AsteroidManager asteroidManager;
    void Awake()
    {
        //check if instance exists
        if (instance == null)
        {
            //assign it to the current object:
            instance = this;
        }
        //make sure instance is the current object
        else if (instance != this)
        {
            //destroy the current game object
            Destroy(gameObject);
        }
        //don't destroy on changing scene
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        asteroidManager = GameObject.Find("GameController").GetComponent<AsteroidManager>();
    }
    public void OnTestButtonPush()
    {
        SceneManager.LoadScene("AsteroidScene");
    }
    public void GoToStrategicOverlay()
    {
        SceneManager.LoadScene("StrategicScreen");
        asteroidManager = GameObject.Find("GameController").GetComponent<AsteroidManager>();
        asteroidManager.InitAllAsteroidReps();
    }
}
