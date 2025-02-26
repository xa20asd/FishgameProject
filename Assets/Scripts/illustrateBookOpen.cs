using UnityEngine;
using UnityEngine.UI;

public class illustrateBookOpen : MonoBehaviour
{
    [SerializeField,Header("按鈕文字")]
    public Text theButtonText;
    public Text[] elseButtonText;

    [SerializeField, Header("各地區魚類圖鑑")]
    public GameObject theFishData;
    public GameObject[] elseFishData;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenFishData()
    {
        theButtonText.fontStyle = FontStyle.Bold;
        for (int i = 0; i < elseFishData.Length; i++)
        {
            elseButtonText[i].fontStyle = FontStyle.Normal;
        }

        theFishData.SetActive(true); 
        for (int k = 0; k < elseFishData.Length; k++)
        { 
            elseFishData[k].SetActive(false);
        }
    }

}
