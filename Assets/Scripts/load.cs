using UnityEngine.SceneManagement;
using UnityEngine;

public class load : MonoBehaviour
{
    public GameObject audiostuff;
    void Awake()
    {
        DontDestroyOnLoad(audiostuff);
        SceneManager.LoadSceneAsync(1);
    }
}
