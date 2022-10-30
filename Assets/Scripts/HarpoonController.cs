using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HarpoonController : MonoBehaviour
{
    [SerializeField] private Slider _harpoonSlider;
    public bool _isHarpoonShooted = false;
    public bool _isHarpoonCharged = false;
    public float sliderSpeed;


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
        }
        if (_harpoonSlider.value == 1)
        {
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
