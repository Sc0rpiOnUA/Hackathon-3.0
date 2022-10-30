using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryOfGame : MonoBehaviour
{
    [SerializeField] private Toggle _toggle;
    [SerializeField] private GameObject _storyPanel;
    public static int t = 0;

    void Awake()
    {
        if (PlayerPrefs.HasKey("t"))
        {
            t = PlayerPrefs.GetInt("t");
            if (t == 1)
            {
                _storyPanel.SetActive(false);
            }
            if(t == 0)
            {
                _storyPanel.SetActive(true);
            }
        }
        else
        {
            _storyPanel.SetActive(true);
            _toggle.isOn = false;
        }
    }

    public void CloseGameStory()
    {
        _storyPanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void Update()
    {
        if(_toggle.isOn)
        {
            t = 1;
            PlayerPrefs.SetInt("t", t);
        }
    }
}
