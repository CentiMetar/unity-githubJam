using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawn : MonoBehaviour
{
    public GameObject[] enemies = new GameObject[5];
    public GameObject[] elite = new GameObject[2];
    void Start()
    {
       if(MasterSceneScript.instance != null && MasterSceneScript.giveScene().SpawnElite())
        {
            Instantiate(elite[Random.Range(0, elite.Length)],transform.position,Quaternion.identity);
            return;
        }
        Instantiate(enemies[Random.Range(0, enemies.Length)], transform.position, Quaternion.identity);
    }

}
