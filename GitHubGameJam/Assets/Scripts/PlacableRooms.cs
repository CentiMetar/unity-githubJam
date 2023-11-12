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
}
