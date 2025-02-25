using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WithdrawTheString : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField, Header("魚上鉤距離")]
    public Text throwDistance;
    [SerializeField, Header("魚的資訊")]
    public Text theFishStatus;
    public Text theFish;
    public GameObject theFishPrice;

    public float adjustWithdrawTime, withdrawdistance;
    float stringTensionTime;
    public bool isWithdrawing;

    [SerializeField, Header("釣竿動作")]
    public GameObject throwString;
    public GameObject tensionButton;
    public GameObject withdrawButton;

    [SerializeField, Header("釣魚成功")]
    public GameObject get;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isWithdrawing) 
        {
            withdrawdistance -= Time.deltaTime * adjustWithdrawTime;
            string newWithdrawDistance = withdrawdistance.ToString("F1");
            throwDistance.text = newWithdrawDistance;
            if(withdrawdistance <= 0)
            {
                withdrawdistance = 0;
                isWithdrawing = false;
                theFishStatus.text = "成功釣到 !!!";
                get.SetActive(true);
                throwString.SetActive(false);
                tensionButton.SetActive(false);
                withdrawButton.SetActive(false);
                theFish.text = "櫻花鉤吻鮭";
                theFishPrice.SetActive(true);
            }
            if (theFishStatus.text == "-- 緊 --")
            {
                stringTensionTime += Time.deltaTime;
                if (stringTensionTime >= 4.0f)
                {
                    theFishStatus.text = "逃跑了...";
                    isWithdrawing = false;
                    throwString.SetActive(true);
                    tensionButton.SetActive(false);
                    withdrawButton.SetActive(false);
                }
            }
        }
    }

    public void OnPointerDown(PointerEventData EventData)
    {
        isWithdrawing = true;
        withdrawdistance = float.Parse(throwDistance.text);
    }
    public void OnPointerUp(PointerEventData EventData)
    {
        isWithdrawing = false;
    }

}
