using UnityEngine;
using UnityEditor;

public class SaveDataConfigWindow : EditorWindow
{

    private Game game;
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
        }
        if  (GUILayout.Button("Reset Data"))
        {
            game.ResetData();
        }

        GUILayout.EndHorizontal();

    }
}
