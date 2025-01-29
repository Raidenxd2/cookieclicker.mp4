using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.IO;

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
    public double MinePrice;
    public double Mines;
    public bool HasJoined;
    public bool PostProcessing;
    public bool Music;
    public bool Sound;
    public bool Fullscreen;
    public bool Particles;
    public double TimePlayed;

    //text
    public TMP_Text CookieCounter;
    public TMP_Text Shop_AutoClickerPrice;
    public TMP_Text Shop_DoubleCookiePrice;
    public TMP_Text Shop_GrandmaPrice;
    public TMP_Text Shop_FarmPrice;
    public TMP_Text Shop_MinePrice;
    public TMP_Text Stats_AutoClickers;
    public TMP_Text Stats_DoubleCookies;
    public TMP_Text Stats_Cookies;
    public TMP_Text Stats_Grandmas;
    public TMP_Text Stats_CPS;
    public TMP_Text Stats_CPC;
    public TMP_Text Stats_Farms;
    public TMP_Text Stats_Rebirths;
    public TMP_Text Stats_Mines;
    public TMP_Text Stats_TimePlayed;

    //UI
    public GameObject NotEnoughCookiesDialog;
    public GameObject MiniGames_FarmBTN;
    public GameObject MiniGames_MineBTN;
    public GameObject FullScreenToggleUI;
    public GameObject ScreenshotSettingsBTN;
    public GameObject TutorialScreen;

    //other
    public GameObject pp;
    public SoundManager soundManager;
    public BGColor bGColor;
    public MiniGameFarm miniGameFarm;
    public GameObject CookieVFX;
    public Transform CookieVFXPos;
    public GameObject VFX;
    public Rebirth rebirth;
    public Update update;
    public MiniGameMine miniGameMine;
    public GameObject MiniGameMine;
    public RenderTexture NotificationRender;
    public ScreenShot screenShot;
    public GameObject CookieGains;
    public OfflineManager offlineManager;

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
        if (File.Exists(Application.persistentDataPath + "/cookie"))
        {
            LoadPlayer();
        }
        else
        {
            TutorialScreen.SetActive(true);
            SavePlayer();
            HasJoined = true;
            PostProcessing = true;
            Music = true;
            Sound = true;
            Fullscreen = true;
            Particles = true;
            screenShot.ScreenshotQuality = 1;
            screenShot.NotificationsInScreenshots = true;
            ResetData();
            SavePlayer();
            Reload();
        }
        
        soundManager = GameObject.FindGameObjectWithTag("sound").GetComponent<SoundManager>();
        sounds = GameObject.FindGameObjectWithTag("sound").GetComponents<AudioSource>();
        
        if (GrandmaPrice <= 125)
        {
            GrandmaPrice = 125;
        }
        if (FarmPrice <= 300)
        {
            FarmPrice = 300;
        }
        if (MinePrice <= 1000)
        {
            MinePrice = 1000;
        }
        if (Application.isMobilePlatform == true)
        {
            FullScreenToggleUI.SetActive(false);
            ScreenshotSettingsBTN.SetActive(false);
        }
        else
        {
            FullScreenToggleUI.SetActive(true);
            ScreenshotSettingsBTN.SetActive(true);
        }
        StartCoroutine(bugfix());
        StartCoroutine(AutoSave());
        StartCoroutine(Tick());
        // update.CheckForUpdatesGet();
        ResizeRenderTexture(NotificationRender, Screen.currentResolution.width, Screen.currentResolution.height);
        offlineManager.LoadOfflineTime();
        SetMaxFPS();
    }

    void SetMaxFPS()
    {
        int refreshRate = (int)Screen.currentResolution.refreshRateRatio.value;
        refreshRate++;
        Application.targetFrameRate = refreshRate;
        Debug.Log("[DEBUG] User Refresh Rate: " + refreshRate);
    }

    void ResizeRenderTexture(RenderTexture renderTexture, int width, int height) 
    {
        if (renderTexture) 
        {
            renderTexture.width = width;
            renderTexture.height = height;
            Debug.Log("Resized render texture to: " + renderTexture.width + renderTexture.height);
        }
    }

    IEnumerator bugfix()
    {
        MiniGameMine.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        MiniGameMine.SetActive(false);
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
        Cookies += CPS * rebirth.Rebirths;
        TimePlayed += 1;
        StartCoroutine(Tick());
    }

    public void PostProcessToggle(bool toggle)
    {
        PostProcessing = toggle;
    }

    public void MusicToggle(bool toggle)
    {
        Music = toggle;
    }

    public void SoundToggle(bool toggle)
    {
        Sound = toggle;
    }

    public void FullscreenToggle(bool toggle)
    {
        Fullscreen = toggle;
        if (Fullscreen == true)
        {
            Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, FullScreenMode.FullScreenWindow, Screen.currentResolution.refreshRate);
        }
        if (Fullscreen == false)
        {
            Screen.SetResolution(800, 600, FullScreenMode.Windowed, Screen.currentResolution.refreshRate);
        }
    }

    public void ParticlesToggle(bool toggle)
    {
        Particles = toggle;
    }

    public void SavePlayer()
    {
        offlineManager.SaveTime();
        SaveSystem.SavePlayer(this, miniGameFarm, rebirth, miniGameMine, screenShot, offlineManager);
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
        Mines = data.Mines;
        MinePrice = data.MinePrice;
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
        Fullscreen = data.Fullscreen;
        Particles = data.Particles;
        rebirth.Rebirths = data.Rebirths;
        rebirth.RebirthCookies = data.RebirthCookies;
        rebirth.RebirthGrandmas = data.RebirthGrandmas;
        TimePlayed = data.TimePlayed;
        miniGameMine.HammerEnergy = data.HammerEnergy;
        miniGameMine.HammerEnergyUpgradePrice = data.HammerEnergyUpgradePrice;
        miniGameMine.HammerStrength = data.HammerStrength;
        miniGameMine.HammerStrengthUpgradePrice = data.HammerStrengthUpgradePrice;
        miniGameMine.Coins = data.Coins;
        miniGameMine.CoinMultiplier = data.CoinMultiplier;
        miniGameMine.CoinMultiplier = data.CoinMultiplierUpgradePrice;
        screenShot.ScreenshotQuality = data.ScreenshotQuality;
        screenShot.NotificationsInScreenshots = data.NotificationsInScreenshots;
        offlineManager.offlineProgressCheck = data.offlineProgressCheck;
        offlineManager.OfflineTime = data.OfflineTime;
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
        Mines = 0;
        MinePrice = 1000;
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
        rebirth.Rebirths = 1;
        rebirth.RebirthCookies = 1000000;
        rebirth.RebirthGrandmas = 10;
        TimePlayed = 0;
        miniGameMine.HammerEnergy = 100;
        miniGameMine.HammerEnergyUpgradePrice = 200;
        miniGameMine.HammerStrength = 0.2f;
        miniGameMine.HammerStrengthUpgradePrice = 100;
        miniGameMine.Coins = 0;
        miniGameMine.CoinMultiplier = 1;
        miniGameMine.CoinMultiplierUpgradePrice = 300;

        SavePlayer();
    }

    public void bakeCookie()
    {
        Cookies += CPC * rebirth.Rebirths;
        Instantiate(CookieVFX, CookieVFXPos);
        Instantiate(CookieGains, CookieVFXPos);
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

    public void BuyMine()
    {
        if (Cookies >= MinePrice)
        {
            Cookies -= MinePrice;
            MinePrice += 1000;
            Mines += 1;
            CPS += 3;
            CPC += 10;
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
        Shop_MinePrice.text = MinePrice.ToString("Mine ( " + "0" + " Cookies");
        Stats_AutoClickers.text = AutoClickers.ToString("Auto Clickers: " + "0");
        Stats_DoubleCookies.text = DoubleCookies.ToString("Double Cookies: " + "0");
        Stats_Cookies.text = Cookies.ToString("Cookies: " + "0");
        Stats_Grandmas.text = Grandmas.ToString("Grandmas: " + "0");
        Stats_CPC.text = CPC.ToString("Total Cookies Per Click: " + "0");
        Stats_CPS.text = CPS.ToString("Total Cookies Per Second: " + "0");
        Stats_Farms.text = Farms.ToString("Farms: " + "0");
        Stats_Rebirths.text = rebirth.Rebirths.ToString("Rebirths: " + "0");
        Stats_Mines.text = Mines.ToString("Mines: " + "0");
        Stats_TimePlayed.text = TimePlayed.ToString("Time Played Seconds: " + "0");
        if (Sound)
        {
            sounds[0].volume = 1;
        }
        else
        {
            sounds[0].volume = 0;
        }
        if (Music)
        {
            sounds[1].volume = 1;
        }
        else
        {
            sounds[1].volume = 0;
        }
        pp.SetActive(PostProcessing);
        Screen.fullScreen = Fullscreen;
        VFX.SetActive(Particles);
        
        if (Farms >= 1)
        {
            MiniGames_FarmBTN.SetActive(true);
        }
        else
        {
            MiniGames_FarmBTN.SetActive(false);
        }
        if (Mines >= 1)
        {
            MiniGames_MineBTN.SetActive(true);
        }
        else
        {
            MiniGames_MineBTN.SetActive(false);
        }
        if (!sounds[1].isPlaying)
        {
            SoundManager.Instance.RandomMusic(music);
        }
    }
}
