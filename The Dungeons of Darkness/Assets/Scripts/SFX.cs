using UnityEngine;

public class SFX : MonoBehaviour
{

    public static SFX instance;

    // All music clips
    AudioClip birds1;
    AudioClip birds2;
    AudioClip crickets;
    AudioClip villageBirds;
    AudioClip tavernCrowd;


    void Awake()
    {
        birds1 = Resources.Load<AudioClip>("Birds1");
        birds2 = Resources.Load<AudioClip>("Birds2");
        crickets = Resources.Load<AudioClip>("Crickets");
        villageBirds = Resources.Load<AudioClip>("VillageBirds");
        tavernCrowd = Resources.Load<AudioClip>("TavernCrowd");

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


        // Tavern checkpoint
        if (CurrentScene.currentScene.scene == "T1")
        {
            this.gameObject.GetComponent<AudioSource>().clip = null;
        }
        // Tavern night
        if (CurrentScene.currentScene.scene == "TN1")
        {
            this.gameObject.GetComponent<AudioSource>().clip = tavernCrowd;
        }
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
        // Forest -> birds2
        if (CurrentScene.currentScene.scene == "F1")
        {
            this.gameObject.GetComponent<AudioSource>().clip = birds2;
        }
        // River -> nothing
        if (CurrentScene.currentScene.scene == "R1")
        {
            this.gameObject.GetComponent<AudioSource>().clip = null;
        }
        // Dungeon -> nothing
        if (CurrentScene.currentScene.scene == "D1")
        {
            this.gameObject.GetComponent<AudioSource>().clip = null;
        }
        // End
        if (CurrentScene.currentScene.scene == "END1" || CurrentScene.currentScene.scene == "END2" || CurrentScene.currentScene.scene == "END3" || CurrentScene.currentScene.scene == "END4" ||
            CurrentScene.currentScene.scene == "END5" || CurrentScene.currentScene.scene == "END6" || CurrentScene.currentScene.scene == "END7" || CurrentScene.currentScene.scene == "END8" ||
            CurrentScene.currentScene.scene == "END9" || CurrentScene.currentScene.scene == "END10")
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
