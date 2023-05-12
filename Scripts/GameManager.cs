using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField]private PlayerController _playerController;

    [SerializeField]private float _respawnDelay = 2f;
    [SerializeField]private float _nextLevelDelay = 7f;

    private bool _isGameEnd;

    private int _score;

    public Text scoreSayac;
    public Text winText;

    public GameObject WinnerUI;

    void Start()
    {
        WinnerUI.SetActive(false);
        //PlayerController scriptinin içindekilere eriþmemizi saðlar.
        _playerController = FindObjectOfType<PlayerController>();
    }

    public void RespawnPlayer()
    {
        if (_isGameEnd == false)
        {
            _isGameEnd = true;
            StartCoroutine("RespawnCoroutine");
        }
    }

    public IEnumerator RespawnCoroutine()
    {
        _playerController.gameObject.SetActive(false);

        yield return new WaitForSeconds(_respawnDelay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        scoreSayac.text = "0";
        _isGameEnd = false;
    }

    public void AddScore(int numberOfScore)
    {
        _score += numberOfScore;
        scoreSayac.text = _score.ToString();
    }

    public void LevelUp()
    {
        WinnerUI.SetActive(true);
        winText.text = "SCORE: " + _score;
        Invoke("NextLevel", _nextLevelDelay);
    }

    public void NextLevel()
    {
        WinnerUI.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
    }
}
