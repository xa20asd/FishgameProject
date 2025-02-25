using UnityEngine;

public class OpenEquipmentSelect : MonoBehaviour
{
    public GameObject thisEquipmentSelecWindow;
    bool isOpen = false;

    [SerializeField, Header("其他裝備視窗")]
    public GameObject[] elseEqupimentWindow = new GameObject[2];

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ControlThisWindow()
    {
        if (thisEquipmentSelecWindow.gameObject.activeSelf == false)
        {
            isOpen = false;
        }

        isOpen = !isOpen;
        thisEquipmentSelecWindow.gameObject.SetActive(isOpen);

        for (int i = 0; i < elseEqupimentWindow.Length; i++)
        { 
            elseEqupimentWindow[i].SetActive(false);
        }
    }
}
