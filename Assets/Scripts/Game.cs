using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{

    //game variables
    public double Cookies;
    public double CPC;
    public double DoubleCookies;
    public double DoubleCookiesPrice;
    public double AutoClickers;
    public double AutoClickerPrice;
    public double Grandmas;
    public double GrandmaPrice;
    public double CPS;
    public double Farms;
    public double FarmPrice;
    public bool HasJoined;
    public bool PostProcessing;
    public bool Music;
    public bool Sound;
    public bool Fullscreen;

    //text
    public TMP_Text CookieCounter;
    public TMP_Text Shop_AutoClickerPrice;
    public TMP_Text Shop_DoubleCookiePrice;
    public TMP_Text Shop_GrandmaPrice;
    public TMP_Text Shop_FarmPrice;
    public TMP_Text Stats_AutoClickers;
    public TMP_Text Stats_DoubleCookies;
    public TMP_Text Stats_Cookies;
    public TMP_Text Stats_Grandmas;
    public TMP_Text Stats_CPS;
    public TMP_Text Stats_CPC;
    public TMP_Text Stats_Farms;

    //UI
    public GameObject NotEnoughCookiesDialog;
    public GameObject MiniGames_FarmBTN;

    //other
    public GameObject pp;
    public SoundManager soundManager;
    public BGColor bGColor;
    public MiniGameFarm miniGameFarm;

    //Audio
    public AudioSource[] sounds;
    public AudioClip[] music;
    public AudioClip errorSound;

    void OnApplicationQuit()
    {
        SavePlayer();
    }

    // Start is called before the first frame update
    void Awake()
    {
        LoadPlayer();
        soundManager = GameObject.FindGameObjectWithTag("sound").GetComponent<SoundManager>();
        sounds = GameObject.FindGameObjectWithTag("sound").GetComponents<AudioSource>();
        if (HasJoined == false)
        {
            SavePlayer();
            HasJoined = true;
            PostProcessing = true;
            Music = true;
            Sound = true;
            Fullscreen = true;
            ResetData();
        }
        if (GrandmaPrice <= 125)
        {
            GrandmaPrice = 125;
        }
        if (FarmPrice <= 300)
        {
            FarmPrice = 300;
        }
        StartCoroutine(AutoSave());
        StartCoroutine(Tick());
    }

    IEnumerator AutoSave()
    {
        yield return new WaitForSeconds(60);
        SavePlayer();
        StartCoroutine(AutoSave());
    }

    IEnumerator Tick()
    {
        yield return new WaitForSeconds(1);
        Cookies += CPS;
        StartCoroutine(Tick());
    }

    public void PostProcessToggle()
    {
        PostProcessing = !PostProcessing;
    }

    public void MusicToggle()
    {
        Music = !Music;
    }

    public void SoundToggle()
    {
        Sound = !Sound;
    }

    public void FullscreenToggle()
    {
        Fullscreen = !Fullscreen;
    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this, miniGameFarm);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        SaveSystem.LoadPlayer();

        Cookies = data.Cookies;
        CPC = data.CPC;
        DoubleCookies = data.DoubleCookies;
        HasJoined = data.HasJoined;
        DoubleCookiesPrice = data.DoubleCookiesPrice;
        AutoClickers = data.AutoClickers;
        AutoClickerPrice = data.AutoClickerPrice;
        CPS = data.CPS;
        PostProcessing = data.PostProcessing;
        Sound = data.Sound;
        Music = data.Music;
        Grandmas = data.Grandmas;
        GrandmaPrice = data.GrandmaPrice;
        Farms = data.Farms;
        FarmPrice = data.FarmPrice;
        miniGameFarm.Farm1_IsGrowing = data.Farm1_IsGrowing;
        miniGameFarm.Farm2_IsGrowing = data.Farm2_IsGrowing;
        miniGameFarm.Farm3_IsGrowing = data.Farm3_IsGrowing;
        miniGameFarm.Farm4_IsGrowing = data.Farm4_IsGrowing;
        miniGameFarm.Farm1_TimeRemaining = data.Farm1_TimeRemaining;
        miniGameFarm.Farm2_TimeRemaining = data.Farm2_TimeRemaining;
        miniGameFarm.Farm3_TimeRemaining = data.Farm3_TimeRemaining;
        miniGameFarm.Farm4_TimeRemaining = data.Farm4_TimeRemaining;
        miniGameFarm.Farm1_Type = data.Farm1_Type;
        miniGameFarm.Farm2_Type = data.Farm2_Type;
        miniGameFarm.Farm3_Type = data.Farm3_Type;
        miniGameFarm.Farm4_Type = data.Farm4_Type;
        miniGameFarm.WhiteCarrots = data.WhiteCarrots;
    }

    public void ResetData()
    {
        Cookies = 0;
        CPC = 1;
        DoubleCookies = 0;
        DoubleCookiesPrice = 50;
        AutoClickers = 0;
        AutoClickerPrice = 25;
        CPS = 0;
        GrandmaPrice = 125;
        Grandmas = 0;
        Farms = 0;
        FarmPrice = 300;
        miniGameFarm.Farm1_IsGrowing = false;
        miniGameFarm.Farm2_IsGrowing = false;
        miniGameFarm.Farm3_IsGrowing = false;
        miniGameFarm.Farm4_IsGrowing = false;
        miniGameFarm.Farm1_TimeRemaining = 0;
        miniGameFarm.Farm2_TimeRemaining = 0;
        miniGameFarm.Farm3_TimeRemaining = 0;
        miniGameFarm.Farm4_TimeRemaining = 0;
        miniGameFarm.Farm1_Type = "";
        miniGameFarm.Farm2_Type = "";
        miniGameFarm.Farm3_Type = "";
        miniGameFarm.Farm4_Type = "";
        miniGameFarm.WhiteCarrots = false;
        SavePlayer();
    }

    public void bakeCookie()
    {
        Cookies += CPC;
    }

    public void BuyAutoClicker()
    {
        if (Cookies >= AutoClickerPrice)
        {
            Cookies -= AutoClickerPrice;
            AutoClickerPrice += 25;
            AutoClickers += 1;
            CPS += 1;
        }
        else
        {
            NotEnoughCookiesDialog.SetActive(true);
            SoundManager.Instance.Play(errorSound);
        }
    }

    public void BuyDoubleCookie()
    {
        if (Cookies >= DoubleCookiesPrice)
        {
            Cookies -= DoubleCookiesPrice;
            DoubleCookiesPrice += 50;
            DoubleCookies +=1;
            CPC += 1;
        }
        else
        {
            NotEnoughCookiesDialog.SetActive(true);
            SoundManager.Instance.Play(errorSound);
        }
    }

    public void BuyGrandma()
    {
        if (Cookies >= GrandmaPrice)
        {
            Cookies -= GrandmaPrice;
            GrandmaPrice += 125;
            Grandmas += 1;
            CPS += 3;
        }
        else
        {
            NotEnoughCookiesDialog.SetActive(true);
            SoundManager.Instance.Play(errorSound);
        }
    }

    public void BuyFarm()
    {
        if (Cookies >= FarmPrice)
        {
            Cookies -= FarmPrice;
            FarmPrice += 300;
            Farms += 1;
            CPS += 10;
        }
        else
        {
            NotEnoughCookiesDialog.SetActive(true);
            SoundManager.Instance.Play(errorSound);
        }
    }

    public void QuitGame()
    {
        SavePlayer();
        Application.Quit();
    }

    public void Reload()
    {
        SavePlayer();
        SceneManager.LoadScene(2);
    }

    // Update is called once per frame
    void Update()
    {
        CookieCounter.text = Cookies.ToString("Cookies: " + "0");
        Shop_AutoClickerPrice.text = AutoClickerPrice.ToString("Auto Clicker (" + "0" + " Cookies)");
        Shop_DoubleCookiePrice.text = DoubleCookiesPrice.ToString("Double Cookie (" + "0" + " Cookies)");
        Shop_GrandmaPrice.text = GrandmaPrice.ToString("Grandma (" + "0" + " Cookies)");
        Shop_FarmPrice.text = FarmPrice.ToString("Farm (" + "0" + " Cookies)");
        Stats_AutoClickers.text = AutoClickers.ToString("Auto Clickers: " + "0");
        Stats_DoubleCookies.text = DoubleCookies.ToString("Double Cookies: " + "0");
        Stats_Cookies.text = Cookies.ToString("Cookies: " + "0");
        Stats_Grandmas.text = Grandmas.ToString("Grandmas: " + "0");
        Stats_CPC.text = CPC.ToString("Total Cookies Per Click: " + "0");
        Stats_CPS.text = CPS.ToString("Total Cookies Per Second: " + "0");
        Stats_Farms.text = Farms.ToString("Farms: " + "0");
        sounds[0].enabled = Sound;
        sounds[1].enabled = Music;
        pp.SetActive(PostProcessing);
        Screen.fullScreen = Fullscreen;
        
        if (Farms >= 1)
        {
            MiniGames_FarmBTN.SetActive(true);
        }
        else
        {
            MiniGames_FarmBTN.SetActive(false);
        }
        if (!sounds[1].isPlaying)
        {
            SoundManager.Instance.RandomMusic(music);
        }
    }
}
