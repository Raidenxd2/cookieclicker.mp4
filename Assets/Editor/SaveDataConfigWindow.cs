using UnityEngine;
using UnityEditor;

public class SaveDataConfigWindow : EditorWindow
{

    private Game game;
    private MiniGameFarm farm;
    private Rebirth rebirth;
    double cookies;
    double CPC;
    double CPS;
    double DoubleCookies;
    double DoubleCookiesPrice;
    double AutoClickers;
    double AutoClickerPrice;
    double Grandmas;
    double GrandmaPrice;
    double Farms;
    double FarmPrice;
    bool Farm1Growing;
    bool Farm2Growing;
    bool Farm3Growing;
    bool Farm4Growing;
    int Farm1TimeRemaining;
    int Farm2TimeRemaining;
    int Farm3TimeRemaining;
    int Farm4TimeRemaining;
    double Mines;
    double MinePrice;
    double Rebirths;


    [MenuItem("Window/Save Data Editor")]
    public static void ShowWindow()
    {
        GetWindow<SaveDataConfigWindow>("Save Data Editor");
    }

    void OnGUI()
    {
        try
        {
            game = GameObject.FindGameObjectWithTag("main").GetComponent<Game>();
            farm = GameObject.FindGameObjectWithTag("farm").GetComponent<MiniGameFarm>();
            rebirth = GameObject.FindGameObjectWithTag("rebirth").GetComponent<Rebirth>();
        }
        catch
        {
            GUILayout.Label("Must be in the game scene!");
        }
        cookies = EditorGUILayout.DoubleField("Cookies", cookies);
        CPS = EditorGUILayout.DoubleField("Cookies Per Second", CPS);
        CPC = EditorGUILayout.DoubleField("Cookies Per Click", CPC);
        DoubleCookies = EditorGUILayout.DoubleField("Double Cookies", DoubleCookies);
        DoubleCookiesPrice = EditorGUILayout.DoubleField("Double Cookie Price", DoubleCookiesPrice);
        AutoClickers = EditorGUILayout.DoubleField("Auto Clickers", AutoClickers);
        AutoClickerPrice = EditorGUILayout.DoubleField("Auto Clicker Price", AutoClickerPrice);
        Grandmas = EditorGUILayout.DoubleField("Grandmas", Grandmas);
        GrandmaPrice = EditorGUILayout.DoubleField("Grandma Price", GrandmaPrice);
        Farms = EditorGUILayout.DoubleField("Farms", Farms);
        FarmPrice = EditorGUILayout.DoubleField("Farm Price", FarmPrice);
        Farm1Growing = EditorGUILayout.Toggle("Farm 1 Growing?", Farm1Growing);
        Farm2Growing = EditorGUILayout.Toggle("Farm 2 Growing?", Farm2Growing);
        Farm3Growing = EditorGUILayout.Toggle("Farm 3 Growing?", Farm3Growing);
        Farm4Growing = EditorGUILayout.Toggle("Farm 4 Growing?", Farm4Growing);
        Farm1TimeRemaining = EditorGUILayout.IntField("Farm 1 Time Remaining", Farm1TimeRemaining);
        Farm2TimeRemaining = EditorGUILayout.IntField("Farm 2 Time Remaining", Farm2TimeRemaining);
        Farm3TimeRemaining = EditorGUILayout.IntField("Farm 3 Time Remaining", Farm3TimeRemaining);
        Farm4TimeRemaining = EditorGUILayout.IntField("Farm 4 Time Remaining", Farm4TimeRemaining);
        Rebirths = EditorGUILayout.DoubleField("Rebirths", Rebirths);
        Mines = EditorGUILayout.DoubleField("Mines", Mines);
        MinePrice = EditorGUILayout.DoubleField("Mine Price", MinePrice);


        GUILayout.BeginHorizontal();

        if (GUILayout.Button("Update Data"))
        {
            game.Cookies = cookies;
            game.CPC = CPC;
            game.CPS = CPS;
            game.DoubleCookies = DoubleCookies;
            game.DoubleCookiesPrice = DoubleCookiesPrice;
            game.AutoClickers = AutoClickers;
            game.AutoClickerPrice = AutoClickerPrice;
            game.Grandmas = Grandmas;
            game.GrandmaPrice = GrandmaPrice;
            game.Farms = Farms;
            game.FarmPrice = FarmPrice;
            farm.Farm1_IsGrowing = Farm1Growing;
            farm.Farm2_IsGrowing = Farm2Growing;
            farm.Farm3_IsGrowing = Farm3Growing;
            farm.Farm4_IsGrowing = Farm4Growing;
            farm.Farm1_TimeRemaining = Farm1TimeRemaining;
            farm.Farm2_TimeRemaining = Farm2TimeRemaining;
            farm.Farm3_TimeRemaining = Farm3TimeRemaining;
            farm.Farm4_TimeRemaining = Farm4TimeRemaining;
            rebirth.Rebirths = Rebirths;
            game.Mines = Mines;
            game.MinePrice = MinePrice;
            game.SavePlayer();
        }
        if (GUILayout.Button("Load Data"))
        {
            game.LoadPlayer();
            cookies = game.Cookies;
            CPC = game.CPC;
            CPS = game.CPS;
            DoubleCookies = game.DoubleCookies;
            DoubleCookiesPrice = game.DoubleCookiesPrice;
            AutoClickers = game.AutoClickers;
            AutoClickerPrice = game.AutoClickerPrice;
            Grandmas = game.Grandmas;
            GrandmaPrice = game.GrandmaPrice;
            Farms = game.Farms;
            FarmPrice = game.FarmPrice;
            Farm1Growing = farm.Farm1_IsGrowing;
            Farm2Growing = farm.Farm2_IsGrowing;
            Farm3Growing = farm.Farm3_IsGrowing;
            Farm4Growing = farm.Farm4_IsGrowing;
            Farm1TimeRemaining = farm.Farm1_TimeRemaining;
            Farm2TimeRemaining = farm.Farm2_TimeRemaining;
            Farm3TimeRemaining = farm.Farm3_TimeRemaining;
            Farm4TimeRemaining = farm.Farm4_TimeRemaining;
            Mines = game.Mines;
            MinePrice = game.MinePrice;
            Rebirths = rebirth.Rebirths;
        }
        if  (GUILayout.Button("Reset Data"))
        {
            game.ResetData();
        }

        GUILayout.EndHorizontal();

    }
}
