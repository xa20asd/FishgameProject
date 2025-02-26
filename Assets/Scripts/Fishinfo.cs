using UnityEngine;

public class Fishinfo : MonoBehaviour
{
    public GameObject unknown;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (PlayerPrefs.GetString(this.gameObject.name) == this.gameObject.name)
        {
            unknown.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
