using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clicker : MonoBehaviour
{
    //Objetos
    public GameData data;

    [SerializeField]
    private Text moneyText;
    private float hitPower;
    public float HitPower { get => hitPower; set => hitPower = value; }


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update e chamado uma vez por frame
    void Update()
    {
        moneyText.text = "$" + data.FormatMoney(data.CurrentMoney);
    }

    //Click
    public void hit()
    {
        data.SetCurrentMoney(hitPower);
    }
    public void SaveClickerData()
    {
        PlayerPrefs.SetFloat("HitPower", hitPower);
    }

    // Método para carregar o hitPower usando PlayerPrefs
    public void LoadClickerData()
    {
        hitPower = PlayerPrefs.GetFloat("HitPower", 1f);
    }
}
