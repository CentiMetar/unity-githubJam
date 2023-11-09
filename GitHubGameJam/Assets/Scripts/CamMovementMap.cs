using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovementMap : MonoBehaviour
{
    public Transform player;
    public Transform tomb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3((player.position.x + tomb.position.x) / 2,Mathf.Clamp(player.position.y+1f,0.5f,tomb.position.y),-10);
    }
}
