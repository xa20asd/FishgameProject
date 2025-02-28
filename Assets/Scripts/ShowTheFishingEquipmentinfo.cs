using UnityEngine;
using UnityEngine.UI;

public class ShowTheFishingEquipmentinfo : MonoBehaviour
{
    public string[] fishingEquipmentName;
    //string[] fishingEquipmentName =
    //    {
    //        "普通釣竿", "好釣竿", "高級釣竿",
    //        "普通釣線", "好釣線", "高級釣線",
    //        "普通魚鉤", "好魚鉤", "高級魚鉤",
    //        "魚餌1號", "魚餌2號", "魚餌3號","魚餌4號","魚餌5號"
    //    };


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < fishingEquipmentName.Length; i++) 
        {
            if (PlayerPrefs.HasKey(fishingEquipmentName[i]))
            {
                this.GetComponent<Text>().text = PlayerPrefs.GetString(fishingEquipmentName[i]);
            }
        }
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
