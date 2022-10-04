using UnityEngine;
using UnityEditor;

public class GithubWelcomeWindow : EditorWindow
{
    [MenuItem("Window/Github Welcome Window")]
    public static void ShowWindow()
    {
        GetWindow<GithubWelcomeWindow>("Welcome");
    }

    void OnGUI()
    {
        GUILayout.Label("Welcome to this mess that i call (in quotes) the cookieclicker.mp4 mess");
        GUILayout.Label("You can access the save editor by going to Window/Save Data Editor");
        GUILayout.Label("and the Notification Tester at Window/Notification Test");
        GUILayout.Label("damnit i got banned from rec room for a stupid freaking reason");
    }
}
