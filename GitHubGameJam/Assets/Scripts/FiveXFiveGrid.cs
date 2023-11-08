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

    
    public void Start()
    {
        for(int i = 0; i < 25; i++)
        {
           
            GridRoomInfo pom = new GridRoomInfo();
            pom.Type = SetType(i);
            pom.Lvl = lvl;
            pom.roomIcon = SetSprite(pom.Type);
            pom.sceneId = i;
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
        int x = Random.Range(0, 10);
        switch (x)
        {
            case 0:
                if (shopNum != 0)
                {
                    shopNum-=1;
                    return 'S';
                } 
                goto case 1;
            case 1:
                if (treasureNum != 0)
                {
                    
                    treasureNum -= 1;
                    return 'T';
                }
                goto case 2;
            case 2:
                if (eliteNum != 0)
                {
                    
                    eliteNum -= 1;
                    return 'E';
                }
                goto case default;
            default:
                if(shopNum + eliteNum + treasureNum >= 25 - i)
                {
                    if (shopNum > 0)
                    {
                        shopNum -= 1;
                        return 'S';
                    }else if (eliteNum > 0)
                    {
                        eliteNum -= 1;
                        return 'E';
                    }
                    else if(treasureNum>0)
                    {
                        treasureNum -= 1;
                        return 'T';
                    }
                    return 'B';
                }
                return 'B';
        }
    }
}
