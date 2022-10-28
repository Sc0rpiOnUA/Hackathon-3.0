using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private Slider _volumeSlider;



    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = 0.6f;
        LevelOfSound();

    }

    // Update is called once per frame
    void Update()
    {
        _audioSource.volume = _volumeSlider.value;
    }

    public void SoundOffButton()
    {
        _audioSource.Stop();
    }

    public void SoundOnButton()
    {
        
       if(!_audioSource.isPlaying)
        {
            LevelOfSound();
            _audioSource.Play();
        };
    }

    public void LevelOfSound()
    {
        _volumeSlider.value = 0.6f;
    }
}
