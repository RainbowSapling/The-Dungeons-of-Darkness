using UnityEngine;
using TMPro;

public class RoomNavigation : MonoBehaviour
{
    public Room currentRoom;

    public GameController controller;

    public TMP_Text displayRoomName;

    void Awake()
    {
        controller = GetComponent<GameController>();
    }

    public void ChangeRoom(Room newRoom)
    {
        currentRoom = newRoom;
        controller.PlayRoomAudio();
        displayRoomName.text = currentRoom.name;
    }

}
