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
