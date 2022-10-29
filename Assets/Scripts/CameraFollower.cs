using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _height;
    [SerializeField] [Range(-20,0)] private float _far;
    void LateUpdate()
    {
        transform.position = _target.position+new Vector3(0f,_height,_far);
    }
}
