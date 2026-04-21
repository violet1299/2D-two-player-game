using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndUI : MonoBehaviour
{
    public GameObject endPanel;
    public TMP_Text scoreText;
    private bool isPlaying;

    void Start()
    {
        endPanel.SetActive(false);
        isPlaying = true;
    }

  
    public void ShowEndUI()
    {
        isPlaying = false;


        endPanel.SetActive(true);
    }


    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0); 
    }
}
