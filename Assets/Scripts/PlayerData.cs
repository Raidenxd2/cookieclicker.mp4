[System.Serializable]
public class PlayerData
{

    //game
    public double Cookies;
    public double CPC;
    public double DoubleCookies;
    public double DoubleCookiesPrice;
    public double AutoClickers;
    public double AutoClickerPrice;
    public double CPS;
    public double Grandmas;
    public double GrandmaPrice;
    public double Farms;
    public double FarmPrice;
    public bool HasJoined;
    public bool PostProcessing;
    public bool Music;
    public bool Sound;
    public bool Fullscreen;
    public double TimePlayed;

    //farm
    public bool Farm1_IsGrowing;
    public bool Farm2_IsGrowing;
    public bool Farm3_IsGrowing;
    public bool Farm4_IsGrowing;
    public int Farm1_TimeRemaining;
    public int Farm2_TimeRemaining;
    public int Farm3_TimeRemaining;
    public int Farm4_TimeRemaining;
    public string Farm1_Type;
    public string Farm2_Type;
    public string Farm3_Type;
    public string Farm4_Type;
    public bool WhiteCarrots;
    public bool Particles;
    public double RebirthCookies;
    public double RebirthGrandmas;
    public double Rebirths;
    public double Mines;
    public double MinePrice;
    public float HammerStrength;
    public float HammerEnergy;
    public double HammerStrengthUpgradePrice;
    public double Coins;
    public double HammerEnergyUpgradePrice;
    public double CoinMultiplier;
    public double CoinMultiplierUpgradePrice;
    public int ScreenshotQuality;

    public PlayerData (Game ga, MiniGameFarm fa, Rebirth re, MiniGameMine mi, ScreenShot ss)
    {
        Cookies = ga.Cookies;
        CPC = ga.CPC;
        DoubleCookies = ga.DoubleCookies;
        HasJoined = ga.HasJoined;
        DoubleCookiesPrice = ga.DoubleCookiesPrice;
        AutoClickers = ga.AutoClickers;
        AutoClickerPrice = ga.AutoClickerPrice;
        CPS = ga.CPS;
        PostProcessing = ga.PostProcessing;
        Music = ga.Music;
        Sound = ga.Sound;
        Grandmas = ga.Grandmas;
        GrandmaPrice = ga.GrandmaPrice;
        Farms = ga.Farms;
        FarmPrice = ga.FarmPrice;
        Farm1_IsGrowing = fa.Farm1_IsGrowing;
        Farm2_IsGrowing = fa.Farm2_IsGrowing;
        Farm3_IsGrowing = fa.Farm3_IsGrowing;
        Farm4_IsGrowing = fa.Farm4_IsGrowing;
        Farm1_TimeRemaining = fa.Farm1_TimeRemaining;
        Farm2_TimeRemaining = fa.Farm2_TimeRemaining;
        Farm3_TimeRemaining = fa.Farm3_TimeRemaining;
        Farm4_TimeRemaining = fa.Farm4_TimeRemaining;
        Farm1_Type = fa.Farm1_Type;
        Farm2_Type = fa.Farm2_Type;
        Farm3_Type = fa.Farm3_Type;
        Farm4_Type = fa.Farm4_Type;
        WhiteCarrots = fa.WhiteCarrots;
        Fullscreen = ga.Fullscreen;
        Particles = ga.Particles;
        RebirthCookies = re.RebirthCookies;
        RebirthGrandmas = re.RebirthGrandmas;
        Rebirths = re.Rebirths;
        Mines = ga.Mines;
        MinePrice = ga.MinePrice;
        TimePlayed = ga.TimePlayed;
        HammerStrength = mi.HammerStrength;
        HammerEnergy = mi.HammerEnergy;
        HammerEnergyUpgradePrice = mi.HammerEnergyUpgradePrice;
        HammerStrengthUpgradePrice = mi.HammerStrengthUpgradePrice;
        Coins = mi.Coins;
        CoinMultiplier = mi.CoinMultiplier;
        CoinMultiplierUpgradePrice = mi.CoinMultiplierUpgradePrice;
        ScreenshotQuality = ss.ScreenshotQuality;
    }
}
