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

    string[,,] fish =
        {
            {
                {"櫻花鉤吻鮭","台灣鯉","台灣鰻","美麗鮎","金線魚"},
                {"溪鰻","鯔魚","鰱魚","台灣錦鯉","黑鱸"},
                {"大頭鰻","橙帶鰻","尖吻鮎","美洲鯰","台灣黃鱸"}
            },
            {
                {"草魚","紅目鯛","斑點鯰","長吻鯛","斑馬魚"},
                {"青魚","吳郭魚","黑鯰","紅斑鯰","銀鯉"},
                {"鮒魚","台灣鯰","黃金鯉","銀鮭","烏鰱"}
            },
            {
                {"鯖魚","旗魚","鯛魚","石斑魚","赤鯛"},
                {"金目鯛","鱸魚","魯魚","大眼鯛","竹筴魚"},
                {"魷魚","海鱸","鰹魚","真鯉","多鰭魚"}
            }
        };
    int[,,] fishPrice =
        {
            {
                {40,25,18, },
                { },
                { }
            },
           
        };

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
                if (PlayerPrefs.GetString("fisharea") == "溪邊 1 區")
                { 
                    
                }
                theFish.text = "櫻花鉤吻鮭";
                theFishPrice.SetActive(true);
            }
            if (theFishStatus.text == "== 緊 ==")
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
