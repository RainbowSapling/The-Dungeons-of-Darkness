using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using Newtonsoft.Json;

public class Scene
{
    public string scene;
    public string option1;
    public string option2;
}

public class GameController : MonoBehaviour
{
    InputAction option1;
    InputAction option2;

    Scene[] sceneManager;

    [SerializeField] AudioSource narrator;

    void Start()
    {
        option1 = InputSystem.actions.FindAction("Option1");
        option2 = InputSystem.actions.FindAction("Option2");

        narrator.Play();

        LoadScenes();
    }

    void Update()
    {
        if (option1.IsPressed() && narrator.isPlaying == false)
        {
            Debug.Log("Option 1 was pressed");
            SceneManager.LoadScene("T2");
        }

        if (option2.IsPressed() && narrator.isPlaying == false)
        {
            Debug.Log("Option 2 was pressed");
            SceneManager.LoadScene("T3");
        }
    }


    void LoadScenes()
    {
        string filePath = Application.dataPath + "/Scenes/sceneManager.json";
        string sceneData = System.IO.File.ReadAllText(filePath);

        sceneManager = Newtonsoft.Json.JsonConvert.DeserializeObject<Scene[]>(sceneData);

        Debug.Log(sceneManager[1].scene);
    }

}
