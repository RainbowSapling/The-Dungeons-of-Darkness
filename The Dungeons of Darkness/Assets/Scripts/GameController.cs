using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    InputAction option1;
    InputAction option2;

    [SerializeField] AudioSource narrator;

    void Start()
    {
        option1 = InputSystem.actions.FindAction("Option1");
        option2 = InputSystem.actions.FindAction("Option2");

        narrator.Play();
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


}
