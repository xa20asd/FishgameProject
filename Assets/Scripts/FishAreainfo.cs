using UnityEngine;
using UnityEngine.UI;

public class FishAreainfo : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        string fishareainfo = PlayerPrefs.GetString("fisharea", "");
        GetComponent<Text>().text = fishareainfo;
        Debug.Log(fishareainfo);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
