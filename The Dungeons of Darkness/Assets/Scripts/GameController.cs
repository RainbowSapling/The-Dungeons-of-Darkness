using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using Newtonsoft.Json;
using System;


public class GameController : MonoBehaviour
{
    public class Scene
    {
        public string scene;
        public string option1;
        public string option2;
    }

    InputAction option1;
    InputAction option2;

    // Array of all scenes and how they connect
    Scene[] sceneManager;

    // Narrator audio file
    [SerializeField] AudioSource narrator;

    void Start()
    {
        // Assign the input actions to the correct controller buttons
        option1 = InputSystem.actions.FindAction("Option1");
        option2 = InputSystem.actions.FindAction("Option2");

        // Play the narrator audio
        narrator.Play();

        // Load scenes from JSON file
        LoadScenes();

        // Assign current scene
        if (CurrentScene.currentScene.scene == null)
        {
            CurrentScene.currentScene = sceneManager[0];
        }

        //Scene test = Array.Find(sceneManager, element => element.scene == currentScene.option1);
        Debug.Log(CurrentScene.currentScene.scene);
    }

    void Update()
    {
        // Wait untill the narrator has finished talking
        if (narrator.isPlaying == false)
        {
            // If the current scene doesn't require a choice, continue to the next scene
            if (CurrentScene.currentScene.option2 == null)
            {
                // Switch scene
                SceneManager.LoadScene(CurrentScene.currentScene.option1);
                // Update current scene
                CurrentScene.currentScene = Array.Find(sceneManager, element => element.scene == CurrentScene.currentScene.option1);
            }

            // If the current scene does have a choice, listen for controller input
            else
            {
                if (option1.IsPressed())
                {
                    Debug.Log("Option 1 was pressed");
                    // Switch scene
                    SceneManager.LoadScene(CurrentScene.currentScene.option1);
                    // Update current scene
                    CurrentScene.currentScene = Array.Find(sceneManager, element => element.scene == CurrentScene.currentScene.option1);
                }

                if (option2.IsPressed())
                {
                    Debug.Log("Option 2 was pressed");
                    // Switch scene
                    SceneManager.LoadScene(CurrentScene.currentScene.option2);
                    // Update current scene
                    CurrentScene.currentScene = Array.Find(sceneManager, element => element.scene == CurrentScene.currentScene.option2);
                }
            }
        }
    }

    // Read all scene connections from JSON file and store in variable
    void LoadScenes()
    {
        string filePath = Application.dataPath + "/Scenes/sceneManager.json";
        string sceneData = System.IO.File.ReadAllText(filePath);

        sceneManager = Newtonsoft.Json.JsonConvert.DeserializeObject<Scene[]>(sceneData);
    }

}
