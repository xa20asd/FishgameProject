using UnityEngine;
using UnityEngine.UI;

public class FishingEquipmentSelect : MonoBehaviour
{
    [SerializeField, Header("裝備選擇")]
    //public GameObject equipment;
    public Text equipmentName;

    [SerializeField, Header("其他按鈕")]
    //public int equipmentCount;
    public Button[] equipments;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void selectTheEquipment(string equipmentname)
    {
        if (this.transform.GetChild(0).GetComponent<Text>().text != "?")
        { 
            equipmentName.text = equipmentname;
            this.GetComponent<Image>().color = Color.white;
            for (int i = 0; i < equipments.Length; i++)
            {
                equipments[i].GetComponent<Image>().color = new Color(170.0f / 255.0f, 170.0f / 255.0f, 170.0f / 255.0f);
            }
        }
    }
}
