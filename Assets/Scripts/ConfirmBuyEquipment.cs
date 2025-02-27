using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.IO;
//using Newtonsoft.Json;

//[CreateAssetMenu(fileName = "AddSaveList", menuName = "ScriptableObject/AddSaveList", order = 1)]
//public class AddSaveList : ScriptableObject
//{
//    public List<string> equipmentList = new List<string>();
//}

public class ConfirmBuyEquipment : MonoBehaviour
{
    //public AddSaveList addSaveList;
    List<string> equipmentList = new List<string>();
    public GameObject[] sellEquipments;

    [SerializeField, Header("購買文字提示")]
    public Text money;
    public Text moneyStatus;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //LoadBuyEquipmentList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void confirm()
    {
        int textMoney = int.Parse(money.text);
        
        for (int i = 0; i < sellEquipments.Length; i++)
        {
            if (sellEquipments[i].GetComponent<Image>().color == new Color(130.0f / 255.0f, 130.0f / 255.0f, 130.0f / 255.0f) && sellEquipments[i].gameObject.tag != "buy")
            {
                string thebuyequipment = sellEquipments[i].GetComponent<WantBuyEquipment>().equipmentName;
                int thesellprice = sellEquipments[i].GetComponent<WantBuyEquipment>().sellprice;
                if (textMoney >= thesellprice)
                { 
                    int newMoney = textMoney - thesellprice;
                    money.text = newMoney.ToString();
                    moneyStatus.gameObject.SetActive(true);
                    moneyStatus.text = "成功購買";
                    sellEquipments[i].gameObject.tag = "buy";
                    sellEquipments[i].GetComponent<Image>().color = new Color(190.0f / 255.0f, 255.0f / 255.0f, 230.0f / 255.0f);
                    equipmentList.Add(thebuyequipment);
                    Debug.Log("已購買裝備數量" + equipmentList.Count);
                    SaveBuyEquipmentList();
                    #region 使用json儲存資料的方法
                    //string jsonList = JsonUtility.ToJson(new EquipmentList(equipmentList));
                    //string jsonList = JsonConvert.SerializeObject(equipmentList);
                    //Debug.Log(jsonList);
                    //PlayerPrefs.SetString("SaveEquipmentList", jsonList);
                    //File.WriteAllText(filepath, jsonList); 
                    #endregion
                    Debug.Log("購買裝備: " + thebuyequipment + ",購買金額: " + thesellprice);
                }
                else
                {
                    moneyStatus.gameObject.SetActive(true);
                    moneyStatus.text = "金額不足";
                }
            }
        }
    }
    void SaveBuyEquipmentList()
    {
        for (int i = 0; i < equipmentList.Count; i++)
        {
            PlayerPrefs.SetString("buyList" + i, equipmentList[i]);
        }
        PlayerPrefs.SetInt("equipmentListCount", equipmentList.Count);
        PlayerPrefs.SetFloat("buyColorR", 190.0f / 255.0f);
        PlayerPrefs.SetFloat("buyColorG", 255.0f / 255.0f);
        PlayerPrefs.SetFloat("buyColorB", 230.0f / 255.0f);
        PlayerPrefs.Save();
    }
    void LoadBuyEquipmentList()
    {
        int count = PlayerPrefs.GetInt("equipmentListCount", 0);
        for (int i = 0; i < count; i++) 
        {
            equipmentList.Add(PlayerPrefs.GetString("buyList" + i));
        }
    }
}







