using System.Collections.Generic;
//using Newtonsoft.Json;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

public class WantBuyEquipment : MonoBehaviour
{
    [SerializeField, Header("裝備資訊")]
    public string equipmentName;
    public int sellprice;

    [SerializeField, Header("選擇項目按鈕")]
    public Button[] buyEquipmentButton;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        #region 使用Json儲存接收資料方法一
        //string jsonstring = PlayerPrefs.GetString("buyEquipmentName", "[]");
        //List<string> getjsonstring = JsonConvert.DeserializeObject<List<string>>(jsonstring);
        //foreach (string theFishEquipmentName in getjsonstring)
        //{
        //    if (theFishEquipmentName == equipmentName)
        //    {
        //        this.gameObject.tag = PlayerPrefs.GetString("buytag", "");
        //        float colorRed = PlayerPrefs.GetFloat("buyColorR", 255);
        //        float colorGreen = PlayerPrefs.GetFloat("buyColorG", 255);
        //        float colorBlue = PlayerPrefs.GetFloat("buyColorB", 255);
        //        this.GetComponent<Image>().color = new Color(colorRed, colorGreen, colorBlue);
        //    }
        //} 
        #endregion

        
        //int count = PlayerPrefs.GetInt("equipmentListCount", 0);
        //for (int i = 0; i < count; i++)
        //{
        //    if (PlayerPrefs.GetString("buyList" + i) == equipmentName)
        //    {
        //        this.gameObject.tag = PlayerPrefs.GetString("buytag", "");
        //        float colorRed = PlayerPrefs.GetFloat("buyColorR", 255);
        //        float colorGreen = PlayerPrefs.GetFloat("buyColorG", 255);
        //        float colorBlue = PlayerPrefs.GetFloat("buyColorB", 255);
        //        this.GetComponent<Image>().color = new Color(colorRed, colorGreen, colorBlue);
        //    }
        //}

        if (PlayerPrefs.GetString("已購買" + equipmentName) == equipmentName)
        {
            this.gameObject.tag = PlayerPrefs.GetString("buytag", "");
            float colorRed = PlayerPrefs.GetFloat("buyColorR", 255);
            float colorGreen = PlayerPrefs.GetFloat("buyColorG", 255);
            float colorBlue = PlayerPrefs.GetFloat("buyColorB", 255);
            this.GetComponent<Image>().color = new Color(colorRed, colorGreen, colorBlue);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if (equipmentName == "buy")
        //{
        //    float colorRed = PlayerPrefs.GetFloat("buyColorR", 255);
        //    float colorGreen = PlayerPrefs.GetFloat("buyColorG", 255);
        //    float colorBlue = PlayerPrefs.GetFloat("buyColorB", 255);

        //    this.GetComponent<Image>().color = new Color(190.0f / 255.0f, 255.0f / 255.0f, 230.0f / 255.0f);
        //}
    }

    /// <summary>
    /// 選擇欲購買裝備時按鈕的變化
    /// </summary>
    public void selectBuyEquipment()
    {
        if (this.GetComponent<Image>().color != new Color(130.0f / 255.0f, 130.0f / 255.0f, 130.0f / 255.0f))
        {
            if (this.GetComponent<Image>().color != new Color(190.0f / 255.0f, 255.0f / 255.0f, 230.0f / 255.0f))
            {
                this.GetComponent<Image>().color = new Color(130.0f / 255.0f, 130.0f / 255.0f, 130.0f / 255.0f);
                for (int i = 0; i < buyEquipmentButton.Length; i++)
                {
                    if (buyEquipmentButton[i].gameObject.tag != "buy")
                    {
                        buyEquipmentButton[i].GetComponent<Image>().color = new Color(224.0f / 255.0f, 224.0f / 255.0f, 224.0f / 255.0f);
                    }
                }
            }
            else
            {
                for (int i = 0; i < buyEquipmentButton.Length; i++)
                {
                    if (buyEquipmentButton[i].gameObject.tag != "buy")
                    {
                        buyEquipmentButton[i].GetComponent<Image>().color = new Color(224.0f / 255.0f, 224.0f / 255.0f, 224.0f / 255.0f);
                    }
                }
            }
        }
    }
}
