using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using Newtonsoft.Json;
using System;
using System.Collections;
using TMPro;
using UnityEditor;
using UnityEditor.SceneManagement;


public class GameController : MonoBehaviour
{
    // Class for scenes
    public class Scene
    {
        public string scene;
        public string option1;
        public string option2;
    }

    InputAction option1;
    InputAction option2;

    // Array of all scenes and how they connect
    public static Scene[] sceneManager;

    // Narrator audio file
    [SerializeField] AudioSource narrator;

    // Game over sound effect
    AudioClip gameOver;

    // Combat sound effect
    AudioClip combat;

    // Text boxes
    [SerializeField] TMP_Text displayCurrent;
    [SerializeField] TMP_Text displayOption1;
    [SerializeField] TMP_Text displayOption2;

    void Awake()
    {
        // Assign audio clip
        gameOver = Resources.Load<AudioClip>("Death1");
        combat = Resources.Load<AudioClip>("Combat");
    }

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
            // Find active scene (able to start game from any scene for testing)
            string activeScene = SceneManager.GetActiveScene().name;
            // Set current scene to active scene
            CurrentScene.currentScene = Array.Find(sceneManager, element => element.scene == activeScene);
        }

        // Update text on screen
        displayCurrent.text = CurrentScene.currentScene.scene;
        displayOption1.text = CurrentScene.currentScene.option1;
        displayOption2.text = CurrentScene.currentScene.option2;
    }

    void Update()
    {
        // Wait untill the narrator has finished talking
        if (narrator.isPlaying == false)
        {
            // Game over -> retart from latest checkpoint
            if (CurrentScene.currentScene.option1 == null && CurrentScene.currentScene.option2 == null)
            {
                // Check if it's the last scene, if it is close game
                if (CurrentScene.currentScene.scene == "O1")
                {
#if UNITY_EDITOR
                    EditorApplication.ExitPlaymode();
#else
                    Application.Quit();
                    Debug.Log("quit");
#endif
                }
                
                // Play game over sound
                narrator.clip = gameOver;
                float gameOverSoundLength = narrator.clip.length;
                narrator.Play();

                StartCoroutine(GameOver(gameOverSoundLength));   
            }
            
            // If the current scene doesn't require a choice, continue to the next scene
            else if (CurrentScene.currentScene.option2 == null)
            {
                // If combat scene -> play combat sounds
                if (CurrentScene.currentScene.scene == "C1" || CurrentScene.currentScene.scene == "C2" || CurrentScene.currentScene.scene == "C3" || CurrentScene.currentScene.scene == "C4" ||
                    CurrentScene.currentScene.scene == "C5" || CurrentScene.currentScene.scene == "C6")
                {
                    // Play combat sounds
                    narrator.clip = combat;
                    float combatSoundLength = narrator.clip.length;
                    narrator.Play();

                    StartCoroutine(ContinueAfterCombat(combatSoundLength));
                }
                else
                {
                    // Switch scene
                    SceneManager.LoadScene(CurrentScene.currentScene.option1);
                    // Update current scene
                    CurrentScene.currentScene = Array.Find(sceneManager, element => element.scene == CurrentScene.currentScene.option1);
                }
                
            }

            // If the current scene does have a choice, listen for controller input
            else
            {
                EdgeCases();

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

        // Update globals

        // ------------------------- Checkpoints -----------------------------
        // Forest checkpoint
        if (CurrentScene.currentScene.scene == "F1")
        {
            Globals.checkpoint = CurrentScene.currentScene;
        }
        // River checkpoint
        if (CurrentScene.currentScene.scene == "R1")
        {
            Globals.checkpoint = CurrentScene.currentScene;
        }
        // Dungeon checkpoint
        if (CurrentScene.currentScene.scene == "D1")
        {
            Globals.checkpoint = CurrentScene.currentScene;
        }

        // --------------- Companion ------------------
        // Player teamed up with Rody
        if (CurrentScene.currentScene.scene == "F19")
        {
            Globals.companion = "Rody";
        }
        // Player teamed up with Saber 
        if (CurrentScene.currentScene.scene == "R18")
        {
            Globals.companion = "Saber";
        }


        // ------------ Others -------------
        // Player found the wizards old house
        if (CurrentScene.currentScene.scene == "VD9")
        {
            Globals.foundHouse = true;
        }

        // Player made a donation to the kobold
        if (CurrentScene.currentScene.scene == "D37")
        {
            Globals.madeDonation = true;
        }

    }

    // Read all scene connections from JSON file and store in variable
    void LoadScenes()
    {
        string filePath = Application.dataPath + "/Scenes/sceneManager.json";
        string sceneData = System.IO.File.ReadAllText(filePath);

        sceneManager = Newtonsoft.Json.JsonConvert.DeserializeObject<Scene[]>(sceneData);
    }

    // Edge cases for if/else statments in navigation
    void EdgeCases()
    {
        // House number
        if (CurrentScene.currentScene.scene == "D6")
        {
            if (Globals.foundHouse == true)
            {
                // Switch scene
                SceneManager.LoadScene("D8a");
                // Update current scene
                CurrentScene.currentScene = Array.Find(sceneManager, element => element.scene == "D8a");
                return;
            }
            else
            {
                // Switch scene
                SceneManager.LoadScene("D8b");
                // Update current scene
                CurrentScene.currentScene = Array.Find(sceneManager, element => element.scene == "D8b");
                return;
            }
        }

        // Donation
        if (CurrentScene.currentScene.scene == "D48")
        {
            if (Globals.madeDonation == true) 
            {
                // Switch scene
                SceneManager.LoadScene("D49");
                // Update current scene
                CurrentScene.currentScene = Array.Find(sceneManager, element => element.scene == "D49");
                return;
            }
            else
            {
                // Switch scene
                SceneManager.LoadScene("D51");
                // Update current scene
                CurrentScene.currentScene = Array.Find(sceneManager, element => element.scene == "D51");
                return;
            }
        }

        // Companion
        if (CurrentScene.currentScene.scene == "D49")
        {
            if (Globals.companion == "Rody")
            {
                // Switch scene
                SceneManager.LoadScene("D50a");
                // Update current scene
                CurrentScene.currentScene = Array.Find(sceneManager, element => element.scene == "D50a");
                return;
            }
            else if (Globals.companion == "Saber")
            {
                // Switch scene
                SceneManager.LoadScene("D50b");
                // Update current scene
                CurrentScene.currentScene = Array.Find(sceneManager, element => element.scene == "D50b");
                return;
            }
            else // No companion
            {
                // Switch scene
                SceneManager.LoadScene("D51");
                // Update current scene
                CurrentScene.currentScene = Array.Find(sceneManager, element => element.scene == "D51");
                return;
            }
        }
    }


    IEnumerator ContinueAfterCombat(float timeToWait)
    {
        yield return new WaitForSeconds(timeToWait);

        // Switch scene
        SceneManager.LoadScene(CurrentScene.currentScene.option1);
        // Update current scene
        CurrentScene.currentScene = Array.Find(sceneManager, element => element.scene == CurrentScene.currentScene.option1);

    }

    IEnumerator GameOver (float timeToWait)
    {
        yield return new WaitForSeconds(timeToWait);

        // Switch scene
        SceneManager.LoadScene(Globals.checkpoint.scene);
        // Update current scene
        CurrentScene.currentScene = Array.Find(sceneManager, element => element.scene == Globals.checkpoint.scene);

    }

}
