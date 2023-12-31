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
    public bool isScaled=false;
    public Rigidbody2D rb2d;
    public GameObject clone;
    public bool isOutofbounds = false;
    
    void Start()
    {
        getRooms(4);
    }
    // Update is called once per frame
    void Update()
    {
        PlacableRooms room = null;
        if (avalibleRooms.Count > 0)
        {
            if (!isScaled)
            {
                displaySelected.texture = avalibleRooms[selectedRoom].Look;
                room = avalibleRooms[selectedRoom];
            }
            else
            {
                displaySelected.texture = avalibleRooms[selectedRoom].scaledVersion.Look;
                room = avalibleRooms[selectedRoom].scaledVersion;
            }
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null)
            {
                if (hit.collider.CompareTag("GridRoom") && !isOutofbounds)
                {
                    Destroy(clone);
                    clone = Instantiate(room.prefab, hit.transform.position + new Vector3(-0.5f, 0.5f, 0f), Quaternion.identity);
                    if (!clone.GetComponent<PlacableRoom>().isInMap())
                    {
                        Destroy(clone);
                        isOutofbounds = true;
                    }

                }
            }
            else
            {
                isOutofbounds = false;
                if (clone != null )
                {
                    Destroy(clone);
                }
            }
            if (clone != null)
            {
                if (clone.GetComponent<PlacableRoom>().overlapping)
                {
                    isOutofbounds = true;
                    Destroy(clone);
                }
            }
            if (Input.GetMouseButtonDown(0) && clone != null && clone.GetComponent<PlacableRoom>().isNextToRoom())
            {
                clone = null;
                avalibleRooms.RemoveAt(selectedRoom);
                if (selectedRoom > avalibleRooms.Count - 1) { selectedRoom = avalibleRooms.Count - 1; }
            }
        }
        else if (avalibleRooms.Count == 0)
        {
            room = null;
            displaySelected.texture = null;
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
