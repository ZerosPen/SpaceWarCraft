using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private AudioClip _audipclip;
    private AudioSource _audioSource; 
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        if (_audioSource == null)
        {
            Debug.LogError("AudioScource is NULL");
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
        SceneManager.LoadScene("Main");
    }

    public void LoadSettingsAirCraft()
    {
        Debug.Log("Going to Hanggar Aircraft...");
        SceneManager.LoadScene("SampleScene");
    }
    public void LoadAirField()
    {
        Debug.Log("Going to Hanggar Aircraft...");
        SceneManager.LoadScene("mainmenu");
    }

}
