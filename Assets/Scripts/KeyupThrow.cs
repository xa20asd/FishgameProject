using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class KeyupThrow : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool isButtonPressed;
    public float throwTime = 0.0f;
    public Text throwDistance;

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
            string throwdistance = throwTime.ToString("F1");
            throwDistance.text = throwdistance;
        }
    }

    public void Throwclick(GameObject throwbutton)
    {
        //throwbutton.interactable = false;
        //throwbutton.onClick.RemoveAllListeners();
        throwbutton.SetActive(false);
        Debug.Log("已甩出釣線");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isButtonPressed = true;
        Debug.Log("已甩出釣線");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isButtonPressed = false;
        Debug.Log("已經落水");
    }
}
