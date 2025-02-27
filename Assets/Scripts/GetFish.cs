using UnityEngine;
using UnityEngine.UI;

public class GetFish : MonoBehaviour
{
    [SerializeField, Header("釣竿動作")]
    public GameObject throwString;
    public GameObject tensionString;
    public GameObject withdrawString;

    [SerializeField, Header("魚類資訊")]
    public GameObject theFishStatus;
    public GameObject theFish;
    public GameObject theFishPrice;
    public GameObject realFishPrice;

    [SerializeField,Header("擁有金錢")]
    public Text money;
    int moneyCalculate;

    [SerializeField, Header("UI按鈕")]
    public Button[] notFishCmdButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moneyCalculate = int.Parse(money.text);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetClick()
    { 
        throwString.SetActive(true);
        tensionString.SetActive(false);
        withdrawString.SetActive(false);
        theFishStatus.SetActive(false);
        theFish.SetActive(false);
        PlayerPrefs.SetString(theFish.GetComponent<Text>().text, theFish.GetComponent<Text>().text);
        theFishPrice.SetActive(false);
        realFishPrice.SetActive(false);
        //PlayerPrefs.SetInt(theFish.GetComponent<Text>().text, int.Parse(realFishPrice.GetComponent<Text>().text));
        this.gameObject.SetActive(false);
        moneyCalculate += int.Parse(realFishPrice.GetComponent<Text>().text);
        money.text = moneyCalculate.ToString();
        PlayerPrefs.SetInt("RealMoney", int.Parse(money.text));
        foreach (Button button in notFishCmdButton)
        {
            button.interactable = true;
        }
    }
}
