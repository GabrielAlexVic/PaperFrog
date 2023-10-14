using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour
{
    //Objetos
    public Shop targetShop;
    public GameData data;
    public Button buyButton;

    //colocar [SerializeField] se quiser editar o valor do multiplier
    private float multiplier = 2f; // Multiplicador para aplicar ao shop, valor padrao = 2x
    [SerializeField]
    private int requiredAmount; // Quantidade necessária para desbloquear o upgrade
    [SerializeField]
    private int upgradePrize; // Quantidade necessária para desbloquear o upgrade
    private int isBought = 0; // 1 = True | 0 = False 

    public int IsBought { get => isBought; set => isBought = value; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ApplyUpgrade()
    {
        if (isBought == 0 && data.CurrentMoney >= upgradePrize && targetShop.Amount >= requiredAmount)
        {
            isBought = 1;
            data.CurrentMoney -= upgradePrize;
            targetShop.AcumulatedMPS *= multiplier;
            targetShop.MpsPerLevel *= multiplier;
            data.MoneyPerSecond += targetShop.AcumulatedMPS;
        }
    }

    // Verifique se o upgrade já foi comprado
    public void BoughtVerify()
    {
        if (isBought == 1)
        {
            buyButton.gameObject.SetActive(false); // Desative o botão se o upgrade foi comprado
        }
        else
        {
            // Verifique se as condições de compra são atendidas
            if (data.CurrentMoney >= upgradePrize && targetShop.Amount >= requiredAmount)
            {
                buyButton.gameObject.SetActive(true); // Ative o botão de compra se as condições forem atendidas
            }
            else
            {
                buyButton.gameObject.SetActive(false); // Desative o botão se as condições não forem atendidas
            }
        }
    }

    public void SaveUpgradeData()
    {
        PlayerPrefs.SetInt("Upgrade_" + gameObject.name + "_IsBought", isBought);
        
    }

    // Método para carregar os dados específicos da loja usando PlayerPrefs
    public void LoadUpgradeData()
    {
        isBought = PlayerPrefs.GetInt("Upgrade_" + gameObject.name + "_IsBought", isBought);
    }

}

