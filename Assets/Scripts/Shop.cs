using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public GameData data;

    [SerializeField]
    private Text shopText;

    [SerializeField]
    private float shopPrize;
    [SerializeField]
    private float amount;
    [SerializeField]
    private float mpsPerLevel; //mps = Money Per Second

    private float acumulatedMPS;

    //Condiçao de compra
    public int isAvailable; // 1 = True | 0 = False 

    //Troca cor do shop se isAvailable = 1
    public Button botao;
    public Color newColor;
    public Color currentColor;



    public float ShopPrize { get => shopPrize; set => shopPrize = value; }
    public float Amount { get => amount; set => amount = value; }
    public float MpsPerLevel { get => mpsPerLevel; set => mpsPerLevel = value; }
    public Text ShopText { get => shopText; set => shopText = value; }
    public float AcumulatedMPS { get => acumulatedMPS; set => acumulatedMPS = value; }

    // Start is called before the first frame update
    void Start()
    {
        if (isAvailable == 0)
        {
            botao.colors = GetColorBlockWithColor(newColor);
        }
    }

    // Update e chamado uma vez por frame
    void Update()
    {
        shopText.text = amount.ToString();
    }

    // Método auxiliar para criar um ColorBlock com a cor especificada
    private ColorBlock GetColorBlockWithColor(Color color)
    {
        ColorBlock cb = botao.colors;
        cb.normalColor = color;
        cb.selectedColor = color;
        return cb;
    }

    //Comprar os Shops
    public void ShopAction()
    {
        if (isAvailable >= 1 && data.CurrentMoney >= shopPrize)
        {
            data.CurrentMoney -= shopPrize;
            amount++;
            shopPrize *= 1.2f; //Cada vez que comprado aumenta o preço em 20%
            acumulatedMPS += mpsPerLevel; //Acumula o mps para somalo ao fazer upgrade
            data.MoneyPerSecond += mpsPerLevel;

            SetColor();


        }
    }

    // Metodo para verificar cor do Shop
    public void SetColor()
    {
        // Liberar a próxima loja se estiver disponível
        if (this == data.shop1 && data.shop1.amount >= 1)
        {
            data.shop2.isAvailable = 1;
            data.shop2.botao.colors = GetColorBlockWithColor(currentColor);
        }
        else if (this == data.shop2 && data.shop2.amount >= 1)
        {
            data.shop3.isAvailable = 1;
            data.shop3.botao.colors = GetColorBlockWithColor(currentColor);
        }
        else if (this == data.shop3 && data.shop3.amount >= 1)
        {
            data.shop4.isAvailable = 1;
            data.shop4.botao.colors = GetColorBlockWithColor(currentColor);
        }
        else if (this == data.shop4 && data.shop4.amount >= 1)
        {
            data.shop5.isAvailable = 1;
            data.shop5.botao.colors = GetColorBlockWithColor(currentColor);
        }
        else if (this == data.shop5 && data.shop4.amount >= 5)
        {
            data.shop6.isAvailable = 1;
            data.shop6.botao.colors = GetColorBlockWithColor(currentColor);
        }
        //Adicionar manualmente para as proximas shops
    }

    // Método para salvar os dados específicos da loja usando PlayerPrefs
    public void SaveShopData()
    {
        PlayerPrefs.SetFloat("Shop_" + gameObject.name + "_Amount", amount);
        PlayerPrefs.SetFloat("Shop_" + gameObject.name + "_Prize", shopPrize);
        PlayerPrefs.SetFloat("Shop_" + gameObject.name + "_MpsPerLevel", mpsPerLevel);
        PlayerPrefs.SetFloat("Shop_" + gameObject.name + "_AcumulatedMPS", acumulatedMPS);
        PlayerPrefs.SetInt("IsAvailable_" + gameObject.name + "_IsAvailable", isAvailable);
    }

    // Método para carregar os dados específicos da loja usando PlayerPrefs
    public void LoadShopData()
    {
        shopPrize = PlayerPrefs.GetFloat("Shop_" + gameObject.name + "_Prize", shopPrize);
        amount = PlayerPrefs.GetFloat("Shop_" + gameObject.name + "_Amount", amount);
        mpsPerLevel = PlayerPrefs.GetFloat("Shop_" + gameObject.name + "_MpsPerLevel", mpsPerLevel);
        acumulatedMPS = PlayerPrefs.GetFloat("Shop_" + gameObject.name + "_AcumulatedMPS", acumulatedMPS);
        isAvailable = PlayerPrefs.GetInt("IsAvailable_" + gameObject.name + "_IsAvailable", isAvailable);
    }
}
