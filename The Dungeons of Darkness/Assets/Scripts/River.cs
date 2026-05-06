using UnityEngine;

public class River : MonoBehaviour
{
    public static River instance;

    // All music clips
    AudioClip river;



    void Awake()
    {
        river = Resources.Load<AudioClip>("Sea");

        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    void Update()
    {

        // River -> start
        if (CurrentScene.currentScene.scene == "R1")
        {
            this.gameObject.GetComponent<AudioSource>().clip = river;
        }
        // Dungeon -> nothing
        if (CurrentScene.currentScene.scene == "D1")
        {
            this.gameObject.GetComponent<AudioSource>().clip = null;
        }


        // Play music
        if (this.gameObject.GetComponent<AudioSource>().isPlaying == false)
        {
            this.gameObject.GetComponent<AudioSource>().Play();
        }
    }
}
