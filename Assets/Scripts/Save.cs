using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour
{
    public GameData data;
    public Clicker click;

    public List<Upgrade> upgrades;
    public List<Shop> shops;

    // Start is called before the first frame update
    void Start()
    {
        //---------------------------------------------------------------------------------------------//
        //RESET LINE                                                                                   //
        PlayerPrefs.DeleteAll();                                                                     //
        //---------------------------------------------------------------------------------------------//

        //LOAD
        LoadAllShopData();

        data.LoadGameData();
        click.LoadClickerData();
    }

    // Update is called once per frame
    void Update()
    {
        SaveAllShopData();
        SaveAllUpgradeData();
        data.SaveGameData();
        click.SaveClickerData();
    }

    // Salva|Carrega lista de Shops
    public void SaveAllShopData()
    {
        foreach (Shop shop in shops)
        {
            shop.SaveShopData();
        }
    }
    public void LoadAllShopData()
    {
        foreach (Shop shop in shops)
        {
            shop.LoadShopData();
        }
    }

    // Salva|Carrega lista de Upgrades
    public void SaveAllUpgradeData()
    {
        foreach (Upgrade upgrade in upgrades)
        {
            upgrade.SaveUpgradeData();
        }
    }

    public void LoadAllUpgradeData()
    {
        foreach (Upgrade upgrade in upgrades)
        {
            upgrade.LoadUpgradeData();
        }
    }
}
