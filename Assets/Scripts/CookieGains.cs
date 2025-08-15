using UnityEngine;
using TMPro;

public class CookieGains : MonoBehaviour
{
    public Game game;
    private TMP_Text text;

    void OnEnable()
    {
        game = GameObject.FindGameObjectWithTag("main").GetComponent<Game>();
        text = gameObject.GetComponent<TMP_Text>();
        text.text = game.CPC.ToString("0");
    }
}