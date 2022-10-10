using UnityEngine.SceneManagement;
using UnityEngine;

public class load : MonoBehaviour
{
    public GameObject audiostuff;
    public Game game;
    public GameObject TutorialPrompt;
    void Awake()
    {
        DontDestroyOnLoad(audiostuff);
        SceneManager.LoadSceneAsync(1);
    }
}
