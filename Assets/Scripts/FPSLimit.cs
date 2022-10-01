using UnityEngine;

public class FPSLimit : MonoBehaviour
{
    void Start()
    {
        int refreshRate = Screen.currentResolution.refreshRate;
        Application.targetFrameRate = refreshRate;
        Debug.Log("[DEBUG] User Refresh Rate: " + refreshRate);
    }
}
