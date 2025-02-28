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

    public float withdrawSpeed, withdrawdistance;
    float stringTensionTime;
    
    public bool isWithdrawing;

    [SerializeField, Header("釣魚裝備")]
    public Text pole;
    public Text poleString;
    public Text hook;
    public Text bait;

    [SerializeField, Header("釣竿動作")]
    public GameObject throwString;
    public GameObject tensionButton;
    public GameObject withdrawButton;

    [SerializeField, Header("釣魚成功")]
    public GameObject get;

    [SerializeField, Header("釣魚參數調整")]
    public int rangeMax;
    public int rangeMin;
    [Header("釣魚機率")]
    public int fishingP1;
    public int fishingP2;
    public int fishingP3;
    public int fishingP4;
    int fishNum1, fishNum2, fishNum3, fishPriceNum1, fishPriceNum2, fishPriceNum3;
    [Header("釣竿參數調整")]
    public int fishingProbability;
    public int goodPolefishingP1up;
    public int goodPolefishingP2up;
    public int goodPolefishingP3up;
    public int goodPolefishingP4up;
    public int goodPoleadjustrangMaxUp;
    public float goodPoleWithdrawSpeedUp;
    int firstgoodPolefishingP1up;
    int firstgoodPolefishingP2up;
    int firstgoodPolefishingP3up;
    int firstgoodPolefishingP4up;
    int firstgoodPoleadjustrangMaxUp;
    float firstgoodPoleWithdrawSpeedUp;

    public int proPolefishingP1up;
    public int proPolefishingP2up;
    public int proPolefishingP3up;
    public int proPolefishingP4up;
    public int proPoleadjustrangMaxUp;
    public float proPoleWithdrawSpeedUp;
    int firstproPolefishingP1up;
    int firstproPolefishingP2up;
    int firstproPolefishingP3up;
    int firstproPolefishingP4up;
    int firstproPoleadjustrangMaxUp;
    float firstproPoleWithdrawSpeedUp;
    [Header("釣線參數調整")]
    public float goodStringWithdrawSpeedUp;
    public float proStringWithdrawSpeedUp;
    float firstgoodStringWithdrawSpeedUp;
    float firstproStringWithdrawSpeedUp;
    [Header("魚鉤參數調整")]
    public int goodHookfishingP1up;
    public int goodHookfishingP2up;
    public int goodHookfishingP3up;
    public int goodHookfishingP4up;
    public int goodHookadjustrangMaxUp;
    int firstgoodHookfishingP1up;
    int firstgoodHookfishingP2up;
    int firstgoodHookfishingP3up;
    int firstgoodHookfishingP4up;
    int firstgoodHookadjustrangMaxUp;

    public int proHookfishingP1up;
    public int proHookfishingP2up;
    public int proHookfishingP3up;
    public int proHookfishingP4up;
    public int proHookadjustrangMaxUp;
    int firstproHookfishingP1up;
    int firstproHookfishingP2up;
    int firstproHookfishingP3up;
    int firstproHookfishingP4up;
    int firstproHookadjustrangMaxUp;

    [Header("魚餌參數調整")]
    public int bait2fishingP1up;
    public int bait2fishingP2up;
    public int bait2fishingP3up;
    public int bait2fishingP4up;
    public int bait2adjustrangMaxUp;
    int firstbait2fishingP1up;
    int firstbait2fishingP2up;
    int firstbait2fishingP3up;
    int firstbait2fishingP4up;
    int firstbait2adjustrangMaxUp;

    public int bait3fishingP1up;
    public int bait3fishingP2up;
    public int bait3fishingP3up;
    public int bait3fishingP4up;
    public int bait3adjustrangMaxUp;
    int firstbait3fishingP1up;
    int firstbait3fishingP2up;
    int firstbait3fishingP3up;
    int firstbait3fishingP4up;
    int firstbait3adjustrangMaxUp;

    public int bait4fishingP1up;
    public int bait4fishingP2up;
    public int bait4fishingP3up;
    public int bait4fishingP4up;
    public int bait4adjustrangMaxUp;
    int firstbait4fishingP1up;
    int firstbait4fishingP2up;
    int firstbait4fishingP3up;
    int firstbait4fishingP4up;
    int firstbait4adjustrangMaxUp;

    public int bait5fishingP1up;
    public int bait5fishingP2up;
    public int bait5fishingP3up;
    public int bait5fishingP4up;
    public int bait5adjustrangMaxUp;
    int firstbait5fishingP1up;
    int firstbait5fishingP2up;
    int firstbait5fishingP3up;
    int firstbait5fishingP4up;
    int firstbait5adjustrangMaxUp;



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
        //釣竿參數設定
        firstgoodPolefishingP1up = goodPolefishingP1up;
        firstgoodPolefishingP2up = goodPolefishingP2up;
        firstgoodPolefishingP3up = goodPolefishingP3up;
        firstgoodPolefishingP4up = goodPolefishingP4up;
        firstgoodPoleadjustrangMaxUp = goodPoleadjustrangMaxUp;
        firstgoodPoleWithdrawSpeedUp = goodPoleWithdrawSpeedUp;

        firstproPolefishingP1up = proPolefishingP1up;
        firstproPolefishingP2up = proPolefishingP2up;
        firstproPolefishingP3up = proPolefishingP3up;
        firstproPolefishingP4up = proPolefishingP4up;
        firstproPoleadjustrangMaxUp = proPoleadjustrangMaxUp;
        firstproPoleWithdrawSpeedUp = proPoleWithdrawSpeedUp;

        //釣線參數設定
        firstgoodStringWithdrawSpeedUp = goodStringWithdrawSpeedUp;
        firstproStringWithdrawSpeedUp = proStringWithdrawSpeedUp;

        //魚鉤參數設定
        firstgoodHookfishingP1up = goodHookfishingP1up;
        firstgoodHookfishingP1up = goodHookfishingP1up;
        firstgoodHookfishingP1up = goodHookfishingP1up;
        firstgoodHookfishingP1up = goodHookfishingP1up;
        firstgoodHookadjustrangMaxUp = goodHookadjustrangMaxUp;

        firstproHookfishingP1up = proHookfishingP1up;
        firstproHookfishingP2up = proHookfishingP2up;
        firstproHookfishingP3up = proHookfishingP3up;
        firstproHookfishingP4up = proHookfishingP4up;
        firstproHookadjustrangMaxUp = proHookadjustrangMaxUp;

        //魚餌參數設定
        firstbait2fishingP1up = bait2fishingP1up;
        firstbait2fishingP2up = bait2fishingP2up;
        firstbait2fishingP3up = bait2fishingP3up;
        firstbait2fishingP4up = bait2fishingP4up;
        firstbait2adjustrangMaxUp = bait2adjustrangMaxUp;

        firstbait3fishingP1up = bait3fishingP1up;
        firstbait3fishingP2up = bait3fishingP2up;
        firstbait3fishingP3up = bait3fishingP3up;
        firstbait3fishingP4up = bait3fishingP4up;
        firstbait3adjustrangMaxUp = bait3adjustrangMaxUp;

        firstbait4fishingP1up = bait4fishingP1up;
        firstbait4fishingP2up = bait4fishingP2up;
        firstbait4fishingP3up = bait4fishingP3up;
        firstbait4fishingP4up = bait4fishingP4up;
        firstbait4adjustrangMaxUp = bait4adjustrangMaxUp;

        firstbait5fishingP1up = bait5fishingP1up;
        firstbait5fishingP2up = bait5fishingP2up;
        firstbait5fishingP3up = bait5fishingP3up;
        firstbait5fishingP4up = bait5fishingP4up;
        firstbait5adjustrangMaxUp = bait5adjustrangMaxUp;
    }

    // Update is called once per frame
    void Update()
    {
        if (isWithdrawing) 
        {
            if (pole.text != "普通釣竿" || poleString.text != "普通釣線")
            {
                AdjustWithdrawSpeed(pole.text);
                AdjustWithdrawSpeed(poleString.text);
                withdrawdistance -= Time.deltaTime * (withdrawSpeed + goodPoleWithdrawSpeedUp + goodStringWithdrawSpeedUp + proPoleWithdrawSpeedUp + proStringWithdrawSpeedUp);
            }
            else
            {
                withdrawdistance -= Time.deltaTime * withdrawSpeed;
            }
            throwDistance.text = withdrawdistance.ToString("F1");
            if (withdrawdistance <= 0)
            {
                withdrawdistance = 0;
                isWithdrawing = false;
                theFishStatus.text = "成功釣到 !!!";
                theFishStatus.color = Color.black;
                theFishStatus.fontStyle = FontStyle.Bold;
                get.SetActive(true);
                throwString.SetActive(false);
                tensionButton.SetActive(false);
                withdrawButton.SetActive(false);
                if (pole.text != "普通釣竿" || poleString.text != "普通釣線" || bait.text != "魚餌1號")
                {
                    AdjustFishingProbabilityRangeMax(pole.text);
                    AdjustFishingProbabilityRangeMax(hook.text);
                    AdjustFishingProbabilityRangeMax(bait.text);
                    fishingProbability = Random.Range(rangeMin, (rangeMax + goodPoleadjustrangMaxUp + proPoleadjustrangMaxUp + goodHookadjustrangMaxUp + proHookadjustrangMaxUp + bait2adjustrangMaxUp + bait3adjustrangMaxUp + bait4adjustrangMaxUp + bait5adjustrangMaxUp));
                    AdjustFishingProbability(pole.text);
                    AdjustFishingProbability(hook.text);
                    AdjustFishingProbability(bait.text);
                    fishingP1 =
                        (
                            fishingP1 +
                            goodPolefishingP1up + proPolefishingP1up +
                            goodHookfishingP1up + proHookfishingP1up +
                            bait2fishingP1up + bait3fishingP1up + bait3fishingP1up + bait4fishingP1up + bait5fishingP1up
                        );
                    fishingP2 =
                        (
                            fishingP2 +
                            goodPolefishingP2up + proPolefishingP2up +
                            goodHookfishingP2up + proHookfishingP2up +
                            bait2fishingP2up + bait3fishingP2up + bait3fishingP2up + bait4fishingP2up + bait5fishingP2up
                        );
                    fishingP3 =
                        (
                            fishingP3 +
                            goodPolefishingP3up + proPolefishingP3up +
                            goodHookfishingP3up + proHookfishingP3up +
                            bait2fishingP3up + bait3fishingP3up + bait3fishingP3up + bait4fishingP3up + bait5fishingP3up
                        );
                    fishingP4 =
                        (
                            fishingP4 +
                            goodPolefishingP4up + proPolefishingP4up +
                            goodHookfishingP4up + proHookfishingP4up +
                            bait2fishingP4up + bait3fishingP4up + bait3fishingP4up + bait4fishingP4up + bait5fishingP4up
                        );
                }
                else
                {
                    fishingProbability = Random.Range(rangeMin, rangeMax);
                }
                if (PlayerPrefs.GetString("fisharea") == "溪邊 1 區")
                {
                    fishNum1 = 0;
                    fishNum2 = 0;
                    fishPriceNum1 = 0;
                    fishPriceNum2 = 0;
                    if (fishingProbability >= fishingP1 && float.Parse(throwDistance.text) >= 4.0f )
                    {
                        fishNum3 = 0;
                        fishPriceNum3 = 0;
                    }
                    else if (fishingProbability >= fishingP2 && fishingProbability < fishingP1 && float.Parse(throwDistance.text) >= 2.5f && float.Parse(throwDistance.text) <= 9.5f)
                    {
                        fishNum3 = 1;
                        fishPriceNum3 = 1;
                    }
                    else if (fishingProbability >= fishingP3 && fishingProbability < fishingP2 && float.Parse(throwDistance.text) >= 1.8f && float.Parse(throwDistance.text) <= 8.0f)
                    {
                        fishNum3 = 2;
                        fishPriceNum3 = 2;
                    }
                    else if (fishingProbability >= fishingP4 && fishingProbability < fishingP3 && float.Parse(throwDistance.text) >= 1.5f && float.Parse(throwDistance.text) <= 6.5f)
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
                    fishNum2 = 1;
                    fishPriceNum1 = 0;
                    fishPriceNum2 = 1;
                    if (fishingProbability >= fishingP1 && float.Parse(throwDistance.text) >= 4.0f)
                    {
                        fishNum3 = 0;
                        fishPriceNum3 = 0;
                    }
                    else if (fishingProbability >= fishingP2 && fishingProbability < fishingP1 && float.Parse(throwDistance.text) >= 2.5f && float.Parse(throwDistance.text) <= 9.5f)
                    {
                        fishNum3 = 1;
                        fishPriceNum3 = 1;
                    }
                    else if (fishingProbability >= fishingP3 && fishingProbability < fishingP2 && float.Parse(throwDistance.text) >= 1.8f && float.Parse(throwDistance.text) <= 8.0f)
                    {
                        fishNum3 = 2;
                        fishPriceNum3 = 2;
                    }
                    else if (fishingProbability >= fishingP4 && fishingProbability < fishingP3 && float.Parse(throwDistance.text) >= 1.5f && float.Parse(throwDistance.text) <= 6.5f)
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
                    fishNum2 = 2;
                    fishPriceNum1 = 0;
                    fishPriceNum2 = 2;
                    if (fishingProbability >= fishingP1 && float.Parse(throwDistance.text) >= 4.0f)
                    {
                        fishNum3 = 0;
                        fishPriceNum3 = 0;
                    }
                    else if (fishingProbability >= fishingP2 && fishingProbability < fishingP1 && float.Parse(throwDistance.text) >= 2.5f && float.Parse(throwDistance.text) <= 9.5f)
                    {
                        fishNum3 = 1;
                        fishPriceNum3 = 1;
                    }
                    else if (fishingProbability >= fishingP3 && fishingProbability < fishingP2 && float.Parse(throwDistance.text) >= 1.8f && float.Parse(throwDistance.text) <= 8.0f)
                    {
                        fishNum3 = 2;
                        fishPriceNum3 = 2;
                    }
                    else if (fishingProbability >= fishingP4 && fishingProbability < fishingP3 && float.Parse(throwDistance.text) >= 1.5f && float.Parse(throwDistance.text) <= 6.5f)
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
                    fishNum2 = 0;
                    fishPriceNum1 = 1;
                    fishPriceNum2 = 0;
                    if (fishingProbability >= fishingP1 && float.Parse(throwDistance.text) >= 4.0f)
                    {
                        fishNum3 = 0;
                        fishPriceNum3 = 0;
                    }
                    else if (fishingProbability >= fishingP2 && fishingProbability < fishingP1 && float.Parse(throwDistance.text) >= 2.5f && float.Parse(throwDistance.text) <= 9.5f)
                    {
                        fishNum3 = 1;
                        fishPriceNum3 = 1;
                    }
                    else if (fishingProbability >= fishingP3 && fishingProbability < fishingP2 && float.Parse(throwDistance.text) >= 1.8f && float.Parse(throwDistance.text) <= 8.0f)
                    {
                        fishNum3 = 2;
                        fishPriceNum3 = 2;
                    }
                    else if (fishingProbability >= fishingP4 && fishingProbability < fishingP3 && float.Parse(throwDistance.text) >= 1.5f && float.Parse(throwDistance.text) <= 6.5f)
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
                    if (fishingProbability >= fishingP1 && float.Parse(throwDistance.text) >= 4.0f)
                    {
                        fishNum3 = 0;
                        fishPriceNum3 = 0;
                    }
                    else if (fishingProbability >= fishingP2 && fishingProbability < fishingP1 && float.Parse(throwDistance.text) >= 2.5f && float.Parse(throwDistance.text) <= 9.5f)
                    {
                        fishNum3 = 1;
                        fishPriceNum3 = 1;
                    }
                    else if (fishingProbability >= fishingP3 && fishingProbability < fishingP2 && float.Parse(throwDistance.text) >= 1.8f && float.Parse(throwDistance.text) <= 8.0f)
                    {
                        fishNum3 = 2;
                        fishPriceNum3 = 2;
                    }
                    else if (fishingProbability >= fishingP4 && fishingProbability < fishingP3 && float.Parse(throwDistance.text) >= 1.5f && float.Parse(throwDistance.text) <= 6.5f)
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
                    fishNum2 = 2;
                    fishPriceNum1 = 1;
                    fishPriceNum2 = 2;
                    if (fishingProbability >= fishingP1 && float.Parse(throwDistance.text) >= 4.0f)
                    {
                        fishNum3 = 0;
                        fishPriceNum3 = 0;
                    }
                    else if (fishingProbability >= fishingP2 && fishingProbability < fishingP1 && float.Parse(throwDistance.text) >= 2.5f && float.Parse(throwDistance.text) <= 9.5f)
                    {
                        fishNum3 = 1;
                        fishPriceNum3 = 1;
                    }
                    else if (fishingProbability >= fishingP3 && fishingProbability < fishingP2 && float.Parse(throwDistance.text) >= 1.8f && float.Parse(throwDistance.text) <= 8.0f)
                    {
                        fishNum3 = 2;
                        fishPriceNum3 = 2;
                    }
                    else if (fishingProbability >= fishingP4 && fishingProbability < fishingP3 && float.Parse(throwDistance.text) >= 1.5f && float.Parse(throwDistance.text) <= 6.5f)
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
                    fishNum2 = 0;
                    fishPriceNum1 = 2;
                    fishPriceNum2 = 0;
                    if (fishingProbability >= fishingP1 && float.Parse(throwDistance.text) >= 4.0f)
                    {
                        fishNum3 = 0;
                        fishPriceNum3 = 0;
                    }
                    else if (fishingProbability >= fishingP2 && fishingProbability < fishingP1 && float.Parse(throwDistance.text) >= 2.5f && float.Parse(throwDistance.text) <= 9.5f)
                    {
                        fishNum3 = 1;
                        fishPriceNum3 = 1;
                    }
                    else if (fishingProbability >= fishingP3 && fishingProbability < fishingP2 && float.Parse(throwDistance.text) >= 1.8f && float.Parse(throwDistance.text) <= 8.0f)
                    {
                        fishNum3 = 2;
                        fishPriceNum3 = 2;
                    }
                    else if (fishingProbability >= fishingP4 && fishingProbability < fishingP3 && float.Parse(throwDistance.text) >= 1.5f && float.Parse(throwDistance.text) <= 6.5f)
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
                    fishNum2 = 1;
                    fishPriceNum1 = 2;
                    fishPriceNum2 = 1;
                    if (fishingProbability >= fishingP1 && float.Parse(throwDistance.text) >= 4.0f)
                    {
                        fishNum3 = 0;
                        fishPriceNum3 = 0;
                    }
                    else if (fishingProbability >= fishingP2 && fishingProbability < fishingP1 && float.Parse(throwDistance.text) >= 2.5f && float.Parse(throwDistance.text) <= 9.5f)
                    {
                        fishNum3 = 1;
                        fishPriceNum3 = 1;
                    }
                    else if (fishingProbability >= fishingP3 && fishingProbability < fishingP2 && float.Parse(throwDistance.text) >= 1.8f && float.Parse(throwDistance.text) <= 8.0f)
                    {
                        fishNum3 = 2;
                        fishPriceNum3 = 2;
                    }
                    else if (fishingProbability >= fishingP4 && fishingProbability < fishingP3 && float.Parse(throwDistance.text) >= 1.5f && float.Parse(throwDistance.text) <= 6.5f)
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
                    if (fishingProbability >= fishingP1 && float.Parse(throwDistance.text) >= 4.0f)
                    {
                        fishNum3 = 0;
                        fishPriceNum3 = 0;
                    }
                    else if (fishingProbability >= fishingP2 && fishingProbability < fishingP1 && float.Parse(throwDistance.text) >= 2.5f && float.Parse(throwDistance.text) <= 9.5f)
                    {
                        fishNum3 = 1;
                        fishPriceNum3 = 1;
                    }
                    else if (fishingProbability >= fishingP3 && fishingProbability < fishingP2 && float.Parse(throwDistance.text) >= 1.8f && float.Parse(throwDistance.text) <= 8.0f)
                    {
                        fishNum3 = 2;
                        fishPriceNum3 = 2;
                    }
                    else if (fishingProbability >= fishingP4 && fishingProbability < fishingP3 && float.Parse(throwDistance.text) >= 1.5f && float.Parse(throwDistance.text) <= 6.5f)
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

    void AdjustWithdrawSpeed(string equipmentname)
    {
        if (equipmentname != "好釣竿")
        {
            goodPoleWithdrawSpeedUp = 0;
        }
        else 
        {
            goodPoleWithdrawSpeedUp = firstgoodPoleWithdrawSpeedUp;
        }
        if (equipmentname != "高級釣竿")
        {
            proPoleWithdrawSpeedUp = 0;
        }
        else
        {
            proPoleWithdrawSpeedUp = firstproPoleWithdrawSpeedUp;
        }
        if (equipmentname != "好釣線")
        {
            goodStringWithdrawSpeedUp = 0;
        }
        else
        {
            goodStringWithdrawSpeedUp = firstgoodStringWithdrawSpeedUp;
        }
        if (equipmentname != "高級釣線")
        {
            proStringWithdrawSpeedUp = 0;
        }
        else
        {
            proStringWithdrawSpeedUp = firstproStringWithdrawSpeedUp;
        }
    }
    void AdjustFishingProbability(string equipmentname)
    {
        if (equipmentname != "好釣竿")
        {
            goodPolefishingP1up = 0;
            goodPolefishingP2up = 0;
            goodPolefishingP3up = 0;
            goodPolefishingP4up = 0;
        }
        else
        {
            goodPolefishingP1up = firstgoodPolefishingP1up;
            goodPolefishingP2up = firstgoodPolefishingP2up;
            goodPolefishingP3up = firstgoodPolefishingP3up;
            goodPolefishingP4up = firstgoodPolefishingP4up;
        }
        if (equipmentname != "高級釣竿")
        {
            proPolefishingP1up = 0;
            proPolefishingP2up = 0;
            proPolefishingP3up = 0;
            proPolefishingP4up = 0;
        }
        else
        {
            proPolefishingP1up = firstproPolefishingP1up;
            proPolefishingP2up = firstproPolefishingP2up;
            proPolefishingP3up = firstproPolefishingP3up;
            proPolefishingP4up = firstproPolefishingP4up;
        }
        if (equipmentname != "好魚鉤")
        {
            goodHookfishingP1up = 0;
            goodHookfishingP2up = 0;
            goodHookfishingP3up = 0;
            goodHookfishingP4up = 0;
        }
        else
        {
            goodHookfishingP1up = firstgoodHookfishingP1up;
            goodHookfishingP2up = firstgoodHookfishingP2up;
            goodHookfishingP3up = firstgoodHookfishingP3up;
            goodHookfishingP4up = firstgoodHookfishingP4up;
        }
        if (equipmentname != "高級魚鉤")
        {
            proHookfishingP1up = 0;
            proHookfishingP2up = 0;
            proHookfishingP3up = 0;
            proHookfishingP4up = 0;
        }
        else
        {
            proHookfishingP1up = firstproHookfishingP1up;
            proHookfishingP2up = firstproHookfishingP2up;
            proHookfishingP3up = firstproHookfishingP3up;
            proHookfishingP4up = firstproHookfishingP4up;
        }
        if (equipmentname != "魚餌2號")
        {
            bait2fishingP1up = 0;
            bait2fishingP2up = 0;
            bait2fishingP3up = 0;
            bait2fishingP4up = 0;
        }
        else
        {
            bait2fishingP1up = firstbait2fishingP1up;
            bait2fishingP2up = firstbait2fishingP2up;
            bait2fishingP3up = firstbait2fishingP3up;
            bait2fishingP4up = firstbait2fishingP4up;
        }
        if (equipmentname != "魚餌3號")
        {
            bait3fishingP1up = 0;
            bait3fishingP2up = 0;
            bait3fishingP3up = 0;
            bait3fishingP4up = 0;
        }
        else
        {
            bait3fishingP1up = firstbait3fishingP1up;
            bait3fishingP2up = firstbait3fishingP2up;
            bait3fishingP3up = firstbait3fishingP3up;
            bait3fishingP4up = firstbait3fishingP4up;
        }
        if (equipmentname != "魚餌4號")
        {
            bait4fishingP1up = 0;
            bait4fishingP2up = 0;
            bait4fishingP3up = 0;
            bait4fishingP4up = 0;
        }
        else
        {
            bait4fishingP1up = firstbait4fishingP1up;
            bait4fishingP2up = firstbait4fishingP2up;
            bait4fishingP3up = firstbait4fishingP3up;
            bait4fishingP4up = firstbait4fishingP4up;
        }
        if (equipmentname != "魚餌5號")
        {
            bait5fishingP1up = 0;
            bait5fishingP2up = 0;
            bait5fishingP3up = 0;
            bait5fishingP4up = 0;
        }
        else
        {
            bait5fishingP1up = firstbait5fishingP1up;
            bait5fishingP2up = firstbait5fishingP2up;
            bait5fishingP3up = firstbait5fishingP3up;
            bait5fishingP4up = firstbait5fishingP4up;
        }

    }
    void AdjustFishingProbabilityRangeMax(string equipmentname)
    {
        if (equipmentname != "好釣竿")
        {
            goodPoleadjustrangMaxUp = 0;
        }
        else
        {
            goodPoleadjustrangMaxUp = firstgoodPoleadjustrangMaxUp;
        }
        if (equipmentname != "高級釣竿")
        {
            proPoleadjustrangMaxUp = 0;
        }
        else
        {
            proPoleadjustrangMaxUp = firstproPoleadjustrangMaxUp;
        }
        if (equipmentname != "好魚鉤")
        {
            goodHookadjustrangMaxUp = 0;
        }
        else
        {
            goodHookadjustrangMaxUp = firstgoodHookadjustrangMaxUp;
        }
        if (equipmentname != "高級魚鉤")
        {
            proHookadjustrangMaxUp = 0;
        }
        else
        {
            proHookadjustrangMaxUp = firstproHookadjustrangMaxUp;
        }
        if (equipmentname != "魚餌2號")
        {
            bait2adjustrangMaxUp = 0;
        }
        else
        {
            bait2adjustrangMaxUp = firstbait2adjustrangMaxUp;
        }
        if (equipmentname != "魚餌3號")
        {
            bait3adjustrangMaxUp = 0;
        }
        else
        {
            bait3adjustrangMaxUp = firstbait3adjustrangMaxUp;
        }
        if (equipmentname != "魚餌4號")
        {
            bait4adjustrangMaxUp = 0;
        }
        else
        {
            bait4adjustrangMaxUp = firstbait4adjustrangMaxUp;
        }
        if (equipmentname != "魚餌5號")
        {
            bait5adjustrangMaxUp = 0;
        }
        else
        {
            bait5adjustrangMaxUp = firstbait5adjustrangMaxUp;
        }
    }



}
