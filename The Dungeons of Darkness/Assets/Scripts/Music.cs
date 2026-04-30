using UnityEngine;

public class Music : MonoBehaviour
{

    public static Music instance;

    // All music clips
    AudioClip village1;
    AudioClip village2;
    AudioClip forrest1;
    AudioClip forrest2;
    AudioClip river1;


    void Awake()
    {
        village1 = Resources.Load<AudioClip>("Village1");
        village2 = Resources.Load<AudioClip>("Village2");
        forrest1 = Resources.Load<AudioClip>("Forrest1");
        forrest2 = Resources.Load<AudioClip>("Forrest2");
        river1 = Resources.Load<AudioClip>("River1");

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
        // Update music
        
        // Village daytime
        if(CurrentScene.currentScene.scene == "VD1" || CurrentScene.currentScene.scene == "TD6") 
        { 
            this.gameObject.GetComponent<AudioSource>().clip = village1;
            this.gameObject.GetComponent<AudioSource>().Play();
        }

        // River
        if (CurrentScene.currentScene.scene == "R1")
        {
            this.gameObject.GetComponent<AudioSource>().clip = river1;
            this.gameObject.GetComponent<AudioSource>().Play();
        }
    }
    
}
