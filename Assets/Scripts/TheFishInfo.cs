using System.Collections;
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


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //theShowTime = Random.Range(earlyShow, laterShow);
        //isFishComing = true;
        //StartCoroutine(ShowTheFishStatus());
    }

    //IEnumerator ShowTheFishStatus()
    //{ 
    //    yield return new WaitForSeconds(theShowTime);
    //    tensionButton.SetActive(true);
    //    this.GetComponent<Text>().text = "魚上鉤 !!!";
    //    Debug.Log("魚上鉤 !!!");
    //}

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
    public void reStartFishComingTime()
    {
        isFishComing = true;
        theShowTime = Random.Range(earlyShow, laterShow);
    }
}
