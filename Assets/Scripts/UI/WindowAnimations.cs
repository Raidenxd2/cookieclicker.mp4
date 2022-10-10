using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowAnimations : MonoBehaviour
{

    public LeanTweenType inType;
    public LeanTweenType outType;

    //shows the window
    void OnEnable()
    {
        LeanTween.scale(gameObject, new Vector3(1, 1, 1), 0.3f).setEase(inType);
    }

    //hides the window
    public void HideWindow()
    {
        LeanTween.scale(gameObject, new Vector3(0, 0, 0), 0.3f).setEase(outType).setOnComplete(HideWindow2);
    }

    //LEAN TWEEN WONT LET ME SETACTIVE IN THE THING
    public void HideWindow2()
    {
        gameObject.SetActive(false);
    }
}
