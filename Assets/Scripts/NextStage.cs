using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextStage : MonoBehaviour
{
    [SerializeField, Header("擁有金錢")]
    public Text Money;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextScene(string nextscenename) 
    {
        PlayerPrefs.SetInt("RealMoney", int.Parse(Money.text));
        SceneManager.LoadScene(nextscenename);
    }
}
