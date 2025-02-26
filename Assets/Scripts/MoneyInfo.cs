using UnityEngine;
using UnityEngine.UI;

public class MoneyInfo : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.GetComponent<Text>().text = PlayerPrefs.GetInt("RealMoney", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
