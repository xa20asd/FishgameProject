using UnityEngine;

public class CloseEquipmentSelect : MonoBehaviour
{
    public GameObject thisEquipmentSelecWindow;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CloseThisWindow()
    {
        thisEquipmentSelecWindow.gameObject.SetActive(false);
    }
}
