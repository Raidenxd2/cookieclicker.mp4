using UnityEngine;
using UnityEditor;

public class NotificationTestWindow : EditorWindow
{

    private Notification notification;
    private string message;
    private string Title;

    [MenuItem("Window/Notification Test")]
    public static void ShowWindow()
    {
        GetWindow<NotificationTestWindow>("Notification Test");
    }

    void OnGUI()
    {
        try
        {
            notification = GameObject.FindGameObjectWithTag("notification").GetComponent<Notification>();
        }
        catch
        {
            GUILayout.Label("Must be in the game scene!");
        }
        message = EditorGUILayout.TextField("Message", message);
        Title = EditorGUILayout.TextField("Title", Title);
        if (GUILayout.Button("Test Notification"))
        {
            notification.ShowNotification(message, Title);
        }
    }
}
