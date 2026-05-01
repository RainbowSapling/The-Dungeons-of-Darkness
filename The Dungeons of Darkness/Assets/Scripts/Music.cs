using UnityEngine;

public class Music : MonoBehaviour
{

    public static Music instance;

    // All music clips
    AudioClip tavernRoom;
    AudioClip villageDay;
    AudioClip villageNight;
    AudioClip forest1;
    AudioClip forest2;
    AudioClip river1;
    AudioClip dungeon1;


    void Awake()
    {
        tavernRoom = Resources.Load<AudioClip>("TavernRoom");
        villageDay = Resources.Load<AudioClip>("VillageDay");
        villageNight = Resources.Load<AudioClip>("VillageNight");
        forest1 = Resources.Load<AudioClip>("Forest1");
        forest2 = Resources.Load<AudioClip>("Forest2");
        river1 = Resources.Load<AudioClip>("River1");
        dungeon1 = Resources.Load<AudioClip>("Dungeon1");

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

        // Tavern room
        if (CurrentScene.currentScene.scene == "T1")
        {
            this.gameObject.GetComponent<AudioSource>().clip = tavernRoom;
        }

        // Village daytime
        if (CurrentScene.currentScene.scene == "VD1" || CurrentScene.currentScene.scene == "TD6") 
        { 
            this.gameObject.GetComponent<AudioSource>().clip = villageDay;
        }

        // Village nighttime
        if (CurrentScene.currentScene.scene == "VN1" || CurrentScene.currentScene.scene == "TN6")
        {
            this.gameObject.GetComponent<AudioSource>().clip = villageNight;
        }

        // River
        if (CurrentScene.currentScene.scene == "R1")
        {
            this.gameObject.GetComponent<AudioSource>().clip = river1;
        }

        // Forest
        if (CurrentScene.currentScene.scene == "F1")
        {
            this.gameObject.GetComponent<AudioSource>().clip = forest2;
        }

        // Dungeon
        if (CurrentScene.currentScene.scene == "D1")
        {
            this.gameObject.GetComponent<AudioSource>().clip = dungeon1;
        }



        // Play music
        if (this.gameObject.GetComponent<AudioSource>().isPlaying == false)
        {
            this.gameObject.GetComponent<AudioSource>().Play();
        }
    }
    
}
