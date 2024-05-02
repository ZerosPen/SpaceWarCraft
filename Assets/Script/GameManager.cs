using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool _isGameOver;

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
    }
    public void winLvl()
    {
        Debug.Log("WIN!!!");
    }

    public void GameOver()
    {
        _isGameOver = true;
    }
}
