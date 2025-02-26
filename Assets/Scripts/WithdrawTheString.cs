using NUnit.Framework;
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
    public GameObject realFishPrice;

    public float adjustWithdrawTime, withdrawdistance;
    float stringTensionTime;
    public bool isWithdrawing;


    [SerializeField, Header("釣竿動作")]
    public GameObject throwString;
    public GameObject tensionButton;
    public GameObject withdrawButton;

    [SerializeField, Header("釣魚成功")]
    public GameObject get;

    [SerializeField, Header("釣魚參數調整")]
    public int rangeMax;
    public int rangeMin;
    public int fishingP1;
    public int fishingP2;
    public int fishingP3;
    public int fishingP4;
    int fishNum1, fishNum2, fishNum3, fishPriceNum1, fishPriceNum2, fishPriceNum3;



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
                {40,25,18,12,8},
                {36,26,20,15,10},
                {33,28,23,18,14}
            },
            {
                {39,27,17,11,7},
                {34,22,16,12,9},
                {30,20,14,10,6}
            },
            {
                {48,45,30,24,20},
                {39,29,19,11,8},
                {35,25,16,9,5}
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
                int fishingProbability = Random.Range(rangeMin, rangeMax);
                if (PlayerPrefs.GetString("fisharea") == "溪邊 1 區")
                {
                    fishNum1 = 0;
                    fishNum2 = 0;
                    fishPriceNum1 = 0;
                    fishPriceNum2 = 0;
                    if (fishingProbability >= fishingP1)
                    {
                        fishNum3 = 0;
                        fishPriceNum3 = 0;
                    }
                    else if (fishingProbability >= fishingP2 && fishingProbability < fishingP1)
                    {
                        fishNum3 = 1;
                        fishPriceNum3 = 1;
                    }
                    else if (fishingProbability >= fishingP3 && fishingProbability < fishingP2)
                    {
                        fishNum3 = 2;
                        fishPriceNum3 = 2;
                    }
                    else if (fishingProbability >= fishingP4 && fishingProbability < fishingP3)
                    {
                        fishNum3 = 3;
                        fishPriceNum3 = 3;
                    }
                    else 
                    {
                        fishNum3 = 4;
                        fishPriceNum3 = 4;
                    }
                }
                else if (PlayerPrefs.GetString("fisharea") == "溪邊 2 區")
                {
                    fishNum1 = 0;
                    fishNum2 = 0;
                    fishPriceNum1 = 1;
                    fishPriceNum2 = 1;
                    if (fishingProbability >= fishingP1)
                    {
                        fishNum3 = 0;
                        fishPriceNum3 = 0;
                    }
                    else if (fishingProbability >= fishingP2 && fishingProbability < fishingP1)
                    {
                        fishNum3 = 1;
                        fishPriceNum3 = 1;
                    }
                    else if (fishingProbability >= fishingP3 && fishingProbability < fishingP2)
                    {
                        fishNum3 = 2;
                        fishPriceNum3 = 2;
                    }
                    else if (fishingProbability >= fishingP4 && fishingProbability < fishingP3)
                    {
                        fishNum3 = 3;
                        fishPriceNum3 = 3;
                    }
                    else
                    {
                        fishNum3 = 4;
                        fishPriceNum3 = 4;
                    }
                }
                else if (PlayerPrefs.GetString("fisharea") == "溪邊 3 區")
                {
                    fishNum1 = 0;
                    fishNum2 = 0;
                    fishPriceNum1 = 2;
                    fishPriceNum2 = 2;
                    if (fishingProbability >= fishingP1)
                    {
                        fishNum3 = 0;
                        fishPriceNum3 = 0;
                    }
                    else if (fishingProbability >= fishingP2 && fishingProbability < fishingP1)
                    {
                        fishNum3 = 1;
                        fishPriceNum3 = 1;
                    }
                    else if (fishingProbability >= fishingP3 && fishingProbability < fishingP2)
                    {
                        fishNum3 = 2;
                        fishPriceNum3 = 2;
                    }
                    else if (fishingProbability >= fishingP4 && fishingProbability < fishingP3)
                    {
                        fishNum3 = 3;
                        fishPriceNum3 = 3;
                    }
                    else
                    {
                        fishNum3 = 4;
                        fishPriceNum3 = 4;
                    }
                }
                else if (PlayerPrefs.GetString("fisharea") == "湖邊 1 區")
                {
                    fishNum1 = 1;
                    fishNum2 = 1;
                    fishPriceNum1 = 0;
                    fishPriceNum2 = 0;
                    if (fishingProbability >= fishingP1)
                    {
                        fishNum3 = 0;
                        fishPriceNum3 = 0;
                    }
                    else if (fishingProbability >= fishingP2 && fishingProbability < fishingP1)
                    {
                        fishNum3 = 1;
                        fishPriceNum3 = 1;
                    }
                    else if (fishingProbability >= fishingP3 && fishingProbability < fishingP2)
                    {
                        fishNum3 = 2;
                        fishPriceNum3 = 2;
                    }
                    else if (fishingProbability >= fishingP4 && fishingProbability < fishingP3)
                    {
                        fishNum3 = 3;
                        fishPriceNum3 = 3;
                    }
                    else
                    {
                        fishNum3 = 4;
                        fishPriceNum3 = 4;
                    }
                }
                else if (PlayerPrefs.GetString("fisharea") == "湖邊 2 區")
                {
                    fishNum1 = 1;
                    fishNum2 = 1;
                    fishPriceNum1 = 1;
                    fishPriceNum2 = 1;
                    if (fishingProbability >= fishingP1)
                    {
                        fishNum3 = 0;
                        fishPriceNum3 = 0;
                    }
                    else if (fishingProbability >= fishingP2 && fishingProbability < fishingP1)
                    {
                        fishNum3 = 1;
                        fishPriceNum3 = 1;
                    }
                    else if (fishingProbability >= fishingP3 && fishingProbability < fishingP2)
                    {
                        fishNum3 = 2;
                        fishPriceNum3 = 2;
                    }
                    else if (fishingProbability >= fishingP4 && fishingProbability < fishingP3)
                    {
                        fishNum3 = 3;
                        fishPriceNum3 = 3;
                    }
                    else
                    {
                        fishNum3 = 4;
                        fishPriceNum3 = 4;
                    }
                }
                else if (PlayerPrefs.GetString("fisharea") == "湖邊 3 區")
                {
                    fishNum1 = 1;
                    fishNum2 = 1;
                    fishPriceNum1 = 2;
                    fishPriceNum2 = 2;
                    if (fishingProbability >= fishingP1)
                    {
                        fishNum3 = 0;
                        fishPriceNum3 = 0;
                    }
                    else if (fishingProbability >= fishingP2 && fishingProbability < fishingP1)
                    {
                        fishNum3 = 1;
                        fishPriceNum3 = 1;
                    }
                    else if (fishingProbability >= fishingP3 && fishingProbability < fishingP2)
                    {
                        fishNum3 = 2;
                        fishPriceNum3 = 2;
                    }
                    else if (fishingProbability >= fishingP4 && fishingProbability < fishingP3)
                    {
                        fishNum3 = 3;
                        fishPriceNum3 = 3;
                    }
                    else
                    {
                        fishNum3 = 4;
                        fishPriceNum3 = 4;
                    }
                }
                else if (PlayerPrefs.GetString("fisharea") == "海邊 1 區")
                {
                    fishNum1 = 2;
                    fishNum2 = 2;
                    fishPriceNum1 = 0;
                    fishPriceNum2 = 0;
                    if (fishingProbability >= fishingP1)
                    {
                        fishNum3 = 0;
                        fishPriceNum3 = 0;
                    }
                    else if (fishingProbability >= fishingP2 && fishingProbability < fishingP1)
                    {
                        fishNum3 = 1;
                        fishPriceNum3 = 1;
                    }
                    else if (fishingProbability >= fishingP3 && fishingProbability < fishingP2)
                    {
                        fishNum3 = 2;
                        fishPriceNum3 = 2;
                    }
                    else if (fishingProbability >= fishingP4 && fishingProbability < fishingP3)
                    {
                        fishNum3 = 3;
                        fishPriceNum3 = 3;
                    }
                    else
                    {
                        fishNum3 = 4;
                        fishPriceNum3 = 4;
                    }
                }
                else if (PlayerPrefs.GetString("fisharea") == "海邊 2 區")
                {
                    fishNum1 = 2;
                    fishNum2 = 2;
                    fishPriceNum1 = 1;
                    fishPriceNum2 = 1;
                    if (fishingProbability >= fishingP1)
                    {
                        fishNum3 = 0;
                        fishPriceNum3 = 0;
                    }
                    else if (fishingProbability >= fishingP2 && fishingProbability < fishingP1)
                    {
                        fishNum3 = 1;
                        fishPriceNum3 = 1;
                    }
                    else if (fishingProbability >= fishingP3 && fishingProbability < fishingP2)
                    {
                        fishNum3 = 2;
                        fishPriceNum3 = 2;
                    }
                    else if (fishingProbability >= fishingP4 && fishingProbability < fishingP3)
                    {
                        fishNum3 = 3;
                        fishPriceNum3 = 3;
                    }
                    else
                    {
                        fishNum3 = 4;
                        fishPriceNum3 = 4;
                    }
                }
                else if (PlayerPrefs.GetString("fisharea") == "海邊 3 區")
                {
                    fishNum1 = 2;
                    fishNum2 = 2;
                    fishPriceNum1 = 2;
                    fishPriceNum2 = 2;
                    if (fishingProbability >= fishingP1)
                    {
                        fishNum3 = 0;
                        fishPriceNum3 = 0;
                    }
                    else if (fishingProbability >= fishingP2 && fishingProbability < fishingP1)
                    {
                        fishNum3 = 1;
                        fishPriceNum3 = 1;
                    }
                    else if (fishingProbability >= fishingP3 && fishingProbability < fishingP2)
                    {
                        fishNum3 = 2;
                        fishPriceNum3 = 2;
                    }
                    else if (fishingProbability >= fishingP4 && fishingProbability < fishingP3)
                    {
                        fishNum3 = 3;
                        fishPriceNum3 = 3;
                    }
                    else
                    {
                        fishNum3 = 4;
                        fishPriceNum3 = 4;
                    }
                }

                theFish.text = fish[fishNum1, fishNum2, fishNum3];
                //PlayerPrefs.SetString(fish[fishNum1, fishNum2, fishNum3], fish[fishNum1, fishNum2, fishNum3]);
               
                theFishPrice.SetActive(true);
                realFishPrice.SetActive(true);
                realFishPrice.GetComponent<Text>().text = fishPrice[fishPriceNum1, fishPriceNum2, fishPriceNum3].ToString();
                //PlayerPrefs.SetInt(fish[fishNum1, fishNum2, fishNum3], fishPrice[fishPriceNum1, fishPriceNum2, fishPriceNum3]);
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
