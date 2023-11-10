using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerMapControler : MonoBehaviour
{
    public RawImage displaySelected;
    public List<PlacableRooms> allRooms;
    public List<PlacableRooms> avalibleRooms= new List<PlacableRooms>();
    public int selectedRoom = 0;
    public bool isScaled;

    // Update is called once per frame
    void Update()
    {
        if (!isScaled)
        {
            displaySelected.texture = avalibleRooms[selectedRoom].Look.texture;
        }
        else
        {
            displaySelected.texture = avalibleRooms[selectedRoom].scaledVersion.Look.texture;
        }
    }
}
