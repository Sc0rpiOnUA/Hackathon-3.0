using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseNamePanel : MonoBehaviour
{
    [SerializeField] private GameObject _namePanel;

    void Start()
    {
        if (PlayerPrefs.HasKey("IsNameSet"))
        {
            var temp = PlayerPrefs.GetInt("IsNameSet");
            if (temp == 0)
            {
                _namePanel.SetActive(true);
            }
            else
                _namePanel.SetActive(false);
        }
        else
            _namePanel.SetActive(true);

    }

    public void CloseInputNameField()
    {
        _namePanel.SetActive(false);
    }
}
