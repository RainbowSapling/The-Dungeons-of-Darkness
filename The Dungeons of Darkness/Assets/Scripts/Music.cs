using UnityEngine;

public class Music : MonoBehaviour
{

    public static Music instance;

    // All music clips
    [SerializeField] AudioClip village1;
    [SerializeField] AudioClip village2;
    [SerializeField] AudioClip forrest1;
    [SerializeField] AudioClip forrest2;

    void Awake()
    {
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
        if(CurrentScene.currentScene.scene == "VD1" || CurrentScene.currentScene.scene == "TD6") 
        { 
            this.gameObject.GetComponent<AudioSource>().clip = village1;
            this.gameObject.GetComponent<AudioSource>().Play();
        }
    }
    
}
