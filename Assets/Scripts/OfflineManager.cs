using System;
using UnityEngine;
using TMPro;

public class OfflineManager : MonoBehaviour
{
    public TMP_Text TimeAway;
    public TMP_Text CookiesGained;

    public GameObject OfflineProgressScreen;

    public DateTime currentTime;
    public DateTime oldTime;

    public Game game;
    public Rebirth rebirth;

    public bool offlineProgressCheck;
    public string OfflineTime;

    public void LoadOfflineTime()
    {
        Debug.Log("offlineProgressCheck: " + offlineProgressCheck);
        if (offlineProgressCheck)
        {
            var tempOfflineTime = Convert.ToInt64(OfflineTime);
            var oldTime = DateTime.FromBinary(tempOfflineTime);
            currentTime = DateTime.Now;
            
            var difference = currentTime.Subtract(oldTime);
            var rawTime = (float) difference.TotalSeconds;
            var offlineTime = rawTime / 2;
            OfflineProgressScreen.SetActive(true);
            TimeSpan timer = TimeSpan.FromSeconds(rawTime);
            TimeAway.text = $"{timer:dd\\:hh\\:mm\\:ss}";

            Debug.Log("Offline Time: " + offlineTime);
            Debug.Log("CPS: " + game.CPS);
            double CookiesGain = offlineTime * game.CPS * rebirth.Rebirths;
            game.Cookies += CookiesGain;
            CookiesGained.text = CookiesGain.ToString("0 Cookies");

            //debug
            Debug.Log("cookies gained from offline: " + CookiesGain);
        }
    }

    public void SaveTime()
    {
        OfflineTime = DateTime.Now.ToBinary().ToString();
        offlineProgressCheck = true;
    }
}