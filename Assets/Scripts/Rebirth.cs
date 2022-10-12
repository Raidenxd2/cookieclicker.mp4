using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Rebirth : MonoBehaviour
{

    public double RebirthCookies;
    public double RebirthGrandmas;
    public double Rebirths;
    public GameObject ReqNotMet;
    public Game game;
    public TMP_Text Requirements;

    void Awake()
    {
        if (Rebirths <= 0)
        {
            RebirthCookies = 1000000;
            RebirthGrandmas = 10;
            Rebirths = 1;
        }
    }

    public void RebirthCheck()
    {
        if (game.Cookies >= RebirthCookies && game.Grandmas >= RebirthGrandmas)
        {
            RebirthCookies += Random.Range(1000000, 10000000);
            RebirthGrandmas += 10;
            Rebirths += 1;
            RebirthReset();
        }
        else
        {
            ReqNotMet.SetActive(true);
        }
    }

    void RebirthReset()
    {
        game.Cookies = 10000;
        game.CPC = 1;
        game.DoubleCookies = 0;
        game.DoubleCookiesPrice = 50;
        game.AutoClickers = 0;
        game.AutoClickerPrice = 25;
        game.CPS = 0;
        game.GrandmaPrice = 125;
        game.Grandmas = 0;
        game.Farms = 0;
        game.FarmPrice = 300;
        game.miniGameFarm.Farm1_IsGrowing = false;
        game.miniGameFarm.Farm2_IsGrowing = false;
        game.miniGameFarm.Farm3_IsGrowing = false;
        game.miniGameFarm.Farm4_IsGrowing = false;
        game.miniGameFarm.Farm1_TimeRemaining = 0;
        game.miniGameFarm.Farm2_TimeRemaining = 0;
        game.miniGameFarm.Farm3_TimeRemaining = 0;
        game.miniGameFarm.Farm4_TimeRemaining = 0;
        game.miniGameFarm.Farm1_Type = "";
        game.miniGameFarm.Farm2_Type = "";
        game.miniGameFarm.Farm3_Type = "";
        game.miniGameFarm.Farm4_Type = "";
        game.miniGameFarm.WhiteCarrots = false;
    }

    // Update is called once per frame
    void Update()
    {
        Requirements.text = "Cookies: " + RebirthCookies + "\nGrandmas: " + RebirthGrandmas;
    }
}
