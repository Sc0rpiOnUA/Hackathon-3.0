using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _startHeight;
    [SerializeField] [Range(-50, 50)] private float _startFar;
    [SerializeField][Range(-50, 50)] private float _endFar;
    [HideInInspector]public bool inPosition = false;
    private void Awake()
    {
        transform.position = _target.position + new Vector3(0f, _startHeight, _startFar);
    }
    void LateUpdate()
    {
        if (inPosition == true)
        {
            transform.position = _target.position + new Vector3(0f, _startHeight, _endFar);

        }
        else
        {
            OnPlay();
        }
    }
    private void OnPlay()
    {
        StartCoroutine(StartSmooth(_target.position + new Vector3(0f, _startHeight, _endFar), 1));
    }
    private IEnumerator StartSmooth(Vector3 targetPosition, float duration)
    {
        float time = 0;
        Vector3 startPosition = transform.position;
        while (time < duration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        float distination = Vector3.Distance(transform.position, targetPosition);
        if (distination < 1f)
        {
            transform.position = targetPosition;
            inPosition = true;
        }
    } 
}
