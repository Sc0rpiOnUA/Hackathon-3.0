using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [HideInInspector]public Transform player;
    public float bombLife = 3;
    void Awake()
    {
        Destroy(gameObject, bombLife);
    }
    private void Update()
    {
        player = GameObject.FindWithTag("Player").transform;
        transform.LookAt(player);
    }
}
