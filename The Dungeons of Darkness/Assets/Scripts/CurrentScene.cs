using UnityEngine;

public class CurrentScene : MonoBehaviour
{

    // Global variable for storing the current scene in the game
    public static GameController.Scene currentScene = new GameController.Scene();


    void Start()
    {
        DontDestroyOnLoad(gameObject);  
    }

    
}
