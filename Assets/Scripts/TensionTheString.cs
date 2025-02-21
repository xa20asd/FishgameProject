using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TensionTheString : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public float continueTime, showLooseTime, showTensionTime, setFishEscapeTime, fishReadyEscapeTime;
    bool isTension, isturnbackTension, isFishReadyEscape;
    public Text theFishStatus;
    public GameObject theFish;
    //public Text theDistance;
    
    [SerializeField, Header("設定鬆緊隨機時間")]
    public float earlyTime;
    public float laterTime;

    [SerializeField, Header("釣竿動作")]
    public GameObject throwString;
    public GameObject withdrawButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        showLooseTime = Random.Range(earlyTime, laterTime);
        showTensionTime = Random.Range(earlyTime, laterTime);
        setFishEscapeTime = Random.Range(earlyTime, laterTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (isTension)
        {
            continueTime += Time.deltaTime;
            if (continueTime >= showLooseTime)
            {
                theFishStatus.text = "-- 鬆 --";
                continueTime = 0; 
                withdrawButton.SetActive(true);
                Debug.Log("-- 鬆 --");
            }
        }
        if (isturnbackTension) 
        { 
            continueTime += Time.deltaTime;
            if (continueTime >= showTensionTime)
            {
                theFishStatus.text = "-- 緊 --";
                Debug.Log("-- 緊 --");
                fishReadyEscapeTime += Time.deltaTime;
                if (fishReadyEscapeTime >= setFishEscapeTime)
                {
                    theFish.SetActive(false);
                    throwString.SetActive(true);
                    this.gameObject.SetActive(false);
                    //theDistance.text = "";
                    theFishStatus.text = "逃跑了...";
                    Debug.Log("逃跑了...");
                    continueTime = 0;
                    fishReadyEscapeTime = 0;
                    isturnbackTension = false;
                }
            }
            
        }
    }

    public void TensionButton()
    { 
        
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        isTension = true;
        isturnbackTension = false ;
        theFishStatus.text = "-- 緊 --";
    }
    public void OnPointerUp(PointerEventData EventData)
    {
        isturnbackTension = true;
        isTension = false;
        if (continueTime <= showTensionTime)
        {
            theFish.SetActive(false);
            throwString.SetActive(true);
            this.gameObject.SetActive(false);
            //theDistance.text = "";
            theFishStatus.text = "逃跑了...";
            Debug.Log("逃跑了...");
            isturnbackTension = false;
        }
    }
}
