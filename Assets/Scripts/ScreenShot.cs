 using UnityEngine;
 using System.Collections;
 using System.IO;
 using TMPro;
 
public class ScreenShot : MonoBehaviour 
{
     
    public string filePath;
    public Notification notification;
    public int ScreenshotQuality;
    public TMP_Text ScreenshotQualityText;

    void Start()
    {
        try
        {
            if (!Directory.Exists(Application.persistentDataPath + filePath))
            {
                Directory.CreateDirectory(Application.persistentDataPath + filePath);
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
            Directory.Delete(Application.persistentDataPath + filePath, true);
            Directory.CreateDirectory(Application.persistentDataPath + filePath);
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
        ScreenCapture.CaptureScreenshot(Application.persistentDataPath + "/screenshots/" + datetime + ".png", ScreenshotQuality);
        notification.ShowNotification("Screenshot saved at " + Application.persistentDataPath + filePath + "/" + datetime + ".png", "Screenshot Taken");
    }

    public void OnValueChanged(float newValue)
    {
        string StringConvert;
        int IntConvert;
        StringConvert = newValue.ToString("0");
        //int.TryParse(StringConvert, out IntConvert);
        IntConvert = int.Parse(StringConvert);
        ScreenshotQuality = IntConvert;
        ScreenshotQualityText.text = IntConvert + "x";
    }
     
}