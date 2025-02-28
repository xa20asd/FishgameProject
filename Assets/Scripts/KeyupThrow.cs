using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Unity.Collections;


public class KeyupThrow : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool isButtonPressed;
    float throwTime = 1.0f;
    public Text throwDistance;

    [SerializeField, Header ("魚類info")]
    public GameObject theFishStatus;
    public GameObject theFish;

    [SerializeField, Header("UI按鈕")]
    public Button[] notFishCmdButton;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isButtonPressed)
        {
            throwTime += Time.deltaTime;
            if (throwTime >= 10.0f)
            {
                throwTime = 10.0f;
                isButtonPressed = false;
            }
            string throwdistance = throwTime.ToString("F1");
            throwDistance.text = throwdistance;
        }
    }

    public void Throwclick(GameObject throwbutton)
    {
        theFishStatus.GetComponent<Text>().fontStyle = FontStyle.Normal;
        throwbutton.SetActive(false);
        TheFishInfo isReStarFishComeTime = FindAnyObjectByType<TheFishInfo>();
        isReStarFishComeTime.reStartFishComingTime();
        foreach (Button button in notFishCmdButton)
        {
            button.interactable = false;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isButtonPressed = true;
        theFishStatus.SetActive(false);
        theFish.SetActive(false);
        theFish.GetComponent<Text>().text = "";
        Debug.Log("已甩出釣線");
        throwTime = 1.0f;  
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isButtonPressed = false;
        Debug.Log("已經落水");
        theFishStatus.SetActive(true);
        theFishStatus.GetComponent<Text>().text = "等待中...";
        theFish.SetActive(true);
    }
}
