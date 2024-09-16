using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private AudioSource _audioSource;
    [SerializeField]
    private AudioClip[] _AudioClip;
    private SpawnPlatfon _Spawnplatfon;
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        if (_audioSource == null)
        {
            Debug.LogError("AudipSource is Error!");
        }
        _audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loadArenaGame()
    {
        Debug.Log("Going to Airfield...");
        SceneManager.LoadScene("Switch");
    }

    public void LoadSettingsAirCraft()
    {
        Debug.Log("Going to Hanggar Aircraft...");
        SceneManager.LoadScene("SettingMenu");
        
    }
    public void LoadAirField()
    {
        Debug.Log("Going to Hanggar Aircraft...");
        SceneManager.LoadScene("mainmenu");
    }
}
