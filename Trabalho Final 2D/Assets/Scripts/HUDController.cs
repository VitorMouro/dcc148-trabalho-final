using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    // Singleton instance
    public static HUDController Instance { get; private set; }

    [Header("References")]
    [SerializeField] private Image soundIcon;
    [SerializeField] private Sprite soundOnSprite;
    [SerializeField] private Sprite soundOffSprite;

    private int _currentLevel = 1;

    void Awake()
    {
        // Singleton pattern implementation
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Make persistent
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        UpdateAllUI();
        
        // Ensure canvas stays visible when new scenes load
        GetComponent<Canvas>().worldCamera = Camera.main;
    }

    public void ToggleSound()
    {
        bool isMuted = !AudioListener.pause;
        AudioListener.pause = isMuted;
        
        // Save sound state
        PlayerPrefs.SetInt("MuteState", isMuted ? 1 : 0);
        
        soundIcon.sprite = isMuted ? soundOffSprite : soundOnSprite;
    }
    void OnEnable()
    {
        // Load saved state when enabled 
        _currentLevel=PlayerPrefs.GetInt("CurrentLevel",1); 
        AudioListener.pause=PlayerPrefs.GetInt("MuteState",0)==1; 

        UpdateAllUI(); 
    }

    private void UpdateAllUI()
    {
        soundIcon.sprite=AudioListener.pause?soundOffSprite:soundOnSprite; 
    }
}