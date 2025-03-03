using UnityEngine;

public class GamgManager : MonoBehaviour
{
    public bool isdeleteAllSaveData;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (isdeleteAllSaveData)
        { 
            PlayerPrefs.DeleteAll();
        }

        Screen.fullScreen = false;
        Screen.SetResolution(1600, 900, false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
