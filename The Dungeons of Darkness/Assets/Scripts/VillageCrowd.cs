using UnityEngine;

public class VillageCrowd : MonoBehaviour
{

    public static VillageCrowd instance;

    // All music clips
    AudioClip villageCrowd;


    void Awake()
    {
        villageCrowd = Resources.Load<AudioClip>("VillageCrowd");

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
        // Update sfx

        // Village daytime -> crowd
        if (CurrentScene.currentScene.scene == "VD1" || CurrentScene.currentScene.scene == "TD6")
        {
            this.gameObject.GetComponent<AudioSource>().clip = villageCrowd;
        }
        // Turn off
        if (CurrentScene.currentScene.scene == "V2" || CurrentScene.currentScene.scene == "V3")
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
