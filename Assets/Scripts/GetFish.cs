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
    public GameObject theFishPirce;

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
        theFishPirce.SetActive(false);
        this.gameObject.SetActive(false);
        moneyCalculate += 8;
        string newMoney = moneyCalculate.ToString();
        money.text = newMoney;
        foreach (Button button in notFishCmdButton)
        {
            button.interactable = true;
        }
    }
}
