using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public GridRoomInfo roomInfo;
    // Start is called before the first frame update
 
    public void SetRoom(GridRoomInfo room)
    {
        roomInfo = room;
        GetComponent<SpriteRenderer>().sprite = roomInfo.roomIcon;

    }
}
