[System.Serializable]
public class PlayerData
{
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

    public PlayerData (Game ga)
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
    }
}
