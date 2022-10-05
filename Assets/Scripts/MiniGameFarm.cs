using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MiniGameFarm : MonoBehaviour
{

    //UI
    public TMP_Text Farm1_IsGrowingText;
    public TMP_Text Farm2_IsGrowingText;
    public TMP_Text Farm3_IsGrowingText;
    public TMP_Text Farm4_IsGrowingText;
    public TMP_Text Farm1_TimeRemainingText;
    public TMP_Text Farm2_TimeRemainingText;
    public TMP_Text Farm3_TimeRemainingText;
    public TMP_Text Farm4_TimeRemainingText;
    public TMP_Text Farm1_TypeText;
    public TMP_Text Farm2_TypeText;
    public TMP_Text Farm3_TypeText;
    public TMP_Text Farm4_TypeText;
    public TMP_Text SelectedTypeText;

    //time remaining
    public int Farm1_TimeRemaining;
    public int Farm2_TimeRemaining;
    public int Farm3_TimeRemaining;
    public int Farm4_TimeRemaining;

    //is growing
    public bool Farm1_IsGrowing;
    public bool Farm2_IsGrowing;
    public bool Farm3_IsGrowing;
    public bool Farm4_IsGrowing;

    //type
    public int Type;
    public string Farm1_Type;
    public string Farm2_Type;
    public string Farm3_Type;
    public string Farm4_Type;

    //scripts
    public Game game;
    public Notification notification;

    // Start is called before the first frame update
    void Start()
    {
        // Farm1_TimeRemaining = 0;
        // Farm2_TimeRemaining = 0;
        // Farm3_TimeRemaining = 0;
        // Farm4_TimeRemaining = 0;
        StartCoroutine(FarmTick());
    }

    IEnumerator FarmTick()
    {
        yield return new WaitForSeconds(1);
        if (Farm1_TimeRemaining <= 0 && Farm1_IsGrowing == true && Farm1_Type == "Wheet")
        {
            Farm1_IsGrowing = false;
            game.Cookies += 350;
            notification.ShowNotification("Growing has finished. You earned 350 cookies.", "Growing Complete!");
        }
        if (Farm2_TimeRemaining <= 0 && Farm2_IsGrowing == true && Farm2_Type == "Wheet")
        {
            Farm2_IsGrowing = false;
            game.Cookies += 350;
            notification.ShowNotification("Growing has finished. You earned 350 cookies.", "Growing Complete!");
        }
        if (Farm3_TimeRemaining <= 0 && Farm3_IsGrowing == true && Farm3_Type == "Wheet")
        {
            Farm3_IsGrowing = false;
            game.Cookies += 350;
            notification.ShowNotification("Growing has finished. You earned 350 cookies.", "Growing Complete!");
        }
        if (Farm4_TimeRemaining <= 0 && Farm4_IsGrowing == true && Farm4_Type == "Wheet")
        {
            Farm4_IsGrowing = false;
            game.Cookies += 350;
            notification.ShowNotification("Growing has finished. You earned 350 cookies.", "Growing Complete!");
        }
        if (Farm1_TimeRemaining <= 0 && Farm1_IsGrowing == true && Farm1_Type == "White Carrots")
        {
            Farm1_IsGrowing = false;
            game.Cookies += 1000;
            notification.ShowNotification("Growing has finished. You earned 1000 cookies.", "Growing Complete!");
        }
        if (Farm2_TimeRemaining <= 0 && Farm2_IsGrowing == true && Farm2_Type == "White Carrots")
        {
            Farm2_IsGrowing = false;
            game.Cookies += 1000;
            notification.ShowNotification("Growing has finished. You earned 1000 cookies.", "Growing Complete!");
        }
        if (Farm3_TimeRemaining <= 0 && Farm3_IsGrowing == true && Farm3_Type == "White Carrots")
        {
            Farm3_IsGrowing = false;
            game.Cookies += 1000;
            notification.ShowNotification("Growing has finished. You earned 1000 cookies.", "Growing Complete!");
        }
        if (Farm4_TimeRemaining <= 0 && Farm4_IsGrowing == true && Farm4_Type == "White Carrots")
        {
            Farm4_IsGrowing = false;
            game.Cookies += 1000;
            notification.ShowNotification("Growing has finished. You earned 1000 cookies.", "Growing Complete!");
        }
        if (Farm1_IsGrowing == true)
        {
            Farm1_TimeRemaining -= 1;
        }
        if (Farm2_IsGrowing == true)
        {
            Farm2_TimeRemaining -= 1;
        }
        if (Farm3_IsGrowing == true)
        {
            Farm3_TimeRemaining -= 1;
        }
        if (Farm4_IsGrowing == true)
        {
            Farm4_TimeRemaining -= 1;
        }
        StartCoroutine(FarmTick());
    }

    public void Farm1_StartGrowing()
    {
        if (Type == 0)
        {
            Farm1_TimeRemaining = 180;
            Farm1_Type = "Wheet";
        }
        if (Type == 1)
        {
            Farm1_TimeRemaining = 400;
            Farm1_Type = "White Carrots";
        }
        Farm1_IsGrowing = true;
    }

    public void Farm2_StartGrowing()
    {
        if (Type == 0)
        {
            Farm2_TimeRemaining = 180;
            Farm2_Type = "Wheet";
        }
        if (Type == 1)
        {
            Farm2_TimeRemaining = 400;
            Farm2_Type = "White Carrots";
        }
        Farm2_IsGrowing = true;
    }

    public void Farm3_StartGrowing()
    {
        if (Type == 0)
        {
            Farm3_TimeRemaining = 180;
            Farm3_Type = "Wheet";
        }
        if (Type == 1)
        {
            Farm3_TimeRemaining = 400;
            Farm3_Type = "White Carrots";
        }
        Farm3_IsGrowing = true;
    }

    public void Farm4_StartGrowing()
    {
        if (Type == 0)
        {
            Farm4_TimeRemaining = 180;
            Farm4_Type = "Wheet";
        }
        if (Type == 1)
        {
            Farm4_TimeRemaining = 400;
            Farm4_Type = "White Carrots";
        }
        Farm4_IsGrowing = true;
    }

    public void TypeWheet()
    {
        Type = 0;
        SelectedTypeText.text = "Currently Selected: Wheet";
    }

    public void TypeWhiteCarrots()
    {
        Type = 1;
        SelectedTypeText.text = "Currently Selected: White Carrots";
    }

    // Update is called once per frame
    void Update()
    {
        Farm1_IsGrowingText.text = "Growing? " + Farm1_IsGrowing;
        Farm2_IsGrowingText.text = "Growing? " + Farm2_IsGrowing;
        Farm3_IsGrowingText.text = "Growing? " + Farm3_IsGrowing;
        Farm4_IsGrowingText.text = "Growing? " + Farm4_IsGrowing;
        Farm1_TimeRemainingText.text = "Time Remaining: " + Farm1_TimeRemaining;
        Farm2_TimeRemainingText.text = "Time Remaining: " + Farm2_TimeRemaining;
        Farm3_TimeRemainingText.text = "Time Remaining: " + Farm3_TimeRemaining;
        Farm4_TimeRemainingText.text = "Time Remaining: " + Farm4_TimeRemaining;
        Farm1_TypeText.text = "Type: " + Farm1_Type;
        Farm2_TypeText.text = "Type: " + Farm2_Type;
        Farm3_TypeText.text = "Type: " + Farm3_Type;
        Farm4_TypeText.text = "Type: " + Farm4_Type;
        if (Farm1_TimeRemaining < 0)
        {
            Farm1_TimeRemaining = 0;
        }
        if (Farm2_TimeRemaining < 0)
        {
            Farm2_TimeRemaining = 0;
        }
        if (Farm3_TimeRemaining < 0)
        {
            Farm3_TimeRemaining = 0;
        }
        if (Farm4_TimeRemaining < 0)
        {
            Farm4_TimeRemaining = 0;
        }
    }
}
