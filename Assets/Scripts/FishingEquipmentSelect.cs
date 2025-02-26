﻿using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;
using UnityEngine.IO;
using System.IO;
using System.Collections.Generic;
//using Newtonsoft.Json;

public class FishingEquipmentSelect : MonoBehaviour
{
    public string buyEquipmentName;
    public Text textBuyEquipmentName;
    //private string filepath;

    [SerializeField, Header("裝備選擇")]
    public Text equipmentName;

    [SerializeField, Header("其他按鈕")]
    public Button[] equipments;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        #region 使用Json儲存接收資料方法一
        //string json = PlayerPrefs.GetString("equipmentList", "{}");
        //EquipmentList equipmentList = JsonUtility.FromJson<EquipmentList>(json);
        //filepath = Application.persistentDataPath + "/savedStrings.json";
        //if (File.Exists(filepath))
        //{
        //    string json = File.ReadAllText(filepath); 
        //    ListWrapper equipmentList = JsonConvert.DeserializeObject<ListWrapper>(json);

        //    if (equipmentList != null && equipmentList.buyEquipmentList != null)
        //    {
        //        foreach (string thebuyequipmentName in equipmentList.buyEquipmentList)
        //        {
        //            if (thebuyequipmentName == buyEquipmentName)
        //            {
        //                textBuyEquipmentName.text = thebuyequipmentName;
        //            }
        //        }
        //    }
        //} 
        #endregion

        #region 使用Json儲存接收資料方法二
        //string jsonstring = PlayerPrefs.GetString("SaveEquipmentList", "[]");
        //List<string> getjsonstring = JsonConvert.DeserializeObject<List<string>>(jsonstring);
        //ListWrapper equipmentList = JsonConvert.DeserializeObject<ListWrapper>(json);

        //foreach (string thebuyequipmentName in getjsonstring)
        //{
        //    if (thebuyequipmentName == buyEquipmentName)
        //    {
        //        textBuyEquipmentName.text = thebuyequipmentName;
        //    }
        //} 
        #endregion

        int count = PlayerPrefs.GetInt("equipmentListCount", 0);
        for (int i = 0; i < count; i++)
        {
            if (PlayerPrefs.GetString("buyList" + i) == buyEquipmentName)
            {
                textBuyEquipmentName.text = PlayerPrefs.GetString("buyList" + i);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// 選擇該裝備時按鈕的變化
    /// </summary>
    /// <param name="equipmentname"></param>
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
