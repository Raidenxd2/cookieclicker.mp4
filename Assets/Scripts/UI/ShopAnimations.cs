using UnityEngine;

public class ShopAnimations : MonoBehaviour
{
    public LeanTweenType inType;
    public LeanTweenType outType;

    //shows the window
    void OnEnable()
    {
        LeanTween.moveLocalX(gameObject, 1f, 0.4f).setEase(inType);
    }

    //hides the window
    public void HideWindow()
    {
        LeanTween.moveLocalX(gameObject, -1f, 0.4f).setEase(outType).setOnComplete(HideWindow2);
    }

    //LEAN TWEEN WONT LET ME SETACTIVE IN THE THING
    public void HideWindow2()
    {
        gameObject.SetActive(false);
    }
}