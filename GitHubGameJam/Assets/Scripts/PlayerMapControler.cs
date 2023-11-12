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
    void Start()
    {
        getRooms(4);
    }
    // Update is called once per frame
    void Update()
    {
        if (!isScaled)
        {
            displaySelected.texture = avalibleRooms[selectedRoom].Look;
        }
        else
        {
            displaySelected.texture = avalibleRooms[selectedRoom].scaledVersion.Look;
        }
    }
    public void getRooms(int num)
    {
        for(int i = 0; i < num; i++)
        {
            avalibleRooms.Add(allRooms[Random.Range(0,7)]);

        }
    }
    public void scrollSelected(int i)
    {
        if (selectedRoom + i >= avalibleRooms.Count) {
            selectedRoom = 0;
        }else if(selectedRoom + i <0) {
            selectedRoom = avalibleRooms.Count;
        }
        else
        {
            selectedRoom += i;
        }
    }
    public void setScaled(bool isScaled)
    {
        this.isScaled = isScaled;
    }
}
