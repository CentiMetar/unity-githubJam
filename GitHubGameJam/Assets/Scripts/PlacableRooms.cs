using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class PlacableRooms : ScriptableObject
{
    public Texture2D Look;
    public GameObject prefab;
    public PlacableRooms scaledVersion;
    public Transform[] aroundRoomRaycastPositions = new Transform[10];
    public Transform[] roomsRaycastPositions = new Transform[8];
    public bool isPlaced=false;
    public bool isNextToRoom()
    {
        for(int i =0;i< aroundRoomRaycastPositions.Length;i++)
        {
            Vector3 rayPosition = aroundRoomRaycastPositions[i].position;
            rayPosition.z = Mathf.Infinity;

            RaycastHit2D hit = Physics2D.Raycast(rayPosition, rayPosition - Camera.main.ScreenToWorldPoint(rayPosition), Mathf.Infinity);
            if (hit.collider.CompareTag("PlacedRoom") || hit.collider.CompareTag("Start"))
            {
                return true;
            }

        }
        return false;
    }
    public bool isInMap()
    {

        for (int i = 0; i < roomsRaycastPositions.Length; i++)
        {
            Vector3 rayPosition = roomsRaycastPositions[i].position;
            rayPosition.z = Mathf.Infinity;

            RaycastHit2D hit = Physics2D.Raycast(rayPosition, rayPosition - Camera.main.ScreenToWorldPoint(rayPosition), Mathf.Infinity);
            if (!hit.collider.CompareTag("GridRoom"))
            {
                return false;
            }

        }
        return true;
    }
}
