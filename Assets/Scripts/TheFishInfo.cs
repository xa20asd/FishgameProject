using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TheFishInfo : MonoBehaviour
{
    //public Text theFishStatus;
    //public float waitingTimeStart, waitingTime;
    [SerializeField, Header("設定魚上鉤隨機時間")]
    public float earlyShow;
    public float laterShow;
    public float theShowTime;

    [SerializeField, Header("釣竿動作")]
    public GameObject tensionButton;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //waitingTimeStart = 0;
        //waitingTime = waitingTimeStart;
        theShowTime = Random.Range(earlyShow, laterShow);

        StartCoroutine(ShowTheFishStatus());
    }

    IEnumerator ShowTheFishStatus()
    { 
        yield return new WaitForSeconds(theShowTime);
        tensionButton.SetActive(true);
        this.GetComponent<Text>().text = "魚上鉤 !!!";
        Debug.Log("魚上鉤 !!!");
    }

    // Update is called once per frame
    void Update()
    {
        //waitingTime += Time.deltaTime;
        //if (waitingTime >= theShowTime)
        //{
        //    this.GetComponent<Text>().text = "魚上鉤 !!!";
        //    waitingTime = waitingTimeStart;
        //    Debug.Log("魚上鉤 !!!");
        //    //theFishStatus.text = "魚上鉤 !!!";
        //}
    }
}
