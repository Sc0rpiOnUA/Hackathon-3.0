using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class HarpoonController : MonoBehaviour
{
    [SerializeField] private Slider _harpoonSlider;
    public bool _isHarpoonShooted = false;
    public bool _isHarpoonCharged = false;
    public float sliderSpeed;
    public UnityEvent OnHookCharged, OnHookUnCharged;

    void Start()
    {
        _harpoonSlider.value = 0;


    }

    // Update is called once per frame
    void Update()
    {
        if(_isHarpoonCharged = false || _harpoonSlider.value < 1 )
        {
            _harpoonSlider.value += sliderSpeed;
            OnHookUnCharged.Invoke();
        }
        if (_harpoonSlider.value == 1)
        {
            OnHookCharged.Invoke();
            _isHarpoonCharged = true;
            _isHarpoonShooted = false;
        }

    }

    public void HarpoonShoot()
    {
        if(_isHarpoonCharged == true && _isHarpoonShooted == false)
        {
            _isHarpoonShooted = true;
            _harpoonSlider.value = 0;
            _isHarpoonCharged = false;
        }
        
    }
}
