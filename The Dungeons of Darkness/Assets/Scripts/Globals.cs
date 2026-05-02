using UnityEngine;
using System;

// Script for storing global variables

public class Globals : MonoBehaviour
{
    // Checkpoints
    public static GameController.Scene checkpoint = Array.Find(GameController.sceneManager, element => element.scene == "T1");

    // Found wizards house
    public static bool foundHouse = false;

    // Made donation
    public static bool madeDonation = false;
    
    // Companion
    public static string companion = null;


    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
