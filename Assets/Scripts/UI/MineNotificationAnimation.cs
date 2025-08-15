using System.Collections;
using UnityEngine;

public class MineNotificationAnimation : MonoBehaviour
{
    public Animation NotificationAnimations;
    public GameObject NotificationObject;
    private Vector2 position;
    private bool Playing;
    public RectTransform OringinalPos;

    void OnEnable()
    {
        Playing = true;
        NotificationAnimations.Play("MineNotificationOpen");
        position = OringinalPos.anchoredPosition;
        StartCoroutine(NotificationWaitThenClose());
    }

    IEnumerator NotificationWaitThenClose()
    {
        yield return new WaitForSeconds(5);
        NotificationAnimations.Play("MineNotificationClose");
        yield return new WaitForSeconds(1);
        Playing = false;
    }

    void Update()
    {
        if (Playing == false)
        {
            OringinalPos.anchoredPosition = position;
            NotificationObject.SetActive(false);
        }
    }
}