using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMManager : MonoBehaviour
{
    public static BGMManager instance;

    [Header("√øπÿBGM≈‰÷√")]
    public AudioClip level1BGM;   
    public AudioClip level2BGM;   
    public AudioClip gameOverBGM; 
    public AudioClip homeBGM;     
    private AudioSource audioSource;

    void Awake()
    {
       
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        audioSource = GetComponent<AudioSource>();
    }

    
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
      
        switch (scene.name)
        {
            case "Begin": 
                PlayBGM(homeBGM);
                break;
            case "scene1": 
                PlayBGM(level1BGM);
                break;
            case "scene2":
                PlayBGM(level2BGM);
                break;
            case "Scene 3": 
                PlayBGM(gameOverBGM);
                break;
        }
    }

  
    void PlayBGM(AudioClip clip)
    {
        if (clip == null) return; 
        audioSource.clip = clip;
        audioSource.volume = 0.5f; 
        audioSource.loop = true;  
        audioSource.Play();
    }

    
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}