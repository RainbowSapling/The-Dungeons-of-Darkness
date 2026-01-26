using UnityEngine;

public class GameController : MonoBehaviour
{
    [HideInInspector] public RoomNavigation roomNavigation;
    public AudioSource audioSource = new AudioSource();

    void Awake()
    {
        roomNavigation = GetComponent<RoomNavigation>(); 
    }

    void Start()
    {
        PlayRoomAudio();
    }

    public void PlayRoomAudio()
    {
        AudioClip clip = roomNavigation.currentRoom.clip;
        audioSource.clip = clip;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
