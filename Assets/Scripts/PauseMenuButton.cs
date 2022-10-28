using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuButton : MonoBehaviour
{
    [SerializeField] GameObject _gameMenuPanel;
    [SerializeField] GameObject _easterEggPanel;
    [SerializeField] Toggle _easterEggToggle;
    [SerializeField] private GameObject _settingsPanel;

    void Start()
    {
        _gameMenuPanel.SetActive(false);
        _easterEggPanel.SetActive(false);
        _settingsPanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            _gameMenuPanel.SetActive(true);
            Time.timeScale = 0;
        }
        if(_easterEggToggle.isOn)
        {
            PlayerPrefs.DeleteKey("t");
            StoryOfGame.t = 0;
        }
    }

    public void BackToGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _gameMenuPanel.SetActive(false);
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene(0);
    }

    public void EasterEggOpen()
    {
        _easterEggPanel.SetActive(true );
    }

    public void CloseEasterEgg()
    {
        _easterEggPanel.SetActive(false);
    }
    public void OpenSettingsButton()
    {
        _settingsPanel.SetActive(true);
    }

    public void CloseSettingsButton()
    {
        _settingsPanel.SetActive(false);
    }


}
