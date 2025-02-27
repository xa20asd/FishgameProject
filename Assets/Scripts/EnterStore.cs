using System.Collections.Generic;
//using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnterStore : MonoBehaviour
{
    //List<string> equipmentNameList = new List<string>();

    //[SerializeField, Header("已顯示擁有的裝備")]
    //public Text[] equipmentName;

    [SerializeField, Header("擁有金錢")]
    public Text money;
     
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextScene(string nextscenename)
    {
        PlayerPrefs.SetInt("RealMoney", int.Parse(money.text));
        #region 使用json方法接收資料轉換場景
        //for (int i = 0; i < equipmentName.Length; i++)
        //{
        //    if (equipmentName[i].text != "?")
        //    { 
        //        string buyEquipmentName = equipmentName[i].text;
        //        equipmentNameList.Add(buyEquipmentName);
        //        string jsonlist = JsonConvert.SerializeObject(equipmentNameList);
        //        PlayerPrefs.SetString("buyEquipmentName", jsonlist);
        //        PlayerPrefs.SetString("buytag", "buy");
        //    }
        //} 
        #endregion
        SceneManager.LoadScene(nextscenename);
    }
}
