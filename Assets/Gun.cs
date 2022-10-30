using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    void LateUpdate()
    {
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * 10f);

        float angle = AngleBetweenPoints(transform.position, mouseWorldPosition);

        transform.rotation = Quaternion.Euler(new Vector3(0f, -angle, transform.rotation.z));
    }

    float AngleBetweenPoints(Vector2 a, Vector2 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
