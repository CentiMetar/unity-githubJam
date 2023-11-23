using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MasterSceneScript : MonoBehaviour
{
    public static MasterSceneScript instance;

    public char[] roomAttributes = new char[5];
    public int sceneToLoad = 0;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public static MasterSceneScript giveScene()
    {
        return instance;
    }
    public void loadScene(int sceneToLoad, char[] roomAttributes)
    {
        this.sceneToLoad = sceneToLoad;
        this.roomAttributes = roomAttributes;
        
    }
}
