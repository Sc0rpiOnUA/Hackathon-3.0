using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TramController : MonoBehaviour
{
    [SerializeField] float _speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void FixedUpdate()
    {
        Forward();
    }
    private void ManageMove()
    {
        
    }

    private void Forward()
    {
        
        transform.Translate((Vector3.forward) * _speed);
    }
    private void TurnLeft()
    {

    }
    private void TurnRight()
    {

    }


}
