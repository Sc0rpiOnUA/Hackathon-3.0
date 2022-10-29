using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private GameObject _leaderBoardPanel;
    [SerializeField] private GameObject _settingsPanel;


    void Start()
    {
        _slider = GetComponent<Slider>();
        _slider.value = 0.5f;
        _leaderBoardPanel.SetActive(false);
        _settingsPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (_slider.value == 0) Application.Quit();
        else if (_slider.value == 1) SceneManager.LoadScene(1);

        
    }

    public void OpenLeaderBoard()
    {
        _leaderBoardPanel.SetActive(true);
    }

    public void CloseLeaderBoard()
    {
        _leaderBoardPanel.SetActive(false);
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
