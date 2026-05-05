using UnityEngine;

public class Music : MonoBehaviour
{

    public static Music instance;

    // All music clips
    AudioClip tavernRoom;
    AudioClip tavernDay;
    AudioClip tavernNight;
    AudioClip villageDay;
    AudioClip villageNight;
    AudioClip forest1;
    AudioClip forest2;
    AudioClip river1;
    AudioClip dungeon1;
    AudioClip end;
    AudioClip victory;


    void Awake()
    {
        tavernRoom = Resources.Load<AudioClip>("TavernRoom");
        tavernDay = Resources.Load<AudioClip>("TavernDay");
        tavernNight = Resources.Load<AudioClip>("TavernNight");
        villageDay = Resources.Load<AudioClip>("VillageDay");
        villageNight = Resources.Load<AudioClip>("VillageNight");
        forest1 = Resources.Load<AudioClip>("Forest1");
        forest2 = Resources.Load<AudioClip>("Forest2");
        river1 = Resources.Load<AudioClip>("River1");
        dungeon1 = Resources.Load<AudioClip>("Dungeon1");
        end = Resources.Load<AudioClip>("End");
        victory = Resources.Load<AudioClip>("Victory1");

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

        // Tavern day
        if (CurrentScene.currentScene.scene == "TD1")
        {
            this.gameObject.GetComponent<AudioSource>().clip = tavernDay;
        }

        // Tavern night
        if (CurrentScene.currentScene.scene == "TN1")
        {
            this.gameObject.GetComponent<AudioSource>().clip = tavernNight;
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

        // End
        if (CurrentScene.currentScene.scene == "END1" || CurrentScene.currentScene.scene == "END2" || CurrentScene.currentScene.scene == "END3" || CurrentScene.currentScene.scene == "END4" ||
            CurrentScene.currentScene.scene == "END5" || CurrentScene.currentScene.scene == "END6" || CurrentScene.currentScene.scene == "END7" || CurrentScene.currentScene.scene == "END8" ||
            CurrentScene.currentScene.scene == "END9" || CurrentScene.currentScene.scene == "END10")
        {
            this.gameObject.GetComponent<AudioSource>().clip = end;
        }

        // Victory
        if (CurrentScene.currentScene.scene == "O1")
        {
            this.gameObject.GetComponent<AudioSource>().clip = victory;
        }



        // Play music
        if (this.gameObject.GetComponent<AudioSource>().isPlaying == false)
        {
            this.gameObject.GetComponent<AudioSource>().Play();
        }
    }
    
}
