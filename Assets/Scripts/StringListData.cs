using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "StringListData", menuName = "ScriptabltObject/ StringListData", order = 1)]

public class StringListData : ScriptableObject
{
    public List<string> equipmentList = new List<string>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
