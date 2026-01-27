using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [HideInInspector] public RoomNavigation roomNavigation;

    // Plays audio
    public AudioSource audioSource;

    //Menu buttons for making choices in the game
    public Button button1;
    public Button button2;


    void Awake()
    {
        // Assign the room navigation script
        roomNavigation = GetComponent<RoomNavigation>();

        // Add event listeners to buttons
        button1.onClick.AddListener(ChooseOption1);
        button2.onClick.AddListener(ChooseOption2);
    }

    void Start()
    {
        // Plays the audio of the first room
        PlayRoomAudio();
    }

    // Plays the audio for the current room
    public void PlayRoomAudio()
    {
        AudioClip clip = roomNavigation.currentRoom.clip;
        audioSource.clip = clip;
        audioSource.Play();
    }

    public void ChooseOption1()
    {
        Debug.Log("option 1");
        Room nextRoom = roomNavigation.currentRoom.exits[0].room;
        roomNavigation.ChangeRoom(nextRoom);
    }

    public void ChooseOption2()
    {
        Debug.Log("option 2");
        Room nextRoom = roomNavigation.currentRoom.exits[1].room;
        roomNavigation.ChangeRoom(nextRoom);
    }


}
