using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectFishArea : MonoBehaviour
{
    public int fishAreaNum1, fishAreaNum2;
    string[,] fishAreas = 
    {
        {"溪邊 1 區", "溪邊 2 區", "溪邊 3 區"},
        {"湖邊 1 區", "湖邊 2 區", "湖邊 3 區"},
        {"海邊 1 區", "海邊 2 區", "海邊 3 區"},
    };
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Updatetext()
    { 
        
    }


    public void SelectArea(string nextscenename)
    {
        PlayerPrefs.SetString("fisharea", fishAreas[fishAreaNum1, fishAreaNum2]);
        SceneManager.LoadScene(nextscenename);

    }
}
