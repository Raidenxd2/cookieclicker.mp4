using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MiniGameMine : MonoBehaviour
{
    
    public float tempHammerStrength;
    public float tempHammerEnergy;
    public float HammerStrength;
    public float HammerEnergy;
    public double HammerStrengthUpgradePrice;
    public double Coins;
    public double HammerEnergyUpgradePrice;
    public double CoinMultiplierUpgradePrice;
    public double CoinMultiplier;
    public GameObject NECDialog;
    public Transform Player;
    public Vector3 StartPos;
    public bool Moving;
    public TMP_Text HammerStrengthText;
    public TMP_Text HammerEnergyText;
    public TMP_Text CoinsText;
    public TMP_Text HammerStrengthPriceText;
    public TMP_Text HammerEnergyPriceText;
    public TMP_Text Depth;
    public TMP_Text CoinMultiplierPriceText;
    public GameObject LoseScreen;
    public TMP_Text LoseScreen_Depth;
    public bool reachedStone;
    public bool reachedHardStone;
    public bool reachedHeat;
    public bool reachedRed;
    public bool reachedWhite;
    public bool reachedEnd;
    public GameObject WinScreen;

    void Start()
    {
        if (HammerStrengthUpgradePrice <= 100)
        {
            HammerStrength = 0.2f;
            HammerStrengthUpgradePrice = 100;
        }
        if (HammerEnergyUpgradePrice <= 200)
        {
            HammerEnergy = 100;
            HammerEnergyUpgradePrice = 200;
        }
        if (CoinMultiplierUpgradePrice <= 300)
        {
            CoinMultiplier = 1;
            CoinMultiplierUpgradePrice = 300;
        }
        StartCoroutine(Init());
    }

    void Update()
    {
        if (Moving)
        {
            moveDown();
        }
        HammerStrengthText.text = "Drill Strength: " + tempHammerStrength;
        HammerEnergyText.text = "Drill Energy: " + tempHammerEnergy;
        HammerStrengthPriceText.text = "Drill Strength Upgrade (" + HammerStrengthUpgradePrice + " Coins";
        HammerEnergyPriceText.text = "Drill Energy Upgrade (" + HammerEnergyUpgradePrice + " Coins";
        CoinMultiplierPriceText.text = "Coin Multiplier Upgrade(" + CoinMultiplierUpgradePrice + " Coins";
        Depth.text = "Depth: " + Player.localPosition.y;
        CoinsText.text = Coins.ToString("Coins: " + "0");
    }

    IEnumerator Init()
    {
        yield return new WaitForSeconds(0.1f);
        tempHammerStrength = HammerStrength;
        tempHammerEnergy = HammerEnergy;
        Player.localPosition = StartPos;
        reachedHardStone = false;
        reachedStone = false;
        reachedHardStone = false;
        reachedRed = false;
        reachedWhite = false;
    }

    public void GameWin()
    {
        WinScreen.SetActive(true);
    }

    public void GameLose()
    {
        StartCoroutine(Init());
    }

    void moveDown()
    {
        if (tempHammerEnergy <= 0)
        {
            LoseScreen_Depth.text = "Depth: " + Player.localPosition.y;
            LoseScreen.SetActive(true);
            return;
        }
        Vector3 currentPos;
        Vector3 newPos;
        currentPos = Player.localPosition;
        newPos = new Vector3(0, currentPos.y - tempHammerStrength, 15.69f);
        Player.localPosition = newPos;
        Coins += HammerStrength * CoinMultiplier;
        double DebugCoins;
        DebugCoins = HammerStrength * CoinMultiplier;
        Debug.Log("Coins Added: " + DebugCoins);
        tempHammerEnergy -= 0.2f;
    }

    public void DecreseHammerStrength(float decrese)
    {
        Debug.Log("Hammer Decrese" + "\nnew: " + decrese + "\nold: " + tempHammerStrength);
        tempHammerStrength -= decrese;
    }

    public void BuyHammerStrengthUpgrade()
    {
        if (Coins >= HammerStrengthUpgradePrice)
        {
            Coins -= HammerStrengthUpgradePrice;
            HammerStrengthUpgradePrice += 100;
            HammerStrength += 0.3f;
        }
        else
        {
            NECDialog.SetActive(true);
        }
    }

    public void BuyHammerEnergyUpgrade()
    {
        if (Coins >= HammerEnergyUpgradePrice)
        {
            Coins -= HammerEnergyUpgradePrice;
            HammerEnergyUpgradePrice += 200;
            HammerEnergy += 10;
        }
        else
        {
            NECDialog.SetActive(true);
        }
    }

    public void BuyCoinMultiplyerUpgrade()
    {
        if (Coins >= CoinMultiplierUpgradePrice)
        {
            Coins -= CoinMultiplierUpgradePrice;
            CoinMultiplierUpgradePrice += 300;
            CoinMultiplier += 0.3;
        }
        else
        {
            NECDialog.SetActive(true);
        }
    }

}
