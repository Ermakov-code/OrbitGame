using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject menuCanvas;
    [SerializeField] private GameObject gameOverCanvas;
    [SerializeField] private GameObject settingsCanvas;
    [SerializeField] private GameObject gameCanvas;
    
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button playButton;
    [SerializeField] private Button closeButton;
    [SerializeField] private Button soundOnButton;
    [SerializeField] private Button soundOffButton;
    [SerializeField] private Button restartButton;

    [SerializeField] private GameObject korabl;
    [SerializeField] private GameObject objectPool;

    [SerializeField] private AudioClip clickSound;
    private void Awake()
    {
        menuCanvas.SetActive(true);
        korabl.GetComponent<OrbitRotate>().enabled = false;
        gameCanvas.SetActive(false);
        objectPool.GetComponent<ObjectPooler>().enabled = false;
        if (PlayerPrefs.GetInt("sound") == 1)
            SoundOn();
        else
            SoundOff();
    }

    void Start()
    {
        soundOnButton.GetComponent<Button>().onClick.AddListener(SoundOn);
        soundOffButton.GetComponent<Button>().onClick.AddListener(SoundOff);
        closeButton.GetComponent<Button>().onClick.AddListener(CloseSettings);
        playButton.GetComponent<Button>().onClick.AddListener(StartGame);
        settingsButton.GetComponent<Button>().onClick.AddListener(OpenSettings);
        restartButton.GetComponent<Button>().onClick.AddListener(RestartGame);
    }

    private void SoundOn()
    {
        AudioSource.PlayClipAtPoint(clickSound, transform.position);
        soundOffButton.interactable = true;
        soundOnButton.interactable = false;
        AudioListener.pause = false;
        PlayerPrefs.SetInt("sound", 1);
    }
    
    private void SoundOff()
    {
        soundOffButton.interactable = false;
        soundOnButton.interactable = true;
        AudioListener.pause = true;
        PlayerPrefs.SetInt("sound", 0);
    }

    private void StartGame()
    {
        AudioSource.PlayClipAtPoint(clickSound, transform.position);
        menuCanvas.SetActive(false);
        korabl.GetComponent<OrbitRotate>().enabled = true;
        gameCanvas.SetActive(true);
        objectPool.GetComponent<ObjectPooler>().enabled = true;
    }

    private void CloseSettings()
    {
        AudioSource.PlayClipAtPoint(clickSound, transform.position);
        menuCanvas.SetActive(true);
        settingsCanvas.SetActive(false);
    }

    private void OpenSettings()
    {
        AudioSource.PlayClipAtPoint(clickSound, transform.position);
        settingsCanvas.SetActive(true);
        menuCanvas.SetActive(false);
    }

    private void RestartGame()
    {
        AudioSource.PlayClipAtPoint(clickSound, transform.position);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }

    public void GameOver()
    {
        AudioSource.PlayClipAtPoint(clickSound, transform.position);
        gameOverCanvas.SetActive(true);
        korabl.GetComponent<OrbitRotate>().enabled = false;
        gameCanvas.SetActive(false);
        objectPool.GetComponent<ObjectPooler>().enabled = false;
    }
}
