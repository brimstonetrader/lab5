using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public GameObject dialogBox;
    public TextMeshProUGUI dialogText;
    public GameObject curtain;
    public GameObject canvas;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI TimerText;
    private int score;
    private int timer = 60;
    private bool raiseLower = false;

    [SerializeField] Slider volumeSlider;
    //public GameObject mainScreen;    
    //public GameObject menuButton;   

    void Start() {
        if (!PlayerPrefs.HasKey("musicVolume")) { 
            PlayerPrefs.SetFloat("musicVolume", 1.0f);
            Load();
        } 
        
        else  {
            Load();
        }
    }
    
    void Update() {

    }

    public void ChangeVolume() {
        AudioListener.volume = volumeSlider.value;
        Save();
    }

    private void Load() {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }
    
    private void Save() {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }

    public void DialogShow(string text)
    {
        dialogBox.SetActive(true);
        StopAllCoroutines();
        StartCoroutine(TypeText(text));
    }

    public void DialogHide()
    {
        dialogBox.SetActive(false);
    }

    IEnumerator TypeText(string text)
    {
        dialogText.text = "";
        foreach (char c in text.ToCharArray())
        {
            dialogText.text += c;
            yield return new WaitForSeconds(0.02f);
        }
    }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void incScore()
    {
        score = score + 10 ;
        ScoreText.text = "Score: " + score;
    }
}

    