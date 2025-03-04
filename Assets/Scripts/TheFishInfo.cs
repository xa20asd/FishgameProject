﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TheFishInfo : MonoBehaviour
{
    [SerializeField, Header("設定魚上鉤隨機時間")]
    public float earlyShow;
    public float laterShow;
    public float theShowTime;
    public float waitingTime;

    bool isFishComing;

    [SerializeField, Header("釣竿動作")]
    public GameObject tensionButton;

    [SerializeField, Header("釣魚裝備")]
    [Header("魚鉤")]
    public Text hook;

    [SerializeField, Header("釣魚參數調整")]
    [Header("魚鉤")]
    public float goodHookAdjustTheShowTime;
    public float proHookAdjustTheShowTime;
    float firstgoodHookAdjustTheShowTime;
    float firstproHookAdjustTheShowTime;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        #region 使用StartCoroutine，延遲顯示
        //theShowTime = Random.Range(earlyShow, laterShow);
        //isFishComing = true;
        //StartCoroutine(ShowTheFishStatus()); 
        #endregion

        firstgoodHookAdjustTheShowTime = goodHookAdjustTheShowTime;
        firstproHookAdjustTheShowTime = proHookAdjustTheShowTime;
    }

    #region 使用IEnumerator，延遲顯示
    //IEnumerator ShowTheFishStatus()
    //{ 
    //    yield return new WaitForSeconds(theShowTime);
    //    tensionButton.SetActive(true);
    //    this.GetComponent<Text>().text = "魚上鉤 !!!";
    //    Debug.Log("魚上鉤 !!!");
    //} 
    #endregion

    // Update is called once per frame
    void Update()
    {
        if (isFishComing)
        {
            waitingTime += Time.deltaTime;
            if (waitingTime >= theShowTime)
            {
                waitingTime = 0;
                tensionButton.SetActive(true);
                this.GetComponent<Text>().text = "魚上鉤 !!!";
                Debug.Log("魚上鉤 !!!");
                isFishComing = false;
            }
        }
        
    }

    /// <summary>
    /// 重新計時魚上鉤時間
    /// </summary>
    public void reStartFishComingTime()
    {
        isFishComing = true;
        if (hook.text != "普通魚鉤")
        {
            AdjustTheShowTime(hook.text);
            earlyShow = earlyShow - goodHookAdjustTheShowTime - proHookAdjustTheShowTime;
            laterShow = laterShow - goodHookAdjustTheShowTime - proHookAdjustTheShowTime;
        }
        theShowTime = Random.Range(earlyShow, laterShow);
    }

    /// <summary>
    /// 因不同魚鉤影響魚上鉤時間
    /// </summary>
    /// <param name="equipmentname"></param>
    void AdjustTheShowTime(string equipmentname)
    {
        if (equipmentname != "好魚鉤")
        {
            goodHookAdjustTheShowTime = 0;
        }
        else 
        {
            goodHookAdjustTheShowTime = firstgoodHookAdjustTheShowTime;
        }
        if (equipmentname != "高級魚鉤")
        {
            proHookAdjustTheShowTime = 0;
        }
        else
        {
            proHookAdjustTheShowTime = firstproHookAdjustTheShowTime;
        }
    }
}
