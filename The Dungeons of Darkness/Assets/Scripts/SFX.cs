using UnityEngine;

public class SFX : MonoBehaviour
{

    public static SFX instance;

    // All music clips
    AudioClip birds1;
    AudioClip birds2;
    AudioClip crickets;
    AudioClip villageBirds;


    void Awake()
    {
        birds1 = Resources.Load<AudioClip>("Birds1");
        birds2 = Resources.Load<AudioClip>("Birds2");
        crickets = Resources.Load<AudioClip>("Crickets");
        villageBirds = Resources.Load<AudioClip>("VillageBirds");

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

        // Village daytime -> birds
        if (CurrentScene.currentScene.scene == "VD1" || CurrentScene.currentScene.scene == "TD6")
        {
            this.gameObject.GetComponent<AudioSource>().clip = villageBirds;
        }
        // Village nighttime -> crickets
        if (CurrentScene.currentScene.scene == "VN1" || CurrentScene.currentScene.scene == "TN6")
        {
            this.gameObject.GetComponent<AudioSource>().clip = crickets;
        }






        // Play music
        if (this.gameObject.GetComponent<AudioSource>().isPlaying == false)
        {
            this.gameObject.GetComponent<AudioSource>().Play();
        }
    }
    
}
