using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacableRoom : MonoBehaviour
{
    public Transform[] roomPos = new Transform[8];
    public Transform[] roomsNext = new Transform[10];
    public bool overlapping = false;
    public bool isNextToRoom()
    {

        for (int i = 0; i < roomsNext.Length; i++)
        {
            Vector3 rayPosition = roomsNext[i].position;
            rayPosition.z = Mathf.Infinity;

            RaycastHit2D hit = Physics2D.Raycast(rayPosition, rayPosition - Camera.main.ScreenToWorldPoint(rayPosition), Mathf.Infinity, LayerMask.GetMask("PlacedRooms"));
            if (hit.collider != null)
            {
                if (hit.collider.CompareTag("PlacedRoom") || hit.collider.CompareTag("Start"))
                {
                    return true;
                }
            }
        }
        return false;
    }
    public bool isInMap()
    {
        int n = 0;
        for (int i = 0; i < roomPos.Length; i++)
        {
            Vector3 rayPosition = roomPos[i].position;
            rayPosition.z = Mathf.Infinity;

            RaycastHit2D hit = Physics2D.Raycast(rayPosition, rayPosition - Camera.main.ScreenToWorldPoint(rayPosition), Mathf.Infinity, LayerMask.GetMask("GridRooms"));
            if (hit.collider != null)
            {
                if (hit.collider.CompareTag("GridRoom"))
                {
                    n++;
                }
                if (n == roomPos.Length)
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
        return false;
    }
    void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("PlacedRoom"))
        {
            overlapping = true;
        }
    }
}
