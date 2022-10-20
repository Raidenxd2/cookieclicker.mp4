using UnityEngine;
using TMPro;

public class CookieGains : MonoBehaviour
{
    public Game game;
    private TMP_Text text;
    private RectTransform atransform;
    void OnEnable()
    {
        game = GameObject.FindGameObjectWithTag("main").GetComponent<Game>();
        text = gameObject.GetComponent<TMP_Text>();
        text.text = game.CPC.ToString("0");
        // atransform = gameObject.GetComponent<RectTransform>();
        // atransform.localPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
    }
}
