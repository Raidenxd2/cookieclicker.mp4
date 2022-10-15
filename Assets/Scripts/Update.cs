using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class Update : MonoBehaviour
{

    string newVersion;
    public string currentVersion;
    public GameObject UpdateScreen;
    public TMP_Text responseText;

    public void GotoDownload()
    {
        Application.OpenURL("https://raidenxd2.itch.io/cookieclickermp4#download");
    }

    public void CheckForUpdatesGet()
    {
        StartCoroutine(GetRequest("https://itch.io/api/1/x/wharf/latest?target=raidenxd2/cookieclickermp4&channel_name=win-32"));
    }

    void CheckForUpdates()
    {
        Debug.Log("Old Version: " + currentVersion);
        Debug.Log("New Version: " + newVersion);
        if (currentVersion != newVersion)
        {
            UpdateScreen.SetActive(true);
        }
    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                    newVersion = webRequest.downloadHandler.text;
                    responseText.text = "Response: " + webRequest.downloadHandler.text;
                    CheckForUpdates();
                    break;
            }
        }
    }
}
