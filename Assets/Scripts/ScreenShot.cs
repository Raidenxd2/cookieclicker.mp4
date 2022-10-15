 using UnityEngine;
 using System.Collections;
 using System.IO;
 
public class ScreenShot : MonoBehaviour 
{
     
    public string filePath;
    public Notification notification;

    void Start()
    {
        try
        {
            if (!Directory.Exists(Application.dataPath + filePath))
            {
                Directory.CreateDirectory(Application.dataPath + filePath);
            }
 
        }
        catch (IOException ex)
        {
            Debug.LogError(ex.Message);
            notification.ShowNotification(ex.Message, "Error");
        }
    }

    public void DeleteScreenshots()
    {
        try
        {
            Directory.Delete(Application.dataPath + filePath, true);
            Directory.CreateDirectory(Application.dataPath + filePath);
        }
        catch (IOException ex)
        {
            Debug.LogError(ex.Message);
            notification.ShowNotification(ex.Message, "Error");
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.F12))
        {
            TakeScreenshot();
        }
    }

    public void TakeScreenshot()
    {
        //string fileName = "screenshot" + Random.Range(0, 500000) + ".png";
        string datetime = System.DateTime.Now.ToString("MM-dd-yyyy hh;mm;ss");
        ScreenCapture.CaptureScreenshot(Application.dataPath + "/screenshots/" + datetime + ".png", 2);
        if (File.Exists(Application.dataPath + "/screenshots/" + datetime))
        {
            ScreenshotTaken();
        }
        notification.ShowNotification("Screenshot saved at " + Application.dataPath + filePath + "/" + datetime + ".png", "Screenshot Taken");
    }

    void ScreenshotTaken()
    {
        Debug.Log("File Already Taken!");
        //string fileName = "screenshot" + Random.Range(0, 500000) + ".png";
        string datetime = System.DateTime.Now.ToString("MM-dd-yyyy hh;mm;ss");
        ScreenCapture.CaptureScreenshot(Application.dataPath + "/screenshots/" + datetime + ".png", 2);
        if (File.Exists(Application.dataPath + "/screenshots/" + datetime + ".png"))
        {
            ScreenshotTaken();
        }
        notification.ShowNotification("Screenshot saved at " + Application.dataPath + filePath + "/" + datetime + ".png", "Screenshot Taken");
    }
     
}