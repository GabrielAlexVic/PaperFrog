using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameData : MonoBehaviour
{
    //Lembrar de tirar o currentMoney
    [SerializeField]
    private float currentMoney;
    private float moneyPerSecond;
    public float CurrentMoney { get => currentMoney; set => currentMoney = value; }
    public float MoneyPerSecond { get => moneyPerSecond; set => moneyPerSecond = value; }

    // Objeto usados para criar condiçoes
    public Shop shop1;
    public Shop shop2;
    public Shop shop3;
    public Shop shop4;
    public Shop shop5;
    public Shop shop6;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update e chamado uma vez por frame
    void Update()
    {
        currentMoney += (moneyPerSecond * Time.deltaTime);
    }


    public void SetCurrentMoney(float value)
    {
        currentMoney += value;
    }

    // Função para formatar o valor do dinheiro
    public string FormatMoney(float value)
    {
        if (value < 1000000) // Se o valor for menor que 1 milhão, não adiciona sufixo
        {
            return value.ToString("F0"); // "F0" para formatar como número inteiro e sem casas decimais
        }

        string[] suffixes = { "", " mil", " milhão", " bilhão", " trilhão", " quadrilhão" }; // Adicione mais sufixos se necessário
        int suffixIndex = 0;

        while (value >= 1000 && suffixIndex < suffixes.Length - 1)
        {
            value /= 1000;
            suffixIndex++;
        }

        return value.ToString("F0") + suffixes[suffixIndex]; // Use "F0" para formatar como número inteiro e sem casas decimais
    }
    public void SaveGameData()
    {
        PlayerPrefs.SetFloat("CurrentMoney", currentMoney);
        PlayerPrefs.SetFloat("MoneyPerSecond", moneyPerSecond);
        // Adicione outros dados específicos da classe GameData que você deseja salvar aqui
        PlayerPrefs.Save();
    }

    // Método para carregar os dados específicos da classe GameData usando PlayerPrefs
    public void LoadGameData()
    {
        currentMoney = PlayerPrefs.GetFloat("CurrentMoney", 0f);
        moneyPerSecond = PlayerPrefs.GetFloat("MoneyPerSecond", 0f);
        // Carregue outros dados específicos da classe GameData que você deseja carregar aqui
    }

}
