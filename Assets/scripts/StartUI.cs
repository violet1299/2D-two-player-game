using UnityEngine;
using UnityEngine.SceneManagement;

public class StartUI : MonoBehaviour
{
    public GameObject StartPanel;
    public string nextSceneName = "scene1";

    void Start()
    {
        
        Time.timeScale = 0f;
        StartPanel.SetActive(true);
    }

    public void StartGame()
    {
        
        Time.timeScale = 1f;

        
        SceneManager.LoadScene(nextSceneName);
    }
}
