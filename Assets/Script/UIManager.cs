using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private GameManager _gameManager;

    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Image _liveimg;
    [SerializeField]
    private Image _healliveimg;
    [SerializeField]
    private Sprite[] _liveSprite;
    [SerializeField]
    private Sprite[] _healliveSprite;

    [SerializeField]
    private Text _GameOverText;
    [SerializeField]
    private Text _RestartText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score		: " + 0;
        _GameOverText.gameObject.SetActive(false);
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (_gameManager == null)
        {
            Debug.LogError("GameManager is NULL");
        }
    }

    public void UpdateScore(int scorepoint)
    {
        scoreText.text = "Score		: " + scorepoint.ToString();
    }

    public void updateheal(int currentlive)
    {
        _healliveimg.sprite = _liveSprite[currentlive];
        if (currentlive < 4) 
        {
            updatelive(currentlive);
        }
    }

    public void updatelive(int currentLives)
    {
        if ( currentLives < 4)
        {
            _liveimg.sprite = _healliveSprite[currentLives];
        }

        if (currentLives > 4)
        {
            updateheal(currentLives);
        }

        if (currentLives == 0)
        {
            GameOverSec();
        }
            
    }

    void GameOverSec()
    {
        _gameManager.GameOver();
        _GameOverText.gameObject.SetActive(true);
        _RestartText.gameObject.SetActive(true);
        StartCoroutine(GameOverFlickerRoutine());
    }

    IEnumerator GameOverFlickerRoutine()
    {
        while (true)
        {
            _GameOverText.text = "GAME OVER";
            yield return new WaitForSeconds(0.5f);
            _GameOverText.text = "";
            yield return new WaitForSeconds(0.5f);
        }
    }
}
