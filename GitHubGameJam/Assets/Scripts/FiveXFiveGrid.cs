using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiveXFiveGrid : MonoBehaviour
{
   
    public GameObject[] rooms = new GameObject[25];
    public int shopNum;
    public int treasureNum;
    public int eliteNum;
    public int lvl;
    public Sprite[] roomIcons = new Sprite[4];

    
    void Start()
    {
        for(int i = 0; i < 25; i++)
        {
           
           GridRoomInfo pom = new GridRoomInfo();
           pom.Type = SetType(i);
           pom.Lvl = lvl;
           rooms[i].GetComponent<Room>().SetRoom(pom);
            
        } 
    }
    public Sprite SetSprite(char c)
    {
        switch (c)
        {
            case 'S':
                return roomIcons[0];
            case 'T':
                return roomIcons[1];
            case 'E':
                return roomIcons[2];
            case 'B':
                return roomIcons[3];
            default:
                return roomIcons[3];
        }
    }
    

    
    public char SetType(int i)
    {
        char c = ' ';
        int x = Random.Range(0, 10);
        switch (x)
        {
            case 0:
                if (shopNum != 0)
                {
                    c = 'S';
                    shopNum-=1;
                    break;
                } 
                goto case 1;
            case 1:
                if (treasureNum != 0)
                {
                    c = 'T';
                    treasureNum -= 1;
                    break;
                }
                goto case 2;
            case 2:
                if (eliteNum != 0)
                {
                    c = 'E';
                    eliteNum -= 1;
                    break;
                }
                goto case default;
            default:
                if(shopNum + eliteNum + treasureNum <= 25 - i)
                {
                    x = Random.Range(0, 10);
                    goto case 0;
                }
                c = 'B';
                break;
        }
        return c;
    }
}
