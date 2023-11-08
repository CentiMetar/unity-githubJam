using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public GridRoomInfo roomInfo;

    public SpriteRenderer iconRender;
    // Start is called before the first frame update
 
    public void SetRoom(GridRoomInfo room)
    {
        roomInfo = room;
        iconRender.sprite = roomInfo.roomIcon;

    }
}
