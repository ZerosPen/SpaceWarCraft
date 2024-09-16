using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool _isGameOver;
    private bool _isWin;
    public GameObject MCPanel;
    private UIManager uiManager;

    private void Start()
    {
        uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        if (uiManager == null)
        {
            Debug.LogError("UIManager is not found or not assigned.");
        }

        if (MCPanel == null)
        {
            Debug.LogError("MCPanel is not assigned in the inspector.");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && _isGameOver == true)
        {
            SceneManager.LoadScene(2); //Current Game Scene
        }
        if (Input.GetKeyDown(KeyCode.Escape) && _isGameOver == true)
        {
            SceneManager.LoadScene(0);
        }
        if (Input.GetKeyDown(KeyCode.Escape) && _isWin == true)
        {
            SceneManager.LoadScene(0);
        }
    }
    public void Winning()
    {
        _isWin = true;
        if (MCPanel != null)
        {
            MCPanel.SetActive(true);
        }
        else
        {
            Debug.LogError("MCPanel is not assigned.");
        }
    }

    public void GameOver()
    {
        _isGameOver = true;
    }
}
